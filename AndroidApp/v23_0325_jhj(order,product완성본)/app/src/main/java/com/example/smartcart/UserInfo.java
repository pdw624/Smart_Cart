package com.example.smartcart;

public class UserInfo {
    static String id="";

    String userName;
    String userMail;
    String userPhone;

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getUserMail() {
        return userMail;
    }

    public void setUserMail(String userMail) {
        this.userMail = userMail;
    }

    public String getUserPhone() {
        return userPhone;
    }

    public void setUserPhone(String userPhone) {
        this.userPhone = userPhone;
    }

    public UserInfo(String userName, String userMail, String userPhone) {
        this.userName = userName;
        this.userMail = userMail;
        this.userPhone = userPhone;
    }
}
