package com.example.registerloginexmple;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import java.io.BufferedReader;

public class adminMenu extends AppCompatActivity {

    private Button btn_userinfo;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_admin_menu);

        btn_userinfo = findViewById(R.id.btn_userinfo);

        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(adminMenu.this, ManagementActivity.class);
                startActivity(intent);
            }
        });

    }
}
