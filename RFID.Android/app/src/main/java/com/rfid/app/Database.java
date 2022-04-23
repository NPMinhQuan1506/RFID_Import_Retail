package com.rfid.app;

import android.annotation.SuppressLint;
import android.os.StrictMode;
import android.util.Log;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

public class Database {
    String classs = "com.mysql.jdbc.Driver";
    private static final String url = "jdbc:mysql://192.168.26.94/rfid?allowMultiQueries=true";
    private static final String user = "urfid";
    private static final String pass = "123456";
    Connection con;
    public Database(){
        con = CONN();
    }
    @SuppressLint("NewApi")
    private Connection CONN(){
        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder()
                .permitAll().build();
        StrictMode.setThreadPolicy(policy);
        Connection conn = null;
        String connURL = null;

        try {
            Class.forName(classs);
            conn = DriverManager.getConnection(url, user, pass);
            System.out.println("Database connection success");
            //conn = DriverManager.getConnection(connURL);

        } catch (SQLException se){
            Log.e("ERR", se.getMessage());
        }
        catch (ClassNotFoundException e){
            Log.e("ERR", e.getMessage());
        }
        catch (Exception e){
            Log.e("ERR", e.getMessage());
        }
        return conn;
    }

    public boolean executeDatabase(String s)
    {
        boolean isSuccess = false;
        try {
            Statement stmt = con.createStatement();
            stmt.executeUpdate(s);
            isSuccess = true;
        }
        catch (Exception e){
            Log.e("ERR", e.getMessage());
        }
        return isSuccess;
    }

    public ResultSet loadData(String s){
        ResultSet results = null;
        try {
            Statement stmt = con.createStatement();
            results = stmt.executeQuery(s);

            ResultSetMetaData rsmd = results.getMetaData();

            return results;
        }
        catch (Exception e){
            Log.e("ERR", e.getMessage());
        }
        return results;
    }
}
