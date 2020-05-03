package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;

public class change_information2 extends AppCompatActivity {

    private String userName;
    private String userMail;
    private String userPhone;
    private String userNewpassword;
    private String userNewpasswordcheck;
    private AlertDialog dialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_information2);

        final Intent intent = getIntent();
        final String userID = intent.getStringExtra("userID");

        //초기화
        final EditText change_name = findViewById(R.id.change_name);
        final EditText change_mail = findViewById(R.id.change_mail);
        final EditText change_phone = findViewById(R.id.change_phone);
        final EditText change_pass = findViewById(R.id.change_pass);
        final EditText change_passcheck = findViewById(R.id.change_passcheck);

        //회원정보 수정완료 버튼 클릭시 수행
        Button btn_completed = findViewById(R.id.btn_completed);
        btn_completed.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                String userID = intent.getStringExtra("userID");
                //EditText에 입력된 값을 가져온다.
                String userName = change_name.getText().toString();
                String userMail = change_mail.getText().toString();
                String userPhone = change_phone.getText().toString();
                String userNewpassword = change_pass.getText().toString();
                String userNewpasswordcheck = change_passcheck.getText().toString();


                //회원정보 수정 버튼
                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {

                        try {
                            JSONObject jsonObject = new JSONObject(response);
                            boolean success = jsonObject.getBoolean("success");

                            if(success){

//                                String userID = jsonObject.getString("userID");
//                                String userName = jsonObject.getString("userName");
//                                String userMail = jsonObject.getString("userMail");
//                                String userPhone = jsonObject.getString("userPhone");
                                String userNewpassword = jsonObject.getString("userNewpassword");
                                String userNewpasswordcheck = jsonObject.getString("userNewpasswordcheck");


                                //비밀번호 확인
                                if(userNewpassword.equals(userNewpasswordcheck))
                                {
                                    Toast.makeText(getApplicationContext(), "회원정보수정이 완료되었습니다.",  Toast.LENGTH_SHORT).show();
                                    Intent intent = new Intent(change_information2.this, change_information.class);
                                    startActivity(intent);
                                } else{
                                    Toast.makeText(getApplicationContext(), "비밀번호과 일치하지않습니다. 다시 확인해주세요.", Toast.LENGTH_SHORT).show();
                                    return;
                                }
                            }

                        } catch (JSONException e){
                            e.printStackTrace();
                        }
                    }
                };

                //서버로 Volley를 이용해서 요청함
                change_informationRequest change_informationRequest = new change_informationRequest(userID, userName, userMail, userPhone, userNewpassword, responseListener);
                RequestQueue queue = Volley.newRequestQueue(change_information2.this);
                queue.add(change_informationRequest);
            }

        });
    }
}
