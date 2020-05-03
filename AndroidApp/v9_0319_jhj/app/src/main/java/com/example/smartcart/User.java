package com.example.smartcart;

public class User {
    String userID;
    String userPassword;
    String userName;
    String userMail;
    String userPhone;


    public String getUserID() {
        return userID;
    }

    public void setUserID(String userID) {
        this.userID = userID;
    }


    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }


    public String getUserPhone() {
        return userPhone;
    }

    public void setUserPhone(String userPhone) {
        this.userPhone = userPhone;
    }

    public User(String userID, String userName,  String userPhone) {
        this.userID = userID;
        this.userName = userName;
        this.userPhone = userPhone;
    }
}
