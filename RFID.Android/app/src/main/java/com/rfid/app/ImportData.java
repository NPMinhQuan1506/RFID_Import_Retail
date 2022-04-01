package com.rfid.app;

import java.util.Date;

public class ImportData {
    int IsEnable;
    String Note;
    int TotalImport;
    int TotalPrice;

    String CreatedDate;
    String EmpId;
    String ModifiedDate;
    int ActualNumber;
    String ImportId;


    public ImportData() {
    }

    public ImportData(int isEnable, String note, int totalImport, int totalPrice, String createdDate, String empId, String modifiedDate, int actualNumber, String importId) {
        IsEnable = isEnable;
        Note = note;
        TotalImport = totalImport;
        TotalPrice = totalPrice;
        CreatedDate = createdDate;
        EmpId = empId;
        ModifiedDate = modifiedDate;
        ActualNumber = actualNumber;
        ImportId = importId;
    }

    public int getIsEnable() {
        return IsEnable;
    }

    public void setIsEnable(int isEnable) {
        IsEnable = isEnable;
    }

    public String getNote() {
        return Note;
    }

    public void setNote(String note) {
        Note = note;
    }

    public int getTotalImport() {
        return TotalImport;
    }

    public void setTotalImport(int totalImport) {
        TotalImport = totalImport;
    }

    public int getTotalPrice() {
        return TotalPrice;
    }

    public void setTotalPrice(int totalPrice) {
        TotalPrice = totalPrice;
    }

    public String getCreatedDate() {
        return CreatedDate;
    }

    public void setCreatedDate(String createdDate) {
        CreatedDate = createdDate;
    }

    public String getEmpId() {
        return EmpId;
    }

    public void setEmpId(String empId) {
        EmpId = empId;
    }

    public String getModifiedDate() {
        return ModifiedDate;
    }

    public void setModifiedDate(String modifiedDate) {
        ModifiedDate = modifiedDate;
    }

    public int getActualNumber() {
        return ActualNumber;
    }

    public void setActualNumber(int actualNumber) {
        ActualNumber = actualNumber;
    }

    public String getImportId() {
        return ImportId;
    }

    public void setImportId(String importId) {
        ImportId = importId;
    }
}
