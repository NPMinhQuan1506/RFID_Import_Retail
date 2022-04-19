package com.rfid.app.Model;

public class SP {
    String name;
    int price;
    String unit;
    int min_stock_quantity;
    int stock_quantity;
    String type;
    String description;
    int is_enable;
    String product_line_id;
    String created_date;
    String modified_date;

    public SP(){

    }

    public SP(String name, int price, String unit, int min_stock_quantity, int stock_quantity, String type, String description, int is_enable, String product_line_id, String created_date, String modified_date) {
        this.name = name;
        this.price = price;
        this.unit = unit;
        this.min_stock_quantity = min_stock_quantity;
        this.stock_quantity = stock_quantity;
        this.type = type;
        this.description = description;
        this.is_enable = is_enable;
        this.product_line_id = product_line_id;
        this.created_date = created_date;
        this.modified_date = modified_date;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public String getUnit() {
        return unit;
    }

    public void setUnit(String unit) {
        this.unit = unit;
    }

    public int getMin_stock_quantity() {
        return min_stock_quantity;
    }

    public void setMin_stock_quantity(int min_stock_quantity) {
        this.min_stock_quantity = min_stock_quantity;
    }

    public int getStock_quantity() {
        return stock_quantity;
    }

    public void setStock_quantity(int stock_quantity) {
        this.stock_quantity = stock_quantity;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public int getIs_enable() {
        return is_enable;
    }

    public void setIs_enable(int is_enable) {
        this.is_enable = is_enable;
    }

    public String getProduct_line_id() {
        return product_line_id;
    }

    public void setProduct_line_id(String product_line_id) {
        this.product_line_id = product_line_id;
    }

    public String getCreated_date() {
        return created_date;
    }

    public void setCreated_date(String created_date) {
        this.created_date = created_date;
    }

    public String getModified_date() {
        return modified_date;
    }

    public void setModified_date(String modified_date) {
        this.modified_date = modified_date;
    }
}
