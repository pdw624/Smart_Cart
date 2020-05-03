package com.example.smartcart;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AlphabetIndexer;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.material.bottomnavigation.BottomNavigationView;

import org.json.JSONArray;
import org.json.JSONObject;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

public class change_information extends AppCompatActivity  {

    private TextView idview, info_view;

    private TextView view_name, view_mail, view_phone;

    private Button btn_change_information;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_information);
        Intent intent = getIntent();

        info_view = findViewById(R.id.info_view);
        String date = UserMenu.db_value_userinfo;
        info_view.setText(date);

        try {
            Log.d("response", "intent:" + intent.getStringExtra("userInfoList"));
            JSONObject jsonObject = new JSONObject(intent.getStringExtra("userInfoList"));
            JSONArray jsonArray = jsonObject.getJSONArray("response");
            //Log.d("response","gogo!!");
            int count = 0;
            String userName, userMail, userPhone;
            while (count < jsonArray.length()) {

                JSONObject object = jsonArray.getJSONObject(count);
                userName = object.getString("userName");
                userMail = object.getString("userMail");
                userPhone = object.getString("userPhone");
                UserInfo userInfo = new UserInfo(userName, userMail, userPhone);
                //      userInfoList.add(userInfo);
                count++;

            }

        } catch (Exception e) {
            e.printStackTrace();
        }


        //view_name
//        TextView viewName = (TextView) findViewById(R.id.view_name);
//        Intent intent1 = getIntent();
//        viewName.setText(intent1.getStringExtra("viewName"));
//
//        //view_mail
//        TextView viewMail = (TextView) findViewById(R.id.view_mail);
//        Intent intent2 = getIntent();
//        viewMail.setText(intent2.getStringExtra("viewMail"));
//
//        //view_phone
//        TextView viewPhone = (TextView) findViewById(R.id.view_phone);
//        Intent intent3 = getIntent();
//        viewPhone.setText(intent3.getStringExtra("viewPhone"));


        idview = findViewById(R.id.id_info_view);
        TextView name = (TextView) findViewById(R.id.id_info_view);

        Intent intent1 = getIntent();
        final String userID = intent1.getStringExtra("userID");
        String msg = UserInfo.id + " 님 정보관리";

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

        //로그아웃
        Button btn_logout = (Button)findViewById(R.id.btn_logout);
        btn_logout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                logout();
            }
        });
    }




    public void logout()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("로그아웃").setMessage("로그아웃 하시겠습니까?");
        builder.setPositiveButton("예", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                Intent intent = new Intent(change_information.this, LoginActivity.class);
                intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP|Intent.FLAG_ACTIVITY_SINGLE_TOP);
                Toast.makeText(getApplicationContext(),"로그아웃 하셨습니다.", Toast.LENGTH_SHORT).show();
                startActivity(intent);
            }
        })
                .setNegativeButton("아니오", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(), "취소하였습니다.", Toast.LENGTH_SHORT).show();
                    }
                })
                .show();
    }

}
