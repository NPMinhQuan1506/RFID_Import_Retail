package com.rfid.app.filebrowser;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

public class IconifiedTextView extends LinearLayout {
    private TextView mText = null;
    private ImageView mIcon = null;

    public IconifiedTextView(Context context, IconifiedText aIconifiedText) {
        super(context);
    	setPadding(10, 10, 10, 10);
        this.setOrientation(HORIZONTAL);
        mIcon = new ImageView(context);
        mIcon.setImageDrawable(aIconifiedText.getIcon());
        mIcon.setPadding(10, 10, 10, 10);
        addView(mIcon, new LayoutParams(LayoutParams.WRAP_CONTENT,
                LayoutParams.WRAP_CONTENT));
        mText = new TextView(context);
        mText.setText(aIconifiedText.getText());
//        mText.setPadding(10, 12, 10, 12);
        mText.setTextSize(22);
        mText.setWidth(LayoutParams.WRAP_CONTENT);
        mText.setHeight(LayoutParams.WRAP_CONTENT);
        addView(mText, new LayoutParams(LayoutParams.MATCH_PARENT,
                LayoutParams.MATCH_PARENT));
    }

    public void setText(String words) {
        mText.setText(words);
    }

    public void setIcon(Drawable bullet) {
        mIcon.setImageDrawable(bullet);
    }
}
