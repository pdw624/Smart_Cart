package com.example.smartcart;


import com.android.volley.AuthFailureError;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

//회원 id체크
public class ValidateRequest extends StringRequest {

    //서버 URL 설정
    final static private String URL = "http://192.168.0.201/Validate.php";
    //final static private String URL = "http://192.168.43.183/Login.php";
    private Map<String, String> map;

    public ValidateRequest(String userID, Response.Listener<String>listener){
        super(Method.POST,URL,listener,null);

        map = new HashMap<>();
        map.put("userID",userID);

    }

    @Override
    protected Map<String, String> getParams() throws AuthFailureError {
        return map;
    }
}