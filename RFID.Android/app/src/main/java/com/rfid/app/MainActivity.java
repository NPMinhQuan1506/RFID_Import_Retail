package com.rfid.app;

import static androidx.constraintlayout.helper.widget.MotionEffect.TAG;

import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.ListView;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Date;
import java.util.ArrayList;
import java.util.Calendar;

public class MainActivity extends Activity {
    private static final String TAG = "ReadAndWriteSnippets";
    private Button btMapping;
    private ImageButton ibtRefresh;
    Database conn = new Database();
    ArrayList<ImportData> dataModels;
    ListView listView;
    private static ImportApdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        // Write a message to the database
        btMapping = (Button) findViewById(R.id.btMapping);
        btMapping.setOnClickListener(new btMappingClickListener());
        listView = (ListView) findViewById(R.id.list);
        ibtRefresh = (ImageButton) findViewById(R.id.ibtRefresh);
        ibtRefresh.setOnClickListener(new ibtRefreshClickListener());

        dataModels = new ArrayList<>();
        ConnectMySQL connectMySql = new ConnectMySQL();
        connectMySql.execute("");
        adapter = new ImportApdapter(dataModels, getApplicationContext());
        listView.setAdapter(adapter);
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {

//                ImportData dataModel= dataModels.get(position);
//
//                Snackbar.make(view, dataModel.getName()+"\n"+dataModel.getType()+" API: "+dataModel.getVersion_number(), Snackbar.LENGTH_LONG)
//                        .setAction("No action", null).show();
            }
        });

    }

    private class ConnectMySQL extends AsyncTask<String, String, String> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected String doInBackground(String... params) {
            String query = "Select grn_id, total_expected_quantity, total_actual_quantity, created_time from GoodsReceiptNote " +
                    "Where is_enable = 1 " +
                    "and total_actual_quantity between 0 and total_expected_quantity - 1";

            try {
                ResultSet rs = conn.loadData(query);
                while (rs.next()) {
                    dataModels.add(
                            new ImportData(
                                    rs.getString(1).toString(),
                                    Integer.parseInt(rs.getString(2).toString()),
                                    Integer.parseInt(rs.getString(3).toString()),
                                    "",
                                    "",
                                    0,
                                    rs.getString(4).toString()
                            )
                    );
                }
            } catch (SQLException throwables) {
                throwables.printStackTrace();
            }
            return null;
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
        }
    }

    private class btMappingClickListener implements View.OnClickListener {
        @Override
        public void onClick(View v) {
            Intent intent = new Intent(MainActivity.this, MappingActivity.class);
            startActivity(intent);
        }
    }

    private class ibtRefreshClickListener implements View.OnClickListener {
        @Override
        public void onClick(View v) {
            dataModels.clear();
            adapter.clearData();
            ConnectMySQL connectMySql = new ConnectMySQL();
            connectMySql.execute("");
            adapter = new ImportApdapter(dataModels, getApplicationContext());
            listView.setAdapter(adapter);
            adapter.notifyDataSetChanged();
        }
    }

    private void loadDataFirebase() {

    }
}