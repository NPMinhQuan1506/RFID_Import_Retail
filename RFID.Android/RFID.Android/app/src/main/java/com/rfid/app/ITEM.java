package com.rfid.app;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class ITEM implements Serializable
{
    @SerializedName("id")
    @Expose
    public Integer Id;

    @SerializedName("itemCode")
    @Expose
    public String ItemCode;

    @SerializedName("itemName")
    @Expose
    public String ItemName;
}
