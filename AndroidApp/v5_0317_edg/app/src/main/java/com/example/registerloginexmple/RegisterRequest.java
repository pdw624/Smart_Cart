package com.example.registerloginexmple;

import android.inputmethodservice.Keyboard;

import com.android.volley.AuthFailureError;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

//회원가입 요청을 보내는 클래스
public class RegisterRequest extends StringRequest {
    //서버 URL설정(php 파일연동)
    final static private String URL="http://172.20.10.3/Register.php";
    //final static private String URL="http://192.168.43.183/Register.php";
    private Map<String, String> map;

    public RegisterRequest(String userID, String userPassword, String userName,
                           String userMail, String userPhone, Response.Listener<String> listener){
        super(Method.POST, URL, listener, null);

        map = new HashMap<>();
        map.put("userID", userID);
        map.put("userPassword",userPassword);
        map.put("userName",userName);
        map.put("userMail", userMail);
        map.put("userPhone", userPhone);

    }

    @Override
    protected Map<String, String> getParams() throws AuthFailureError {
        return map;
    }
}
