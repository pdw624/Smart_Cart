package com.example.registerloginexmple;

import android.bluetooth.BluetoothHidDeviceAppSdpSettings;

import com.android.volley.AuthFailureError;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

public class change_informationRequest extends StringRequest {
    final static private String URL = "http://172.20.10.3/Update.php";

    private Map<String, String> map;

    //생성자
    public change_informationRequest(String userID, String userName,
                                     String userMail, String userPhone, String userNewpassword, Response.Listener<String> listener){
        super(Method.POST, URL, listener, null);

        //초기화
        map = new HashMap<>();
        map.put("userID", userID);
        map.put("userName", userName);
        map.put("userNewpassword", userNewpassword);
        map.put("userMail", userMail);
        map.put("userPhone", userPhone);
    }

    @Override
    protected Map<String, String> getParams() throws AuthFailureError {
        return map;
    }
}
