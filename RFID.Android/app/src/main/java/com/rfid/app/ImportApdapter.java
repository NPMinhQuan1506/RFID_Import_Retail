package com.rfid.app;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;

public class ImportApdapter extends ArrayAdapter<ImportData> implements View.OnClickListener{

    private ArrayList<ImportData> dataSet;
    Context mContext;

    // View lookup cache
    private static class ViewHolder {
        TextView txtImportId;
        TextView txtStatus;
        TextView txtCreatedDate;
        TextView txtTotalImport;
        Button btnCheck;
    }

    public ImportApdapter(ArrayList<ImportData> data, Context context) {
        super(context, R.layout.importlist_items, data);
        this.dataSet = data;
        this.mContext=context;

    }

    @Override
    public void onClick(View v) {

        int position=(Integer) v.getTag();
        Object object= getItem(position);
        ImportData dataModel=(ImportData)object;

        switch (v.getId())
        {
            case R.id.btCheck:

                break;
//            case R.id.item_info:
//                Snackbar.make(v, "Release date " +dataModel.getFeature(), Snackbar.LENGTH_LONG)
//                        .setAction("No action", null).show();
//                break;
        }
    }

    private int lastPosition = -1;

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        // Get the data item for this position
        ImportData dataModel = getItem(position);
        // Check if an existing view is being reused, otherwise inflate the view
        ViewHolder viewHolder; // view lookup cache stored in tag

        final View result;

        if (convertView == null) {

            viewHolder = new ViewHolder();
            LayoutInflater inflater = LayoutInflater.from(getContext());
            convertView = inflater.inflate(R.layout.importlist_items, parent, false);
            viewHolder.txtImportId = (TextView) convertView.findViewById(R.id.import_id);
            viewHolder.txtStatus = (TextView) convertView.findViewById(R.id.status);
            viewHolder.txtCreatedDate = (TextView) convertView.findViewById(R.id.create_date);
            viewHolder.txtTotalImport = (TextView) convertView.findViewById(R.id.total_import);
            viewHolder.btnCheck = (Button) convertView.findViewById(R.id.btCheck);

            result=convertView;

            convertView.setTag(viewHolder);
        } else {
            viewHolder = (ViewHolder) convertView.getTag();
            result=convertView;
        }

//        Animation animation = AnimationUtils.loadAnimation(mContext, (position > lastPosition) ? R.anim.up_from_bottom : R.anim.down_from_top);
//        result.startAnimation(animation);
//        lastPosition = position;

        viewHolder.txtImportId.setText(dataModel.getImportId());
//        viewHolder.txtStatus.setText(dataModel.getStatus());
        viewHolder.txtCreatedDate.setText(dataModel.getCreatedDate());
        viewHolder.txtTotalImport.setText(String.valueOf(dataModel.getTotalImport()));
        viewHolder.btnCheck.setOnClickListener(this);
        // Return the completed view to render on screen
        return convertView;
    }
    public void clearData() {
        // clear the data
        dataSet.clear();
    }
}
