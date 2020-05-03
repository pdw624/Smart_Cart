package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class cartinfo extends AppCompatActivity {

    private Button cart_btn1;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cartinfo);

        cart_btn1 = findViewById(R.id.cart_btn1);


        cart_btn1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(cartinfo.this,UserMenu.class);
                startActivity(intent);
            }
        });
    }
}
