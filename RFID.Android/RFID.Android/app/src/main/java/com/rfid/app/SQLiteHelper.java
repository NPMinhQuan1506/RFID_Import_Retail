package com.rfid.app;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.util.ArrayList;
import java.util.List;

public class SQLiteHelper extends SQLiteOpenHelper {
    private static final String TAG = "SQLite";

    // table ITEM
    private static final String ITEMS_Query = "Id, ItemCode, ItemName";
    private static final String TABLE_ITEM = "ITEMS";
    private static final String COL_Id = "Id";
    private static final String COL_ItemCode = "ItemCode";
    private static final String COL_ItemName = "ItemName";

    // table RFID
    private static final String RFID_Query = "Id, ItemCode, ItemName, EPC, RSSI, Count, Created";
    private static final String TABLE_RFID = "RFIDS";
    private static final String COL_EPC = "EPC";
    private static final String COL_RSSI = "RSSI";
    private static final String COL_Count = "Count";
    private static final String COL_Created = "Created";

    public SQLiteHelper(Context context)  {
        super(context, UIHelper.DatabaseName, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        // Script to create tables.
        String script = "CREATE TABLE " + TABLE_ITEM
                + "(" + COL_Id + " INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, "
                + COL_ItemCode + " TEXT, "
                + COL_ItemName + " TEXT)";
        db.execSQL(script);

        // Script to create table ITEM Detail
        script = "CREATE TABLE " + TABLE_RFID
                + "(" + COL_Id + " INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, "
                + COL_ItemCode + " TEXT, "
                + COL_ItemName + " TEXT, "
                + COL_EPC + " TEXT, "
                + COL_RSSI + " TEXT,"
                + COL_Count + " INTEGER, "
                + COL_Created + " TEXT)";
        db.execSQL(script);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
       // Drop table
    }

    // ITEM functions
    public long addUpdate(ITEM v) {
        // check exists
        SQLiteDatabase db = this.getWritableDatabase();
        Cursor cursor = db.query(TABLE_ITEM, new String[] { ITEMS_Query },
                COL_ItemCode + "=?", new String[] { String.valueOf(v.ItemCode) },
                null, null, null, null);

        ITEM itemDto = null;
        if (cursor != null && cursor.moveToFirst()) {
            itemDto = ITEMDto(cursor,1);
        }

        long result = 0;
        ContentValues values = new ContentValues();
        if (itemDto != null) {
            values.put(COL_ItemCode, v.ItemCode);
            values.put(COL_ItemName, v.ItemName);
            // Inserting Row
            result = db.insert(TABLE_ITEM, null, values);
        }
        else{
            values.put(COL_ItemName, v.ItemName);
            // update Row
            result = db.update(TABLE_ITEM, values,
                    COL_ItemCode + " = ?", new String[] { String.valueOf(v.ItemCode)});
        }

        db.close();
        return result;
    }

    public ITEM get(int id) {
        SQLiteDatabase db = this.getReadableDatabase();

        Cursor cursor = db.query(TABLE_ITEM, new String[] { ITEMS_Query },
                COL_Id + "=?", new String[] { String.valueOf(id) },
                null, null, null, null);

        ITEM v = null;
        if (cursor != null && cursor.moveToFirst()) {
            v = ITEMDto(cursor,1);
        }

        cursor.close();
        db.close();

        return v;
    }

    private ITEM ITEMDto(Cursor cursor, int i){
        ITEM v = new ITEM();
        v.Id = Integer.parseInt(cursor.getString(0));
        v.ItemCode = cursor.getString(1);
        v.ItemName = cursor.getString(2);
        return  v;
    }

    public List<ITEM> searchItem(String searchText) {
        SQLiteDatabase db = this.getReadableDatabase();

        String selection = null;
        String[] selectionArgs = null;

        if (!UIHelper.isNullOrEmpty(searchText)) {
            selection = COL_ItemCode + " like ? AND " + COL_ItemName + " like ? ";
            selectionArgs = new String[] { "%" + searchText + "%", "%" + searchText + "%" };
        }
        Cursor cursor = db.query(TABLE_ITEM, new String[]{ ITEMS_Query },
                selection, selectionArgs,
                null, null, COL_Id, null);

        int i = 1;
        List<ITEM> result = new ArrayList<>();
        if (cursor != null && cursor.moveToFirst()) {
            do {
                ITEM v = ITEMDto(cursor, i++);
                result.add(v);
            } while(cursor.moveToNext());
        }

        cursor.close();
        db.close();

        return result;
    }

    // RFID functions
    public void addList(List<RFID> list) {
        // save list
        for(RFID item : list ){
            add(item);
        }
    }

    public long add(RFID v) {
        SQLiteDatabase db = this.getWritableDatabase();
        long id = 0;
        if (v.Id == 0) {
            ContentValues values = new ContentValues();
            values.put(COL_Id, v.Id);
            values.put(COL_ItemCode, v.ItemCode);
            values.put(COL_ItemName, v.ItemName);
            values.put(COL_EPC, v.EPC);
            values.put(COL_RSSI, v.RSSI);
            values.put(COL_Created, v.Created);

            // Inserting Row
            id = db.insert(TABLE_RFID, null, values);
        }
        else{
            RFID rfid = getRFID(v.EPC);
            if (rfid == null)
                id = update(v);
        }
        db.close();

        return id;
    }

    public long update(RFID v) {
        SQLiteDatabase db = this.getWritableDatabase();

        ContentValues values = new ContentValues();
        values.put(COL_Count, v.Count);
        values.put(COL_ItemCode, v.ItemCode);
        values.put(COL_ItemName, v.ItemName);

        // Updating Row
        int result = db.update(TABLE_RFID, values,
                COL_EPC + " = ?", new String[]{ v.EPC });

        db.close();

        return result;
    }

    public RFID getRFID(String ePC) {
        RFID v = null;

        SQLiteDatabase db = this.getReadableDatabase();

        Cursor cursor = db.query(TABLE_RFID, new String[] { RFID_Query },
                COL_EPC + "=?", new String[] { ePC },
                null, null, null, null);

        int i = 1;
        if (cursor != null && cursor.moveToFirst()) {
            v = RFIDDto(cursor, i++);
        }

        cursor.close();
        db.close();

        return v;
    }

    public List<AndroidList> getRFIDScanList(String searchText) {
        List<AndroidList> result = new ArrayList<>();
        List<RFID> getRFIDList = getRFIDList(searchText);

        int totalQty = 0;
        for(RFID item : getRFIDList) {
            AndroidList v = new AndroidList();
            v.Stt = item.Stt;
            v.ValueKey = String.valueOf(item.Id);
            v.ValueText = String.format("%s - %s", item.EPC, item.ItemCode);
            result.add(v);
        }

        AndroidList total = new AndroidList();
        total.ValueText = String.format("Total (%s)", UIHelper.getHtmlGreen(totalQty + (result.size() > 1 ? " tags" : " tag")) +")");
        result.add(0, total);

        return result;
    }

    private List<RFID> getRFIDList(String searchText) {
        List<RFID> result = new ArrayList<>();

        SQLiteDatabase db = this.getReadableDatabase();

        String selection = null;
        String[] selectionArgs = null;
        if (searchText == null || searchText.equals("")) {
            selection = COL_ItemCode + " like ? ";
            selectionArgs = new String[]{  "%" + searchText + "%" };
        }

        Cursor cursor = db.query(TABLE_RFID, new String[] { RFID_Query },
                selection, selectionArgs,
                null, null, null, null);

        int i = 1;
        if (cursor != null && cursor.moveToFirst()) {
            do {
                RFID v = RFIDDto(cursor, i++);
                result.add(v);
            } while(cursor.moveToNext());
        }

        cursor.close();
        db.close();

        return result;
    }

    private RFID RFIDDto(Cursor cursor, int i){
        RFID v = new RFID();
        v.Stt = i;
        v.Id = Integer.parseInt(cursor.getString(0));
        v.ItemCode = cursor.getString(1);
        v.ItemName = cursor.getString(2);
        v.EPC = cursor.getString(5);
        v.RSSI = cursor.getString(6);
        v.Count = Integer.parseInt(cursor.getString(6));
        v.Created = cursor.getString(7);
        return  v;
    }

}
