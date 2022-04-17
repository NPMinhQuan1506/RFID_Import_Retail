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
    public static List<String> LoadFileScan(String fileName){
        List<String> list = new ArrayList<>();
        if (fileName.endsWith("xls") || fileName.endsWith("xlsx")){
            list = LoadFileXls(fileName);
        }
        else{
            list = LoadFileText(fileName);
        }
        return list;
    }

    public static List<String> LoadFileXls(String fileName){
        List<String> list = new ArrayList<>();
        try {
            ArrayList<HashMap<String, Object>> arrayLists = FileXls.readXLSmap(fileName);
            for (HashMap<String, Object> item: arrayLists) {
                list.add(Objects.requireNonNull(item.get("tagUii")).toString()); // xls only store field tagUii
            }
        } catch (Exception e) {
            e.printStackTrace();
            throw e;
        }
        return list;
    }

    public static List<String> LoadFileText(String fileName){
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
    public static boolean SaveFileTxt(ArrayList<HashMap<String, String>> lists2, String fileName) throws Exception{
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
                    } else {}
                }
            }

            Files.write(Paths.get(FilePathTxt), lst);
            return true;
        } catch (Exception ex) {
            throw ex;
        }
    }

    // save rfids to SQL
    public boolean SaveSQL(ArrayList<HashMap<String, String>> lists2, Context cont, int deliveryOrderId) throws Exception{
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
                        String[] myTaskParams = { String.valueOf(deliveryOrderId), item.EPC };
                        ConnectMySQL connectMySql = new ConnectMySQL();
                        connectMySql.execute(myTaskParams);
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

    private class ConnectMySQL extends AsyncTask<String, String, String>{
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
        }

        @Override
        protected String doInBackground(String... params) {
            int random = (int)(Math.random() * 5 + 1);
//            String query = "Update deliveryorderdetail set is_checked = 1 " +
//                            "Where delivery_order_id = '"+params[0]+"' and product_instance_id = '"+params[1]+"'";
            String query1 = "Insert into productinstance (`product_instance_id`, `product_line_id`, `is_purcharsed`) " +
                            "values('"+params[1]+"', 'SP00"+random+"', 0)";
            conn.executeDatabase(query1);
            return null;
        }

        @Override
        protected void onPostExecute(String s) {
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
