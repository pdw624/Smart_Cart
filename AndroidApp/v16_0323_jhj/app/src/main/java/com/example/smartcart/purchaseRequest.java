package com.example.smartcart;

import com.android.volley.AuthFailureError;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

public class purchaseRequest extends StringRequest {

    final static private String URL = "http://192.168.0.201/PurchaseList.php";
    private Map<String, String> map;

    public purchaseRequest(String userID, Response.Listener<String> listener) {
        super(Method.POST, URL, listener, null);

        map = new HashMap<>();
        map.put("userID", userID);
        //map.put("date");
    }
    @Override
    protected Map<String, String> getParams() throws AuthFailureError{
        return map;
    }


}
