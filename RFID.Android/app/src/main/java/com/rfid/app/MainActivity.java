package com.rfid.app;

import static androidx.constraintlayout.helper.widget.MotionEffect.TAG;

import android.app.Activity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;

import java.util.Date;
import java.util.ArrayList;
import java.util.Calendar;

public class MainActivity extends Activity {
    private static final String TAG = "ReadAndWriteSnippets";
    private Button btMapping;
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

        dataModels = new ArrayList<>();
//        if (mDatabase != null) {
//            mDatabase = null;
//        }
//        mDatabase = FirebaseDatabase.getInstance().getReference();
//        mDatabase.child("ProductRFID").addValueEventListener(new ValueEventListener() {
//            @Override
//            public void onDataChange(DataSnapshot dataSnapshot) {
//                // get all of the children at this level.
//                Iterable<DataSnapshot> children = dataSnapshot.getChildren();
//
//                ImportApdapter sampleAdapter = (ImportApdapter) listView.getAdapter();
//                if (sampleAdapter != null) {
//                    dataModels.clear();
//                }
//
//                // shake hands with each of them.'
//                for (DataSnapshot child : children) {
//                    Iterable<DataSnapshot> children1 = child.getChildren();
//
//                    for (DataSnapshot child1 : children1) {
//                        ImportData specimenDTO = child1.getValue(ImportData.class);
//                        dataModels.add(specimenDTO);
//                    }
//                }
//                adapter = new ImportApdapter(dataModels, getApplicationContext());
//
//                listView.setAdapter(adapter);
//                if (mDatabase != null) {
//                    mDatabase.removeEventListener(this);
//                    mDatabase = null;
//                }
//
//            }
//
//            @Override
//            public void onCancelled(DatabaseError databaseError) {
//
//            }
//        });
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

    private class btMappingClickListener implements View.OnClickListener {
        @Override
        public void onClick(View v) {

//            FirebaseDatabase database = FirebaseDatabase.getInstance();
//            DatabaseReference myRef = database.getReference("message");
//
//            myRef.setValue("Hello, World!");
        }
    }

    private void loadDataFirebase() {

    }
}