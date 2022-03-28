package com.rfid.app;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.io.Serializable;
import java.util.Date;

public class RFID implements Serializable
{
    @SerializedName("stt")
    @Expose
    public int Stt;

    @SerializedName("id")
    @Expose
    public int Id;

    @SerializedName("itemCode")
    @Expose
    public String ItemCode;

    @SerializedName("itemName")
    @Expose
    public String ItemName;

    @SerializedName("ePC")
    @Expose
    public String EPC;

    @SerializedName("rSSI")
    @Expose
    public String RSSI;

    @SerializedName("count")
    @Expose
    public Integer Count;

    @SerializedName("created")
    @Expose
    public String Created;

    public Date CreatedVal() {return UIHelper.getDateValue(this.Created);}
}
