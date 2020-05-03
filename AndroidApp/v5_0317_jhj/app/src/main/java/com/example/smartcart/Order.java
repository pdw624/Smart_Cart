package com.example.smartcart;

public class Order{
    String product;
    String price;
    String buyday;

    public Order(String product, String price, String buyday) {
        this.product = product;
        this.price = price;
        this.buyday = buyday;
    }

    public String getProduct() {
        return product;
    }

    public void setProduct(String product) {
        this.product = product;
    }

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


}
