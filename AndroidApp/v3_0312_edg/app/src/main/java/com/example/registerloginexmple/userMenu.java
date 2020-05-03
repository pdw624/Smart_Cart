package com.example.registerloginexmple;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class userMenu extends AppCompatActivity {

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

        TextView welcome = (TextView) findViewById(R.id.idView);

        Intent intent = getIntent();
        String userID = intent.getStringExtra("userID");
        String msg = userID + " 님";

        welcome.setText(msg);

        btn_cart_connection = findViewById(R.id.btn_cart_connection);         //카트 연동
        btn_shopping_list = findViewById(R.id.btn_shopping_list);             //장바구니
        btn_purchase_history = findViewById(R.id.btn_purchase_history);       //주문 목록
        btn_user_info = findViewById(R.id.btn_user_info);                     //회원정보 수정

        btn_cart_connection.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(userMenu.this, cartConnection.class);
                startActivity(intent);
            }
        });

        btn_shopping_list.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(userMenu.this, shopping_list.class);
                startActivity(intent);
            }
        });

        btn_purchase_history.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(userMenu.this, purchase_history.class);
            }
        });

        btn_user_info.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(userMenu.this, change_information.class);
                startActivity(intent);
            }
        });

    }
}
