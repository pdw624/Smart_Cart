package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class change_information extends AppCompatActivity {

    private TextView idview;

    private TextView view_name, view_mail, view_phone;

    private Button btn_change_information;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_information);

        //view_name
        TextView viewName = (TextView) findViewById(R.id.view_name);
        Intent intent1 = getIntent();
        viewName.setText(intent1.getStringExtra("viewName"));

        //view_mail
        TextView viewMail = (TextView) findViewById(R.id.view_mail);
        Intent intent2 = getIntent();
        viewMail.setText(intent2.getStringExtra("viewMail"));

        //view_phone
        TextView viewPhone = (TextView) findViewById(R.id.view_phone);
        Intent intent3 = getIntent();
        viewPhone.setText(intent3.getStringExtra("viewPhone"));


        idview = findViewById(R.id.id_info_view);
        TextView name = (TextView) findViewById(R.id.id_info_view);

        Intent intent = getIntent();
        final String userID = intent.getStringExtra("userID");
        String msg = UserInfo.id + " 님";

        name.setText(msg);



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
