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

    private TextView idview, info_view;
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

        final String userID = UserInfo.id;
        String msg = UserInfo.id + " 님 정보관리";

        name.setText(msg);


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
                if(cartConnection.isConnected == true){
                    Intent intent = new Intent(change_information.this, ShoppingList.class);
                    intent.putExtra("userID", userID);
                    startActivity(intent);
                }
                else{
                    Toast.makeText(getApplicationContext(),"카트 연결을 한 후 다시 시도해주세요.",Toast.LENGTH_SHORT).show();
                }
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
