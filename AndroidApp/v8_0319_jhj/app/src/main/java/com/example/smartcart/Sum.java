package com.example.smartcart;

public class Sum {
    String product;
    String price;
    String buydate;

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

    public String getBuydate() {
        return buydate;
    }

    public void setBuydate(String buydate) {
        this.buydate = buydate;
    }

    public Sum(String product, String price, String buydate) {
        this.product = product;
        this.price = price;
        this.buydate = buydate;
    }
}
