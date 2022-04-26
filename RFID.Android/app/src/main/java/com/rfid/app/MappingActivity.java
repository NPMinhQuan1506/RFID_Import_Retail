package com.rfid.app;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ImageButton;
import android.widget.ListView;

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class MappingActivity extends Activity {

    private ImageButton ibtRefresh;
    Database conn = new Database();
    ArrayList<ProductData> dataModels;
    ListView listView;
    private static MappingAdapter adapter;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mapping);

        listView = (ListView) findViewById(R.id.list);
        ibtRefresh = (ImageButton) findViewById(R.id.ibtRefresh);
        ibtRefresh.setOnClickListener(new ibtRefreshClickListener());

        dataModels = new ArrayList<>();
        ConnectMySQL connectMySql = new ConnectMySQL();
        connectMySql.execute("");
        adapter = new MappingAdapter(dataModels, getApplicationContext());
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
            String query = "Select product_line_id, name, type, price from Product " +
                    "Where is_enable = 1; ";

            try {
                ResultSet rs = conn.loadData(query);
                while (rs.next()) {
                    dataModels.add(
                            new ProductData(
                                rs.getString(1).toString(),
                                rs.getString(2).toString(),
                                rs.getString(3).toString(),
                                Integer.valueOf(rs.getString(4))
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

    private class ibtRefreshClickListener implements View.OnClickListener {
        @Override
        public void onClick(View v) {
            dataModels.clear();
            adapter.clearData();
            ConnectMySQL connectMySql = new ConnectMySQL();
            connectMySql.execute("");
            adapter = new MappingAdapter(dataModels, getApplicationContext());
            listView.setAdapter(adapter);
            adapter.notifyDataSetChanged();
        }
    }
}