package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

public class find_id_result extends AppCompatActivity {

    private TextView textView46;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_find_id_result);
        Intent intent = getIntent();

        textView46 = findViewById(R.id.textView46);
        String result = find_id.db_value_userID;
        textView46.setText(result);

    }
}
