package com.rfid.app.Model;

public class RFIDProduct {
    int is_check;
    String mapping_time;
    String product_line_id;
    String rfid;

    public RFIDProduct(){

    }

    public RFIDProduct(int is_check, String mapping_time, String product_line_id, String rfid) {
        this.is_check = is_check;
        this.mapping_time = mapping_time;
        this.product_line_id = product_line_id;
        this.rfid = rfid;
    }

    public int getIs_check() {
        return is_check;
    }

    public void setIs_check(int is_check) {
        this.is_check = is_check;
    }

    public String getMapping_time() {
        return mapping_time;
    }

    public void setMapping_time(String mapping_time) {
        this.mapping_time = mapping_time;
    }

    public String getProduct_line_id() {
        return product_line_id;
    }

    public void setProduct_line_id(String product_line_id) {
        this.product_line_id = product_line_id;
    }

    public String getRfid() {
        return rfid;
    }

    public void setRfid(String rfid) {
        this.rfid = rfid;
    }
}
