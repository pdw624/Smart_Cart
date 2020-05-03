package com.example.registerloginexmple;

//하나의 정보를 담을 클래스
public class User {
    String userID;
    String userPassword;
    String userName;
    String userAge;

    public String getUserID() {
        return userID;
    }

    public void setUserID(String userID) {
        this.userID = userID;
    }

    public String getUserPassword() {
        return userPassword;
    }

    public void setUserPassword(String userPassword) {
        this.userPassword = userPassword;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getUserAge() {
        return userAge;
    }

    public void setUserAge(String userAge) {
        this.userAge = userAge;
    }

    //생성자
    public User(String userID, String userPassword, String userName, String userAge) {
        this.userID = userID;
        this.userPassword = getUserPassword();
        this.userName = userName;
        this.userAge = userAge;
    }
}
