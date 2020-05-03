package com.example.smartcart;

import android.util.Log;

import com.android.volley.AuthFailureError;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

public class FindRequest2 extends StringRequest {

    final static private String URL = "http://192.168.0.23/FindValidatePassword.php";
    private Map<String, String>map;

    public FindRequest2(String userID, String userName, String userMail, Response.Listener<String> listener){
        super(Method.POST, URL, listener, null);

        map = new HashMap<>();
        map.put("userID", userID);
        map.put("userName", userName);
        map.put("userMail", userMail);
        Log.d("Response", "Request2 -> useID: " + userID);
        Log.d("Response", "Request2 -> useName: " + userName);
        Log.d("Response", "Request2 -> userMail: " + userMail);

    }

    // 만약 POST 방식에서 전달할 요청 파라미터가 있다면 HashMap 객체에 넣어준다.
    @Override
    protected Map<String, String> getParams() throws AuthFailureError {
        return map;
    }

}
