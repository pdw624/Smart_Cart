package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class UserMenu extends AppCompatActivity {

    private Button btn_userinfo;
    private TextView Name;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_menu);

        Name = findViewById(R.id.Name);

        Intent intent = getIntent();
        String userID = intent.getStringExtra("userID");

        Name.setText(userID);

        btn_userinfo = findViewById(R.id.btn_userinfo);

        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserMenu.this,ShoppingList.class);
                startActivity(intent);
            }
        });
    }
}
