package com.example.smartcart;

import com.android.volley.AuthFailureError;
import com.android.volley.Response;
import com.android.volley.toolbox.StringRequest;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class shoppingListAdapter extends StringRequest {
    final static private String URL = "http://192.168.0.201/split.php";

    private Map<String, String> map;

    //생성자
    public shoppingListAdapter(String orderListGet, Response.Listener<String> listener){
        super(Method.POST, URL, listener, null);

        //초기화
        map = new HashMap<>();
        map.put("orderList", orderListGet);

    }

    @Override
    protected Map<String, String> getParams() throws AuthFailureError {
        return map;
    }
}
