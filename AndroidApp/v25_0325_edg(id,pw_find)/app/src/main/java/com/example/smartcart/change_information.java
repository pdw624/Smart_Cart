package com.example.smartcart;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AlphabetIndexer;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.material.bottomnavigation.BottomNavigationView;

import org.json.JSONArray;
import org.json.JSONObject;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

public class change_information extends AppCompatActivity  {
    public static String db_value_userinfo;
    private TextView idview, info_view;

    private TextView view_name, view_mail, view_phone;

    private Button btn_change_information;

    private Button btn_stock,btn_userinfo,btn_sales,btn_home;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_information);
        Intent intent = getIntent();

        info_view = findViewById(R.id.info_view);
        String date = UserMenu.db_value_userinfo;
        info_view.setText(date);


        idview = findViewById(R.id.id_info_view);
        TextView name = (TextView) findViewById(R.id.id_info_view);

        Intent intent1 = getIntent();
        final String userID = intent1.getStringExtra("userID");
        String msg = UserInfo.id + " 님 정보관리";

        name.setText(msg);



        try {
            Log.d("response", "intent:" + intent.getStringExtra("userInfoList"));
            JSONObject jsonObject = new JSONObject(intent.getStringExtra("userInfoList"));
            JSONArray jsonArray = jsonObject.getJSONArray("response");
            //Log.d("response","gogo!!");
            int count = 0;
            String userName, userMail, userPhone;
            while (count < jsonArray.length()) {

                JSONObject object = jsonArray.getJSONObject(count);
                userName = object.getString("userName");
                userMail = object.getString("userMail");
                userPhone = object.getString("userPhone");
                UserInfo userInfo = new UserInfo(userName, userMail, userPhone);
                //      userInfoList.add(userInfo);
                count++;
            }

        } catch (Exception e) {
            e.printStackTrace();
        }


        btn_change_information = findViewById(R.id.btn_change_information);

        btn_change_information.setOnClickListener(new View.OnClickListener(){

            @Override
            public void onClick(View v) {
                Intent intent = new Intent(change_information.this, change_information2.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_userinfo = findViewById(R.id.btn_userinfo);
        btn_stock = findViewById(R.id.btn_stock);
        btn_sales = findViewById(R.id.btn_sales);
        btn_home = findViewById(R.id.btn_home);

        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(change_information.this, ShoppingList.class);
                intent.putExtra("userID",userID);
                startActivity(intent);
            }
        });

        btn_stock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(change_information.this, purchase_history.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_sales.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(change_information.this, change_information.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(change_information.this, UserMenu.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });



    }

}
