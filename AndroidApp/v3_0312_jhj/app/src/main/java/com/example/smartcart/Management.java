package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
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
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_management);
        Intent intent = getIntent();
        listView=(ListView)findViewById(R.id.listView);
        userList = new ArrayList<User>();
        adapter = new UserListAdapter(getApplicationContext(),userList);
        listView.setAdapter(adapter);

        try{
            JSONObject jsonObject = new JSONObject(intent.getStringExtra("userList"));
            JSONArray jsonArray = jsonObject.getJSONArray("response");
            int count = 0;
            String userID,userPassword,userName,userAge;
            while(count < jsonArray.length()){
               JSONObject object = jsonArray.getJSONObject(count);
               userID = object.getString("userID");
               userPassword = object.getString("userPassword");
               userName = object.getString("userName");
               userAge = object.getString("userAge");
               User user = new User(userID,userPassword,userName,userAge);
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
