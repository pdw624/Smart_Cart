package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class purchase_history extends AppCompatActivity {
    private Button btn_stock,btn_userinfo,btn_sales,btn_home;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_purchase_history);

        Intent intent = getIntent();
        final String userID = intent.getStringExtra("userID");

//하단 네비게이션바 버튼
        btn_userinfo = findViewById(R.id.btn_userinfo);
        btn_stock = findViewById(R.id.btn_stock);
        btn_sales = findViewById(R.id.btn_sales);
        btn_home = findViewById(R.id.btn_home);


        //하단 네비게이션바 버튼
        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(purchase_history.this, ShoppingList.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_stock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(purchase_history.this, purchase_history.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_sales.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(purchase_history.this, change_information.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(purchase_history.this, UserMenu.class);
                intent.putExtra("userID", userID);
                UserInfo.id = userID;
                startActivity(intent);
            }
        });
    }
}
