package com.rfid.app;

import java.util.Date;

public class ImportData {
    String GrnId;
    int TotalExpectedQuantity;
    int TotalActualQuantity;
    String EmpId;
    String Note;
    int IsEnable;
    String CreatedTime;

    public ImportData() {
        GrnId = "";
        TotalExpectedQuantity = 0;
        TotalActualQuantity = -1;
        EmpId = "";
        Note = "";
        IsEnable = 1;
        CreatedTime = "";
    }


    public ImportData(String grnId, int totalExpectedQuantity, int totalActualQuantity, String empId, String note, int isEnable, String createdTime) {
        GrnId = grnId;
        TotalExpectedQuantity = totalExpectedQuantity;
        TotalActualQuantity = totalActualQuantity;
        EmpId = empId;
        Note = note;
        IsEnable = isEnable;
        CreatedTime = createdTime;
    }

    public String getGrnId() {
        return GrnId;
    }

    public void setGrnId(String grnId) {
        GrnId = grnId;
    }

    public int getTotalExpectedQuantity() {
        return TotalExpectedQuantity;
    }

    public void setTotalExpectedQuantity(int totalExpectedQuantity) {
        TotalExpectedQuantity = totalExpectedQuantity;
    }

    public int getTotalActualQuantity() {
        return TotalActualQuantity;
    }

    public void setTotalActualQuantity(int totalActualQuantity) {
        TotalActualQuantity = totalActualQuantity;
    }

    public String getEmpId() {
        return EmpId;
    }

    public void setEmpId(String empId) {
        EmpId = empId;
    }

    public String getNote() {
        return Note;
    }

    public void setNote(String note) {
        Note = note;
    }

    public int getIsEnable() {
        return IsEnable;
    }

    public void setIsEnable(int isEnable) {
        IsEnable = isEnable;
    }

    public String getCreatedTime() {
        return CreatedTime;
    }

    public void setCreatedTime(String createdTime) {
        CreatedTime = createdTime;
    }
}
