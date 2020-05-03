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
    private TextView theDate2,date2,purchase,thePurchase1,thePurchase2,thePurchase3;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_purchase_history);

        Intent intent = getIntent();
        final String userID = intent.getStringExtra("userID");


        btn_Calendar2 = findViewById(R.id.btn_Calendar2);
        theDate2 = (TextView) findViewById(R.id.date2);
        thePurchase1 = (TextView) findViewById(R.id.purchase1);
        thePurchase2 = (TextView) findViewById(R.id.purchase2);
        thePurchase3 = (TextView) findViewById(R.id.purchase3);


        String purchase1 = CalendarActivity2.db_value_result1;
        thePurchase1.setText(purchase1);
        String purchase2 = CalendarActivity2.db_value_result2;
        thePurchase2.setText(purchase2);
        String purchase3 = CalendarActivity2.db_value_result3;
        thePurchase3.setText(purchase3);

        String date2 = CalendarActivity2.db_value_date2;
        theDate2.setText(date2);


        //달력선택 버튼
        btn_Calendar2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(purchase_history.this,CalendarActivity2.class);
                startActivity(intent);
            }
        });


        //하단 네비게이션바 버튼
        btn_userinfo = findViewById(R.id.btn_userinfo);
        btn_stock = findViewById(R.id.btn_stock);
        btn_sales = findViewById(R.id.btn_sales);
        btn_home = findViewById(R.id.btn_home);

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

    }
}
