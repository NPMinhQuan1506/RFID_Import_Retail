package com.rfid.app;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Environment;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;
import java.util.Map.Entry;
import java.util.Objects;
import java.util.Set;

/**
 * Created by Administrator on 2021/6/22.
 */

public class FileImport {
    static String xlsFilePath = Environment.getExternalStorageDirectory() + "/RfidData/";
    static String FilePathTxt = "";
    Database conn = new Database();

    public static List<String> LoadFileScan(String fileName) {
        List<String> list = new ArrayList<>();
        if (fileName.endsWith("xls") || fileName.endsWith("xlsx")) {
            list = LoadFileXls(fileName);
        } else {
            list = LoadFileText(fileName);
        }
        return list;
    }

    public static List<String> LoadFileXls(String fileName) {
        List<String> list = new ArrayList<>();
        try {
            ArrayList<HashMap<String, Object>> arrayLists = FileXls.readXLSmap(fileName);
            for (HashMap<String, Object> item : arrayLists) {
                list.add(Objects.requireNonNull(item.get("tagUii")).toString()); // xls only store field tagUii
            }
        } catch (Exception e) {
            e.printStackTrace();
            throw e;
        }
        return list;
    }

    public static List<String> LoadFileText(String fileName) {
        List<String> list = new ArrayList<>();
        try {
            File file = new File(fileName);

            if (file.exists())
                list = Files.readAllLines(file.toPath());
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return list;
    }

    // save rfids to TXT
    public static boolean SaveFileTxt(ArrayList<HashMap<String, String>> lists2, String fileName) throws Exception {
        try {
            if (fileName.isEmpty())
                FilePathTxt = xlsFilePath + "txt" + GetTimesyyyymmddhhmmss() + ".txt";
            else
                FilePathTxt = xlsFilePath + fileName;

            File path2 = new File(xlsFilePath);
            if (path2.mkdirs()) {
            }

            List<String> lst = new ArrayList<>();
            for (int i = 0; i < lists2.size(); i++) {
                Set<Entry<String, String>> sets = lists2.get(i).entrySet();
                for (Entry<String, String> entry : sets) {
                    if (entry.getKey().equals("tagUii")) {
                        String str = entry.getValue().toString();
                        str = str.replace("EPC:", "");
                        str = str.replace("TID:", "");

                        lst.add(str);
                    } else {
                    }
                }
            }

            Files.write(Paths.get(FilePathTxt), lst);
            return true;
        } catch (Exception ex) {
            throw ex;
        }
    }

    // save rfids to SQL
    public boolean SaveSQL(ArrayList<HashMap<String, String>> lists2, Context cont, String grnId, String productId, Boolean isMapping) throws Exception {
        try {
//            SQLiteHelper db = new SQLiteHelper(cont);
            List<RFID> list = new ArrayList<>();

            String id = "";
            for (int i = 0; i < lists2.size(); i++) {
                Set<Entry<String, String>> sets = lists2.get(i).entrySet();

                for (Entry<String, String> entry : sets) {
                    if (entry.getKey().equals("tagUii")) {
                        id = entry.getValue().toString();
                        id = id.replace("EPC:", "");
                        id = id.replace("TID:", "");
//                        id = id.substring(0, 12);
                        id = id.substring(id.length() - 5, id.length());
                        RFID item = new RFID();
                        item.EPC = id;

                        ConnectMySQL connectMySql = new ConnectMySQL(grnId, productId, item.EPC, isMapping);
                        connectMySql.execute();
                        list.add(item);
                    } else {
                    }
                }
            }
//            db.addList(list);

            return true;
        } catch (Exception ex) {
            throw ex;
        }
    }

    private class ConnectMySQL extends AsyncTask<Void, Void, Void> {
        String grnId, productId, EPC;
        Boolean isMapping;

        public ConnectMySQL(String _grnId, String _productId, String _EPC, Boolean _isMapping) {
            this.grnId = _grnId;
            this.productId = _productId;
            this.EPC = _EPC;
            this.isMapping = _isMapping;
        }

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected Void doInBackground(Void... params) {
            String query = "";
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.getDefault());
            String dtNow = sdf.format(new Date());
            if (isMapping) {
//                int random = (int) (Math.random() * 5 + 1);
//                query = "Insert into ProductRFID (`rfid`, `product_line_id`, `mapping_time`, `is_checked`) " +
//                        "values('" + EPC + "', (SELECT product_line_id FROM Product ORDER BY RAND() LIMIT 1), '" + dtNow + "' , '0')";
                query = "Insert into ProductRFID (`rfid`, `product_line_id`, `mapping_time`, `is_checked`) " +
                        "values('" + EPC + "', '"+productId+"', '" + dtNow + "' , '0')";
            } else {
                query = "Update GoodsReceiptNoteDetail Set actual_quantity =  actual_quantity + 1 " +
                        "Where grn_id = '" + grnId + "' And product_line_id = (Select product_line_id from ProductRFID WHERE is_checked = 0 and rfid = '" + EPC + "') " +
                        "And actual_quantity < expected_quantity; ";
                query += "Update GoodsReceiptNoteDetail Set is_checked = '1'" +
                        "Where grn_id = '" + grnId + "' And product_line_id = (Select product_line_id from ProductRFID WHERE is_checked = 0 and rfid = '" + EPC + "') " +
                        "And actual_quantity >= expected_quantity; ";
                query += "Update ProductRFID Set is_checked = '1' " +
                        "WHERE rfid = '" + EPC + "'; ";
                query += "Update GoodsReceiptNote Set total_actual_quantity = total_actual_quantity + 1 " +
                        "Where grn_id = '" + grnId + "' and total_actual_quantity < total_expected_quantity;";
                query += "Update GoodsReceiptNote Set note = 'Completed quantity' " +
                        "Where grn_id = '" + grnId + "' and total_actual_quantity >= total_expected_quantity;";
            }
            conn.executeDatabase(query);
            return null;
        }

        @Override
        protected void onPostExecute(Void s) {
            super.onPostExecute(s);
        }
    }

