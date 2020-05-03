package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class find_id_result extends AppCompatActivity {

    private TextView textView46;
    private Button btn_login2, btn_pass;
    private ImageButton btn_back;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_find_id_result);
        Intent intent = getIntent();

        String userID = intent.getStringExtra("userID");
        String userName = intent.getStringExtra("userName");

        String msg = userName + " 님의 아이디는\n" + userID + " 입니다.";

        TextView find_result = (TextView) findViewById(R.id.textView46);

        find_result.setText(msg);

        //뒤로가기
        btn_back = findViewById(R.id.backspace2);
        btn_back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(find_id_result.this, LoginActivity.class);
                startActivity(intent);
            }
        });

        //다시 로그인 버튼
        btn_login2 = findViewById(R.id.btn_login2);
        btn_login2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(find_id_result.this, LoginActivity.class);
                startActivity(intent);
            }
        });

        //비밀번호 찾기 버튼
        btn_pass = findViewById(R.id.btn_pass);
        btn_pass.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(find_id_result.this, find_password.class);
                startActivity(intent);
            }
        });

//        textView46 = findViewById(R.id.textView46);
//        String result = find_id.db_value_userID;
//        textView46.setText(result);
        Log.d("Response", "find_id_result --> userID: " + userID);
        Log.d("Response", "find_id_result --> userName: " + userName);

    }
}
