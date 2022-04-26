package com.rfid.app;

import java.math.BigDecimal;

public class ProductData {
    String Id;
    String Name;
    String Type;
    int price;

    public ProductData() {
        Id = "";
        Name = "";
        Type = "";
        this.price = 0;
    }

    public ProductData(String id, String name, String type, int price) {
        Id = id;
        Name = name;
        Type = type;
        this.price = price;
    }

    public String getId() {
        return Id;
    }

    public void setId(String id) {
        Id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getType() {
        return Type;
    }

    public void setType(String type) {
        Type = type;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }
}