    public static boolean SaveFileXls(ArrayList<HashMap<String, String>> lists2, String tmpname) throws Exception {
        try {
            String file = "";
            if (tmpname.isEmpty())
                file = xlsFilePath + "xls" + GetTimesyyyymmddhhmmss() + ".xls";
            else
                file = xlsFilePath + tmpname;
            File path2 = new File(xlsFilePath);

            if (path2.mkdirs()) {

            }
            List<Object> al22 = new ArrayList<Object>();
            List<String> al2 = new ArrayList<String>();
            al2.add("SerialNo");

            al22.add(al2);
            FileXls.writeXLS(file, al22);
            List<Object> ac = new ArrayList<Object>();

            int adds = -1;
            String id = "";
            // String sxl = "";
            for (int i = 0; i < lists2.size(); i++) {
                List<String> al = new ArrayList<String>();
                Set<Entry<String, String>> sets = lists2.get(i).entrySet();

                for (Entry<String, String> entry : sets) {
                    if (entry.getKey().equals("tagUii")) {
                        id = entry.getValue().toString();
                        id = id.replace("EPC:", "");
                        id = id.replace("TID:", "");
                    } else {
                    }
                    // Object value=entry.getValue();
                }
                al.add(id);

                // al.add(sxl);
                ac.add(al);
            }

            return FileXls.writeXLS(file, ac);
        } catch (Exception ex) {
            throw ex;
        }
    }

    public static String GetTimesyyyymmddhhmmss() {

        SimpleDateFormat formatter = new SimpleDateFormat("yyyyMMddHHmmss");
        Date curDate = new Date(System.currentTimeMillis());
        String dt = formatter.format(curDate);

        return dt;

    }
}
