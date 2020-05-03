package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class Management extends AppCompatActivity {

    private ListView listView;
    private UserListAdapter adapter;
    private List<User> userList;

    private Button btn_stock,btn_userinfo,btn_sales,btn_home;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_management);
        Intent intent = getIntent();
        listView=(ListView)findViewById(R.id.listView);


        userList = new ArrayList<User>();
        adapter = new UserListAdapter(getApplicationContext(),userList);
        listView.setAdapter(adapter);


        btn_userinfo = findViewById(R.id.btn_userinfo);
        btn_stock = findViewById(R.id.btn_stock);
        btn_sales = findViewById(R.id.btn_sales);
        btn_home = findViewById(R.id.btn_home);


        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Management.this, Management.class);
                startActivity(intent);
            }
        });

        btn_stock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Management.this, STManage.class);
                startActivity(intent);
            }
        });

        btn_sales.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Management.this, Sale.class);
                startActivity(intent);
            }
        });

        btn_home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Management.this, AdminMenu.class);
                startActivity(intent);
            }
        });


        try{
            JSONObject jsonObject = new JSONObject(intent.getStringExtra("userList"));
            JSONArray jsonArray = jsonObject.getJSONArray("response");
            int count = 0;
            String userID,userName,userPhone;
            while(count < jsonArray.length()){
               JSONObject object = jsonArray.getJSONObject(count);
               userName = object.getString("userName");
               userID = object.getString("userID");
               userPhone = object.getString("userPhone");

               User user = new User(userName,userID,userPhone);
               userList.add(user);

               count++;
            }
        }catch (Exception e){
            e.printStackTrace();
        }
        /*
        userList.add(new User("혁진","바보","ㄱㄷ","20"));
        userList.add(new User("혁진","바보","ㄱㄷ","20"));
        userList.add(new User("혁진","바보","ㄱㄷ","20"));
*/

    }
}
