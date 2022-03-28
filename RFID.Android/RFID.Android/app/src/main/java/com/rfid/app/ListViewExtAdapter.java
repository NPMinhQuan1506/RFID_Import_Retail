package com.rfid.app;

import android.app.Activity;
import android.text.Html;
import android.text.Spanned;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

/* Created by TUAN on 2018/09/11 */

public class ListViewExtAdapter<T> extends BaseAdapter {
    protected List<T> list;
    protected String[] fieldNames = {"", "", "", "", ""};   // field name in object data
    protected int iColumnShow = 5;                          // number of columns show in grid
    protected int fResource = 0;

    protected Activity activity;

    private int getResource() {
        if (fResource == 0)
            return R.layout.listview_columns;
        else
            return fResource;
    }

    public void setResource(int resource) {
        fResource = resource;
    }

    public void setFieldNames(String[] fieldArray, int columnShow) {
        fieldNames = fieldArray;
        iColumnShow = (columnShow == 0 ? fieldNames.length : columnShow);
    }

    public ListViewExtAdapter(Activity activity) {
        super();
        this.activity = activity;
        this.list = new ArrayList<T>();
        this.notifyDataSetChanged();
    }

    public void ResetAdapter() {
        this.list = new ArrayList<T>();
        this.notifyDataSetChanged();
    }

    public void addDataSource(List<T> lst) {
        if (lst == null) {
            ResetAdapter();
            return;
        }

        this.list = lst;
        // refresh grid
        this.notifyDataSetChanged();
    }

    private String getValue(T t, int index)
    {
        try {
            Object o = t.getClass().getField(fieldNames[index]).get(t);
            return o != null ? o.toString() : "";
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        return  "";
    }

    private Spanned getValueHtml(T t, int index) {
        try {
            return Html.fromHtml(getValue(t, index)); // used by TextView
        } catch (Exception e) {
            return null;
        }
    }

    public void addItem(T value) {
        addItem(value, true);
    }

    private void addItem(T item, boolean onTop) {
        if (onTop)
            this.list.add(0, item);
        else
            this.list.add(item);
        // refresh grid
        this.notifyDataSetChanged();
    }

    public List<T> getList() {
        return list;
    }

    @Override
    public int getCount() {
        return list.size();
    }

    @Override
    public Object getItem(int position) {
        return list.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    private class ViewHolder {
        TextView txtFirst;
        TextView txtSecond;
        TextView txtThird;
        /*
        TextView txtFourth;
        TextView txtFifth;
        */
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // TODO Auto-generated method stub
        ViewHolder holder;

        LayoutInflater inflater = activity.getLayoutInflater();
        if (convertView == null) {
            convertView = inflater.inflate(getResource(), null, true);
            holder = new ViewHolder();

            if (iColumnShow > 0)
                holder.txtFirst = convertView.findViewById(R.id.TextFirst);
            if (iColumnShow > 1)
                holder.txtSecond = convertView.findViewById(R.id.TextSecond);
            if (iColumnShow > 2)
                holder.txtThird = convertView.findViewById(R.id.TextThird);
            /*
            if (iColumnShow > 3)
                holder.txtFourth = (TextView) convertView.findViewById(R.id.TextFourth);
            if (iColumnShow > 4)
                holder.txtFifth = (TextView) convertView.findViewById(R.id.TextFifth);
            */
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }

        T item = list.get(position);
        // 2019-08-07 show html format
        if (iColumnShow > 0) holder.txtFirst.setText(getValueHtml(item, 0));
        if (iColumnShow > 1) holder.txtSecond.setText(getValueHtml(item, 1));
        if (iColumnShow > 2) holder.txtThird.setText(getValueHtml(item, 2));
        /*
        if (iColumnShow > 3) holder.txtFourth.setText(item.getColVal(3));
        if (iColumnShow > 4) holder.txtFifth.setText(item.getColVal(4));
        */
        return convertView;
    }

}

