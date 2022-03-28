package com.rfid.app.filebrowser;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;

import java.util.ArrayList;
import java.util.List;

public class IconifiedTextListAdapter extends BaseAdapter {
    private Context mContext = null;
    private List<IconifiedText> mItems = new ArrayList<IconifiedText>();

    public IconifiedTextListAdapter(Context context) {
        mContext = context;
    }

    public void addItem(IconifiedText it) {
        mItems.add(it);
    }

    public void setListItems(List<IconifiedText> lit) {
        mItems = lit;
    }

    public int getCount() {
        return mItems.size();
    }

    public Object getItem(int position) {
        return mItems.get(position);
    }

    public boolean areAllItemsSelectable() {
        return false;
    }

    public boolean isSelectable(int position) {
        return mItems.get(position).isSelectable();
    }

    public long getItemId(int position) {
        return position;
    }

    public View getView(int position, View convertView, ViewGroup parent) {
        IconifiedTextView btv;
        if (convertView == null) {
            btv = new IconifiedTextView(mContext, mItems.get(position));
        } else {
            btv = (IconifiedTextView) convertView;
            btv.setText(mItems.get(position).getText());
            btv.setIcon(mItems.get(position).getIcon());
        }
        return btv;
    }
}
