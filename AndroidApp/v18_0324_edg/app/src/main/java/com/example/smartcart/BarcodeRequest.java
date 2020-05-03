package com.example.smartcart;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.HashMap;
import java.util.Map;

public class BarcodeRequest extends StringRequest {

    final static private String URL = "http://192.168.0.201/ShoppingList.php";

    private Map<String, String> map;


    //생성자
    public BarcodeRequest(String barcode, Response.Listener<String> listener){

        super(Method.POST, URL, listener, null);

        map = new HashMap<>();
        map.put("barcode", barcode);
    }

    @Override
    protected Map<String,String> getParams() throws AuthFailureError {
        return map;
    }
}
