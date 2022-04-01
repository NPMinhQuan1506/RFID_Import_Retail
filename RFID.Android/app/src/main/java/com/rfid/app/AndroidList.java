package com.rfid.app;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class AndroidList implements Serializable
{
    @SerializedName("stt")
    @Expose
    public Integer Stt;

    @SerializedName("valueText")
    @Expose
    public String ValueText;

    @SerializedName("valueKey")
    @Expose
    public String ValueKey;
}
