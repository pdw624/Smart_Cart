package com.example.smartcart;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import androidx.appcompat.app.AppCompatActivity;

public class UserMenu extends AppCompatActivity {

    public static String db_value_userinfo;

    private TextView idView;

    private Button btn_cart_connection;
    private Button btn_shopping_list;
    private Button btn_purchase_history;
    private Button btn_user_info;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_menu);

        idView = findViewById(R.id.idView);

        TextView name = (TextView) findViewById(R.id.idView);

        Intent intent = getIntent();
        final String userID = intent.getStringExtra("userID");
        String msg = UserInfo.id + " 님";
        Log.d("response", userID );

        name.setText(msg);

        btn_cart_connection = findViewById(R.id.btn_cart_connection);         //카트 연동
        btn_shopping_list = findViewById(R.id.btn_shopping_list);             //장바구니
        btn_purchase_history = findViewById(R.id.btn_purchase_history);       //주문 이력
        btn_user_info = findViewById(R.id.btn_user_info);                     //내 정보관리

        btn_cart_connection.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserMenu.this, cartConnection.class);
                startActivity(intent);
            }
        });

        btn_shopping_list.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserMenu.this, ShoppingList.class);
                startActivity(intent);
            }
        });


        //주문 이력
        btn_purchase_history.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserMenu.this, purchase_history.class);
                startActivity(intent);
            }
        });


        //내 정보관리
        btn_user_info.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonObject = new JSONObject(response);
                            String success = jsonObject.getString("response");

                            String result="";
                            //     Log.d("Response","value : " + success);
                            if (success.length() > 0) {
                                JSONArray obj = new JSONArray(success);
                                for (int i =0; i<obj.length();i++){
                                    JSONObject user = obj.getJSONObject(i);

                                    result += user.getString("userName") +"\n\n"+ user.getString("userMail")+ "\n\n"
                                            + user.getString("userPhone")+"\n\n";
                                    Log.d("Response","getstring : " + result);
                                    db_value_userinfo = result;
                                }

                                Intent intent = new Intent(UserMenu.this, change_information.class);
                                startActivity(intent);
                            }
                            else{
                                Intent intent = new Intent(UserMenu.this, change_information.class);
                                startActivity(intent);
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                UserInfoRequest userInfoRequest = new UserInfoRequest(userID,responseListener);
                RequestQueue queue = Volley.newRequestQueue(UserMenu.this);
                queue.add(userInfoRequest);
            }
        });
    }
}
