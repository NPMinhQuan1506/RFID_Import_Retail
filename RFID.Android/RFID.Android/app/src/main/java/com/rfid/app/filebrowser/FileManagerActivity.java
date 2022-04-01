package com.rfid.app.filebrowser;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ListActivity;
import android.content.DialogInterface;
import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ListView;
import android.widget.Toast;

import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import com.rfid.app.R;

import org.apache.commons.io.FilenameUtils;

public class FileManagerActivity extends ListActivity {

	public static String FILE_PATH_ACTION = "com.handset.download.filepath";
	
	public static final String EXTRA_FILE_PATH = "filePath";

    private List<IconifiedText> directoryEntries = new ArrayList<IconifiedText>();
    private File currentDirectory = new File("/");
    private String fCurrentFile = "";
    /**
     * Called when the activity is first created.
     */
    @Override
    public void onCreate(Bundle icicle) {
        super.onCreate(icicle);

        fCurrentFile = getIntent().getStringExtra("IntentObject");
        browseToDownDirectory(fCurrentFile);

        this.setSelection(0);
    }

    private void browseToDownDirectory(String fileName) {
        String filePath = "";
        if (fileName.isEmpty())
            filePath = Environment.getExternalStorageDirectory() + "/RfidData/";
        else{
            filePath = FilenameUtils.getPath(fileName);
        }
        File file = new File(filePath);
        if (file.mkdirs()) {
        }

        if(file==null)
        {
            return;
        }

        browseTo(file);
    }

    private void browseToRoot() {
        browseTo(new File("/"));
    }

    private void upOneLevel() {
        if (this.currentDirectory.getParent() != null)
            this.browseTo(this.currentDirectory.getParentFile());
    }

    private void browseTo(final File file) {
        this.setTitle(file.getAbsolutePath());
        if (file.isDirectory()) {
            this.currentDirectory = file;
            fill(file.listFiles());
        } else {
            //fileOptMenu(file); // DO NOT SHOW QUESTION
            fileSelected(file);
        }
    }

    private void fileSelected(final File file){
        Intent intent = new Intent();
        intent.putExtra(EXTRA_FILE_PATH, file.getAbsolutePath());
        setResult(Activity.RESULT_OK, intent);
        finish();
    }

    private void fill(File[] files) {
        if (files == null) {
            Toast.makeText(FileManagerActivity.this,
                    getString(R.string.msg_strPermissionDeny), Toast.LENGTH_SHORT).show();
            this.browseTo(this.currentDirectory.getParentFile());
            return;
        }

        this.directoryEntries.clear();

        this.directoryEntries.add(new IconifiedText(
                getString(R.string.current_dir), getResources().getDrawable(
                R.drawable.folder)));

        if (this.currentDirectory.getParent() != null)
            this.directoryEntries.add(new IconifiedText(
                    getString(R.string.up_one_level), getResources()
                    .getDrawable(R.drawable.uponelevel)));

        Drawable currentIcon = null;
        for (File currentFile : files) {

            int currentPathStringLenght = this.currentDirectory
                    .getAbsolutePath().length();

            if (currentFile.isDirectory()) {
                currentIcon = getResources().getDrawable(R.drawable.folder);
            } else {
                String fileName = currentFile.getName();
                if (checkEndsWithInStringArray(fileName, getResources()
                        .getStringArray(R.array.fileEndingImage))) {
                    currentIcon = getResources().getDrawable(R.drawable.image);
                } else if (checkEndsWithInStringArray(fileName, getResources()
                        .getStringArray(R.array.fileEndingWebText))) {
                    currentIcon = getResources()
                            .getDrawable(R.drawable.webtext);
                } else if (checkEndsWithInStringArray(fileName, getResources()
                        .getStringArray(R.array.fileEndingPackage))) {
                    currentIcon = getResources().getDrawable(R.drawable.packed);
                } else if (checkEndsWithInStringArray(fileName, getResources()
                        .getStringArray(R.array.fileEndingAudio))) {
                    currentIcon = getResources().getDrawable(R.drawable.audio);
                } else if (checkEndsWithInStringArray(fileName, getResources()
                        .getStringArray(R.array.fileEndingVideo))) {
                    currentIcon = getResources().getDrawable(R.drawable.video);
                } else {
                    currentIcon = getResources().getDrawable(R.drawable.text);
                }

                currentPathStringLenght += 1;
            }

            Log.i("FileManagerActivity","AbsolutePath=" + currentFile.getAbsolutePath());

            this.directoryEntries.add(new IconifiedText(currentFile
                    .getAbsolutePath().substring(currentPathStringLenght),
                    currentIcon));
        }
        Collections.sort(this.directoryEntries);
        IconifiedTextListAdapter itla = new IconifiedTextListAdapter(this);
        itla.setListItems(this.directoryEntries);
        this.setListAdapter(itla);
    }

    protected void onListItemClick(ListView l, View v, int position, long id) {
        super.onListItemClick(l, v, position, id);
        String selectedFileString = this.directoryEntries.get(position).getText();

        if (selectedFileString.equals(getString(R.string.current_dir))) {
            this.browseTo(this.currentDirectory);
        } else if (selectedFileString.equals(getString(R.string.up_one_level))) {
            this.upOneLevel();
        } else {
            File clickedFile = null;
            clickedFile = new File(this.currentDirectory.getAbsolutePath()
                    + "/" + this.directoryEntries.get(position).getText());
            if (clickedFile != null) {
                this.browseTo(clickedFile);
            }
        }
    }

    private boolean checkEndsWithInStringArray(String checkItsEnd,
                                               String[] fileEndings) {
        for (String aEnd : fileEndings) {
            if (checkItsEnd.endsWith(aEnd))
                return true;
        }
        return false;
    }

    public boolean onCreateOptionsMenu(Menu menu) {
        super.onCreateOptionsMenu(menu);
        menu.add(0, 3, 0, "root").setIcon(R.drawable.goroot);
        menu.add(0, 4, 0, "up").setIcon(R.drawable.uponelevel);
        return true;
    }

    public boolean onOptionsItemSelected(MenuItem item) {
        super.onOptionsItemSelected(item);
        switch (item.getItemId()) {
            case 3:
                this.browseToRoot();
                break;
            case 4:
                this.upOneLevel();
                break;
        }
        return false;
    }

    @Override
    public boolean onPrepareOptionsMenu(Menu menu) {
        return super.onPrepareOptionsMenu(menu);
    }

    public void fileOptMenu(final File file) {
        new AlertDialog.Builder(FileManagerActivity.this)
                .setTitle(R.string.file_title_sel_file)
                .setMessage(R.string.file_title_sel_file_confirm)
                .setPositiveButton(R.string.file_btn_confirm,
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                // TODO Auto-generated method stub
                                fileSelected(file);
                            }
                        })
                .setNegativeButton(R.string.file_btn_cancel,
                        new DialogInterface.OnClickListener() {
                            @Override
                            public void onClick(DialogInterface dialog, int which) {
                                Toast.makeText(FileManagerActivity.this, R.string.file_msg_cancel, Toast.LENGTH_SHORT).show();
                            }
                        }).show();
    }

    public String GetCurDirectory() {
        return this.currentDirectory.getAbsolutePath();
    }

    public void moveFile(String source, String destination) {
        new File(source).renameTo(new File(destination));
    }
}
