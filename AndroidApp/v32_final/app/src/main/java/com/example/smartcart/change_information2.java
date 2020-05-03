package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
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

import java.util.regex.Pattern;

public class change_information2 extends AppCompatActivity {


    private String userNewpassword, userNewpasswordcheck;
    private String userName;
    private String userMail;
    private String userPhone;
    private AlertDialog dialog;
    private Boolean pass_check1, pass_check2,  mail_check, name_check, phone_check;
    private String str_pass, str_id, str_name, str_mail, str_phone;
    String pwPattern, idPattern, namePattern, mailPattern, phonePattern;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_change_information2);

        final Intent intent = getIntent();
//        final String userID = intent.getStringExtra("userID");
        final String userID = UserInfo.id;

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

                //String userID = intent.getStringExtra("userID");
                String userID = UserInfo.id;

                Log.d("userID", "userID:" + userID);
                //EditText에 입력된 값을 가져온다.


                userName = change_name.getText().toString();
                userMail = change_mail.getText().toString();
                userPhone = change_phone.getText().toString();
                userNewpassword = change_pass.getText().toString();
                userNewpasswordcheck = change_passcheck.getText().toString();

                pwPattern = "^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{6,12}$";
                namePattern = "^[A-Za-z]{2,20}$";
                mailPattern = "^[_a-zA-Z0-9-\\.]+@[\\.a-zA-Z0-9-]+\\.[a-zA-Z]+$";
                phonePattern = "^[0-9]{11,12}$";


                str_name = userName;
                name_check = Pattern.matches(namePattern, str_name);

                str_mail = userMail;
                mail_check = Pattern.matches(mailPattern, str_mail);

                str_phone = userPhone;
                phone_check = Pattern.matches(phonePattern, str_phone);

                str_pass = userNewpassword;
                pass_check1 = Pattern.matches(pwPattern, str_pass);

                str_pass = userNewpasswordcheck;
                pass_check2 = Pattern.matches(pwPattern, str_pass);


                if (userName.equals("")) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(change_information2.this);
                    dialog = builder.setMessage("이름을 입력해주세요.")
                            .setPositiveButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                }

                if(name_check == false){
                    Toast.makeText(getApplicationContext(), "영문이름으로 입력하세요.", Toast.LENGTH_SHORT).show();
                    return;
                }

                if (userMail.equals("")) {
                    AlertDialog.Builder builder1 = new AlertDialog.Builder(change_information2.this);
                    dialog = builder1.setMessage("이메일을 입력해주세요.")
                            .setPositiveButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                }

                if(mail_check == false){
                    Toast.makeText(getApplicationContext(), "메일 형식에 맞지않습니다.", Toast.LENGTH_SHORT).show();
                    return;
                }

                if (userPhone.equals("")) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(change_information2.this);
                    dialog = builder.setMessage("휴대폰 번호를 입력해주세요.")
                            .setPositiveButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                }

                if(phone_check == false){
                    Toast.makeText(getApplicationContext(), "핸드폰번호를 다시 입력하세요.", Toast.LENGTH_SHORT).show();
                    return;
                }

                if (userNewpassword.equals("")) {
                    AlertDialog.Builder builder1 = new AlertDialog.Builder(change_information2.this);
                    dialog = builder1.setMessage("새 비밀번호를 입력해주세요.")
                            .setPositiveButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                }

                if(pass_check1 == false){
                    Toast.makeText(getApplicationContext(), "비밀번호를 문자와 숫자로 조합하세요.", Toast.LENGTH_SHORT).show();
                    return;
                }

                if (userNewpasswordcheck.equals("")) {
                    AlertDialog.Builder builder1 = new AlertDialog.Builder(change_information2.this);
                    dialog = builder1.setMessage("새 비밀번호 확인을 입력해주세요.")
                            .setPositiveButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                }

                if(pass_check2 == false){
                    Toast.makeText(getApplicationContext(), "비밀번호를 문자와 숫자로 조합하세요.", Toast.LENGTH_SHORT).show();
                    return;
                }





                //비밀번호 확인
                if(userNewpassword.equals(userNewpasswordcheck)){

                    //회원정보 수정 버튼
                    Response.Listener<String> responseListener = new Response.Listener<String>() {
                        @Override
                        public void onResponse(String response) {


                            try {
                                JSONObject jsonObject = new JSONObject(response);
                                boolean success = jsonObject.getBoolean("success");

                                if(success){


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

                    //결과 완료시 회원정보수정 완료
                    Toast.makeText(getApplicationContext(), "회원정보수정이 완료되었습니다. \n 변경된 정보로 다시 로그인해주세요",  Toast.LENGTH_LONG).show();
                    Intent intent = new Intent(change_information2.this, LoginActivity.class);
                    startActivity(intent);

                } else{

                    Toast.makeText(getApplicationContext(), "비밀번호과 일치하지않습니다. 다시 확인해주세요.", Toast.LENGTH_SHORT).show();
                    return;

                }

            }

        });
    }
}
