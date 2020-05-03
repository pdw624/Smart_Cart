package com.example.smartcart;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.regex.Pattern;

public class find_id extends AppCompatActivity {

    public static String db_value_userID;

    private ImageButton btn_back1;
    private EditText find_id_name, find_id_email;
    private AlertDialog dialog;
    private boolean validate = false;   //정보가 일치한지 체크해주는 변수

    private String userName;
    private String userMail;
    private Button btn_find_id;

    private Boolean name_check, mail_check;
    private String str_name, str_mail;
    String namePattern, mailPattern;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_find_id);

        //뒤로가기
        btn_back1 = findViewById(R.id.backspace1);
        btn_back1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(find_id.this, LoginActivity.class);
                startActivity(intent);
            }
        });


        //초기화
        find_id_name = findViewById(R.id.find_id_name);
        find_id_email = findViewById(R.id.find_id_email);

        //확인 버튼 클릭
        btn_find_id = findViewById(R.id.btn_find_id);
        btn_find_id.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //EditText에 입력된 값을 가져옴
                final String userName = find_id_name.getText().toString();
                String userMail = find_id_email.getText().toString();


                //ID값 미입력시
                if (validate) {     //현재 validdate에 체크가 되있는 상태 바로 빠져나가기
                    return;         //검증완료
                }

                if (userName.equals("")) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(find_id.this);
                    dialog = builder.setMessage("이름이 빈칸입니다.")
                            .setPositiveButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                    }

                if (userMail.equals("")) {
                    AlertDialog.Builder builder1 = new AlertDialog.Builder(find_id.this);
                    dialog = builder1.setMessage("메일이 빈칸입니다.")
                            .setPositiveButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                }



                //정상적 진행 후 -> 중복체크 시작
                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {

                            JSONObject jsonObject = new JSONObject(response);
                            //String success = jsonObject.getString("response");
                            boolean success = jsonObject.getBoolean("success");
                            String result = "";


                            if (success) {

                                AlertDialog.Builder builder = new AlertDialog.Builder(find_id.this);
                                dialog = builder.setMessage("입력하신 정보와 일치하는 아이디가없습니다.")
                                        .setNegativeButton("확인", null)
                                        .create();
                                dialog.show();

                            } else {
                                JSONArray obj = new JSONArray(success);
                                for (int i = 0; i < obj.length(); i++) {
                                    JSONObject user = obj.getJSONObject(i);

                                    result += user.getString("userName") + " 님의 아이디는 \n"
                                            + user.getString("userID") + "입니다.";
                                    Log.d("Response", "getstring : " + result);
                                    db_value_userID = result;
                                }
                                Intent intent = new Intent(find_id.this, find_id_result.class);
                                intent.putExtra("userName", userName);
                                startActivity(intent);
                                Log.d("Response","intent");

//                                ////////////////////////////////////////////////////////////////////////////////////////////////
//                               Intent intent = new Intent(find_id.this, find_id_result.class);
//                               intent.putExtra("userName", userName);
//                                startActivity(intent);
                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                };


                //서버로 Volley를 이용해서 요청을 함
                FindRequest findRequest = new FindRequest(userName, userMail, responseListener);
                RequestQueue queue = Volley.newRequestQueue(find_id.this);
                queue.add(findRequest);



//                //이름, 메일, 공백, 유효성 검사
//                namePattern = "^[A-Za-z]{2,4}$";
//                mailPattern = "^[_a-zA-Z0-9-\\.]+@[\\.a-zA-Z0-9-]+\\.[a-zA-Z]+$";
//
//                str_name = find_id_name.getText().toString().trim();
//                name_check = Pattern.matches(namePattern, str_name);
//
//                str_mail = find_id_email.getText().toString().trim();
//                mail_check = Pattern.matches(mailPattern, str_mail);
//
//
//                //이름, 메일 공백, 유효성 체크
//                if(name_check == true){
//                    if(mail_check == true){
//                        return;
//                    }else{
//                        Toast.makeText(getApplicationContext(), "메일을 다시 입력해주세요.", Toast.LENGTH_SHORT).show();
//                    }
//                }else
//                    {
//                        Toast.makeText(getApplicationContext(), "이름을 다시 입력해주세요.", Toast.LENGTH_SHORT).show();
//                }
//
//                //////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//
//
//
//
//
//
//
//                //아이디 찾기 버튼
//                Response.Listener<String> responseListener = new Response.Listener<String>() {
//                    @Override
//                    public void onResponse(String response) {
//                        try {
//                            JSONObject jsonResponse = new JSONObject(response);
//                            boolean success = jsonResponse.getBoolean("success");
//                            if (success) {   //아이디찾기에 성공한 경우
//
//
//                            } else {    //아이디찾기에 실패한 경우
//                                //Toast.makeText(getApplicationContext(), "회원 등록에 실패하였습니다.", Toast.LENGTH_SHORT).show();
//                                return;
//                            }
//                        } catch (JSONException e) {
//                            e.printStackTrace();
//                        }
//
//                    }
//                };



            }
        });


    }
}
