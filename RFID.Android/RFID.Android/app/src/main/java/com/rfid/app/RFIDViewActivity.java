package com.rfid.app;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.MotionEvent;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.rfid.app.filebrowser.FileManagerActivity;

import org.apache.commons.io.FilenameUtils;

import java.util.List;

public class RFIDViewActivity extends Activity {
    public static final int REQUESTCODE_CHOOSE_FILE = 3;
    private TextView textViewHeader;
    private TextView textView;
    private String fCurrentFile = "";
    private Boolean fFormLoading = true;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        try {
            super.onCreate(savedInstanceState);
            setContentView(R.layout.activity_rfid_view);

            Button btnBack = findViewById(R.id.btnBack);
            Button btn_chooseFile = findViewById(R.id.btn_chooseFile);
            textViewHeader = findViewById(R.id.textViewHeader);
            textView = findViewById(R.id.textView);

            btnBack.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    onBackPressed();
                }
            });
            btn_chooseFile.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    ViewScannedFile();
                }
            });

            fCurrentFile = getIntent().getStringExtra("IntentObject");
            LoadData(fCurrentFile);
            fFormLoading = false;
        } catch (Exception ex) {
            onBackPressed();
        }
    }

    @Override
    public boolean dispatchTouchEvent(MotionEvent ev) {
        return super.dispatchTouchEvent(ev);
    }

    private void ViewScannedFile(){
        Intent in = new Intent(RFIDViewActivity.this, FileManagerActivity.class);
        in.putExtra("IntentObject", fCurrentFile);
        startActivityForResult(in, REQUESTCODE_CHOOSE_FILE);
    }

    public void LoadData(String filePath) {
        if (filePath != null && !filePath.equals("")) {
            textViewHeader.setText(FilenameUtils.getName(filePath));
            List<String> lst = FileImport.LoadFileScan(fCurrentFile);
            textView.setText(String.join("\n", lst));
        }
        else{
            if (fFormLoading){
                ViewScannedFile();
            }
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        // TODO Auto-generated method stub
        switch (requestCode) {
            case REQUESTCODE_CHOOSE_FILE:
                if(resultCode == Activity.RESULT_OK) {
                    fCurrentFile = data.getStringExtra(FileManagerActivity.EXTRA_FILE_PATH);
                    LoadData(fCurrentFile);
                }
                break;

            default:
                break;
        }
    }
}
