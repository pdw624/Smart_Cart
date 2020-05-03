package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

public class find_password_result extends AppCompatActivity {

    private TextView textView49;
    private Button btn_login3, btn_find_id2;
    private ImageButton btn_back;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_find_password_result);
        Intent intent = getIntent();

        String userName = intent.getStringExtra("userName");
        String userPassword = intent.getStringExtra("userPassword");

        String msg = userName + " 님의 비밀번호는\n" + userPassword +" 입니다.";
        TextView find_result = (TextView) findViewById(R.id.textView49);

        find_result.setText(msg);


        //뒤로가기
        btn_back = findViewById(R.id.backspace2);
        btn_back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(find_password_result.this, LoginActivity.class);
                startActivity(intent);
            }
        });

        //다시 로그인 버튼
        btn_login3 = findViewById(R.id.btn_login3);
        btn_login3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(find_password_result.this, LoginActivity.class);
                startActivity(intent);
            }
        });

        //아이디 찾기 버튼
        btn_find_id2 = findViewById(R.id.btn_find_id2);
        btn_find_id2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(find_password_result.this, find_password.class);
                startActivity(intent);
            }
        });

    }
}
