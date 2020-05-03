package com.example.smartcart;

import android.os.Bundle;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class purchase_history extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_purchase_history);

        TextView name = (TextView) findViewById(R.id.purchase_viewName);
        String msg = UserInfo.id + "님 구매이력";

        name.setText(msg);

    }
}
