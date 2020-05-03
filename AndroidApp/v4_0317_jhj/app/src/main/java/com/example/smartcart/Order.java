package com.example.smartcart;

public class Order{

    String price;
    String buyday;

    public String getPrice() {
        return price;
    }

    public void setPrice(String price) {
        this.price = price;
    }

    public String getBuyday() {
        return buyday;
    }

    public void setBuyday(String buyday) {
        this.buyday = buyday;
    }

    public Order(String price, String buyday) {
        this.price = price;
        this.buyday = buyday;
    }
}
