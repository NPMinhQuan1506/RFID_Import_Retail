package com.rfid.app;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;

import java.util.ArrayList;

public class MappingAdapter extends ArrayAdapter<ProductData> implements View.OnClickListener {

    private ArrayList<ProductData> dataSet;
    Context mContext;

    @Override
    public void onClick(View v) {

    }

    // View lookup cache
    private static class ViewHolder {
        TextView txtProductId;
        TextView txtName;
        TextView txtType;
        TextView txtPrice;
        Button btnMap;
    }

    public MappingAdapter(ArrayList<ProductData> data, Context context) {
        super(context, R.layout.importlist_items, data);
        this.dataSet = data;
        this.mContext = context;

    }

    private int lastPosition = -1;

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // Get the data item for this position
        ProductData dataModel = getItem(position);
        // Check if an existing view is being reused, otherwise inflate the view
        ViewHolder viewHolder; // view lookup cache stored in tag

        final View result;

        if (convertView == null) {

            viewHolder = new ViewHolder();
            LayoutInflater inflater = LayoutInflater.from(getContext());
            convertView = inflater.inflate(R.layout.mappinglist_items, parent, false);
            viewHolder.txtProductId = (TextView) convertView.findViewById(R.id.product_id);
            viewHolder.txtName = (TextView) convertView.findViewById(R.id.product_name);
            viewHolder.txtType = (TextView) convertView.findViewById(R.id.type);
            viewHolder.txtPrice = (TextView) convertView.findViewById(R.id.price);
            viewHolder.btnMap = (Button) convertView.findViewById(R.id.btMap);

            result = convertView;

            convertView.setTag(viewHolder);
        } else {
            viewHolder = (ViewHolder) convertView.getTag();
            result = convertView;
        }

//        Animation animation = AnimationUtils.loadAnimation(mContext, (position > lastPosition) ? R.anim.up_from_bottom : R.anim.down_from_top);
//        result.startAnimation(animation);
//        lastPosition = position;

        viewHolder.txtProductId.setText(dataModel.getId());
        viewHolder.txtName.setText(dataModel.getName());
        viewHolder.txtType.setText(dataModel.getType());
        viewHolder.txtPrice.setText(String.valueOf(dataModel.getPrice()));
        viewHolder.btnMap.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ProductData dataModel = (ProductData) getItem(position);
                switch (v.getId()) {
                    case R.id.btMap:
                        Bundle bundle = new Bundle();
                        bundle.putString("product_id", dataModel.getId());
                        bundle.putBoolean("is_mapping", true);
                        Intent intent = new Intent(mContext, RFIDScanActivity.class);
                        intent.putExtras(bundle);
                        mContext.startActivity(intent);
                        break;
                }
            }
        });
        // Return the completed view to render on screen
        return convertView;
    }

    public void clearData() {
        // clear the data
        dataSet.clear();
    }
}
