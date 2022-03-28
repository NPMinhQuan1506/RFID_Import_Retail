package com.rfid.app;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import java.util.List;

public class SQLiteActivity extends Activity {
    private ListViewExtAdapter fAdapter;
    private EditText edtSearch;
    private TextView textViewSearch;
    private ListView listView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            setContentView(R.layout.activity_sqlite);

            edtSearch = findViewById(R.id.edtSearch);
            textViewSearch = findViewById(R.id.textViewSearch);

            listView = findViewById(R.id.listView);
            fAdapter = new ListViewExtAdapter(this);
            fAdapter.setFieldNames(new String[]{UIHelper.STT, UIHelper.VALUETEXT}, 2);
            fAdapter.setResource(R.layout.listview_columns);
            listView.setAdapter(fAdapter);

            findViewById(R.id.btnBack).setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    onBackPressed();
                }
            });

            findViewById(R.id.btnDelete).setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    DeleteData("");
                }
            });

            findViewById(R.id.btnLoad).setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Load();
                }
            });

        } catch (Exception ex) {
            onBackPressed();
            UIHelper.showExceptionError(SQLiteActivity.this, ex);
        }
    }

    public void DeleteData(String typeCmd)
    {
        // delete all data
        if (deleteDatabase(UIHelper.DatabaseName)) {
            UIHelper.ToastMessageLong(SQLiteActivity.this, R.string.deleted_database_success);
            edtSearch.setText("");
            Load();
        }
    }

    public void Load() {
        textViewSearch.setText(R.string.form_scan_detail);
        SQLiteHelper db = new SQLiteHelper(SQLiteActivity.this);

        List<AndroidList> itemList = db.getRFIDScanList(edtSearch.getText().toString());
        if (itemList != null && itemList.size() > 0) {
            textViewSearch.setText(String.format("Total %", itemList.size()));
        }

        fAdapter.addDataSource(itemList);
    }
}
