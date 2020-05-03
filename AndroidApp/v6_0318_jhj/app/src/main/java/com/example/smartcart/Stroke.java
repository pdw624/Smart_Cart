package com.example.smartcart;

public class Stroke {
    String strokeName;
    String strokePrice;
    String strokeQuantity;

    public String getStrokeName() {
        return strokeName;
    }

    public void setStrokeName(String strokeName) {
        this.strokeName = strokeName;
    }

    public String getStrokePrice() {
        return strokePrice;
    }

    public void setStrokePrice(String strokePrice) {
        this.strokePrice = strokePrice;
    }

    public String getStrokeQuantity() {
        return strokeQuantity;
    }

    public void setStrokeQuantity(String strokeQuantity) {
        this.strokeQuantity = strokeQuantity;
    }

    public Stroke(String strokeName, String strokePrice, String strokeQuantity) {
        this.strokeName = strokeName;
        this.strokePrice = strokePrice;
        this.strokeQuantity = strokeQuantity;
    }
}
