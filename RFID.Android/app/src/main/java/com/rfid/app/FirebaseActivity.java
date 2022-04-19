package com.rfid.app;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.rfid.app.Model.RFIDProduct;
import com.rfid.app.Model.SP;


public class FirebaseActivity extends Activity {
    Button btnAdd, btnAddRFID ;
    @Override
    protected void onCreate( Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.firebase_layout);

        btnAdd = (Button) findViewById(R.id.btnAdd);
        btnAddRFID = (Button) findViewById(R.id.btnAddRFID);


        btnAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                addObject();
            }
        });

        btnAddRFID.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                addObjectRFID();
            }
        });
    }
    public void addObject(){
        FirebaseDatabase database =FirebaseDatabase.getInstance();
        DatabaseReference product_ref= database.getReference("Product").child("sp002");
        SP SP002 =new SP("Laptop",50000,"cái",10,20,"Đồ Công Nghệ",
                "Mắc quá đi",0,"00B0 7A14 2C2B 2848 0800 0166","2022-03-16 10:47:59.000","2022-03-20 10:47:59.000");

        product_ref.setValue(SP002, new DatabaseReference.CompletionListener() {
            @Override
            public void onComplete(@Nullable DatabaseError error, @NonNull DatabaseReference ref) {
                Toast.makeText(FirebaseActivity.this, "Add Success", Toast.LENGTH_SHORT).show();
            }
        });

    }
    public void addObjectRFID(){
        FirebaseDatabase database =FirebaseDatabase.getInstance();
        DatabaseReference product_ref= database.getReference("ProductRFID");
        DatabaseReference sP_ref= product_ref.child("sp002").child("00B0 7A14 2C2B 2848 0800 0169");
        RFIDProduct rfid=new RFIDProduct(0,"2022-03-16 10:47:59.000",
                "sp001","00B0 7A14 2C2B 2848 0800 0166");

        sP_ref.setValue(rfid, new DatabaseReference.CompletionListener() {
            @Override
            public void onComplete(@Nullable DatabaseError error, @NonNull DatabaseReference ref) {
                Toast.makeText(FirebaseActivity.this, "Add Success", Toast.LENGTH_SHORT).show();
            }
        });


    }
}
