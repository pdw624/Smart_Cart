package com.example.registerloginexmple;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class change_information extends AppCompatActivity {

    private TextView idview;

    private TextView view_name, view_mail, view_phone;

    private Button btn_change_information;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_information);

        idview = findViewById(R.id.id_info_view);

        TextView name = (TextView) findViewById(R.id.id_info_view);

        Intent intent = getIntent();
        final String userID = intent.getStringExtra("userID");
        String msg = userID + " 님";

        name.setText(msg);


        view_name = findViewById(R.id.view_name);
        view_mail = findViewById(R.id.view_mail);
        view_phone = findViewById(R.id.view_phone);

        btn_change_information = findViewById(R.id.btn_change_information);

        btn_change_information.setOnClickListener(new View.OnClickListener(){

            @Override
            public void onClick(View v) {
                Intent intent = new Intent(change_information.this, change_information2.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

    }
}
