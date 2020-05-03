package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import org.json.JSONArray;
import org.json.JSONObject;

public class purchase_history extends AppCompatActivity {
    private Button btn_stock,btn_userinfo,btn_sales,btn_home,btn_Calendar2;
    private TextView theDate2,date2,purchase,thePurchase;
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
        btn_Calendar2 = findViewById(R.id.btn_Calendar2);
        theDate2 = (TextView) findViewById(R.id.date2);
        date2 = (TextView) findViewById(R.id.date2);
        thePurchase = (TextView) findViewById(R.id.purchase);
        purchase = (TextView)findViewById(R.id.purchase);

        String purchase = CalendarActivity2.db_value_result2;
        thePurchase.setText(purchase);

        String date2 = CalendarActivity2.db_value_date2;
        theDate2.setText(date2);
        //하단 네비게이션바 버튼
        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(cartConnection.isConnected == true){
                    Intent intent = new Intent(purchase_history.this, ShoppingList.class);
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
        btn_Calendar2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(purchase_history.this,CalendarActivity2.class);
                startActivity(intent);
            }
        });
    }
}
