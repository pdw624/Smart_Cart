package com.example.smartcart;

import com.android.volley.AuthFailureError;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

public class UserInfoRequest extends StringRequest {

    final static private String URL = "http://192.168.0.23/UserInfoList.php";

    private Map<String, String>map;


    //생성자
    public UserInfoRequest(String userID, Response.Listener<String> listener){

        super(Method.POST, URL, listener, null);

        map = new HashMap<>();
        map.put("userID", userID);
    }

    @Override
    protected Map<String,String> getParams() throws AuthFailureError{
        return map;
    }

}
