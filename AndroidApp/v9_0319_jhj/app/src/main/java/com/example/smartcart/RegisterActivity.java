package com.example.smartcart;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;
import com.example.smartcart.LoginActivity;
import com.example.smartcart.RegisterRequest;

import org.json.JSONException;
import org.json.JSONObject;

public class RegisterActivity extends AppCompatActivity {

    //private EditText et_id, et_pass, et_name, et_mail, et_phone;
    //private Button btn_register;

    private String userID;
    private String userPassword;
    private String userName;
    private String userMail;
    private String userPhone;
    private AlertDialog dialog;
    private boolean validate = false;   //사용할 수 있는 아이디인지 체크해주는 변수

    @Override
    protected void onCreate(Bundle savedInstanceState) { //액티비티 시작시 처음으로 실행되는 생명주기
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register);

        //초기화
        final EditText et_id = findViewById(R.id.et_id);
        final EditText et_pass = findViewById(R.id.et_pass);
        final EditText et_name = findViewById(R.id.et_name);
        final EditText et_mail = findViewById(R.id.et_mail);
        final EditText et_phone = findViewById(R.id.et_phone);

        //회원 가입시 아이디 중복체크 부분
        final Button validateButton = (Button) findViewById(R.id.validateButton);
        validateButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //Log.d("RegisterActivity", "validateButton onClick +++!!!!!");
                String userID = et_id.getText().toString();

                //ID값 미입력시
                if (validate) {     //현재 validdate에 체크가 되있는 상태 바로 빠져나가기
                    return;         //검증완료
                }
                //Log.d("RegisterActivity", "validateButton onClick ---!!!!!");
                if (userID.equals(""))
                {
                    AlertDialog.Builder builder = new AlertDialog.Builder(RegisterActivity.this);
                    dialog = builder.setMessage("아이디는 빈 칸일 수 없습니다")
                            .setPositiveButton("확인", null)
                            .create();
                    dialog.show();
                    //Log.d("RegisterActivity", "validateButton onClick ---!!!!!");
                    return;
                }

                //정상적 진행 후 -> 중복체크 시작
                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try
                        {
                            //Log.d("RegisterActivity", "Response +++!!!!!");
                            //Toast.makeText(RegisterActivity.this, response, Toast.LENGTH_LONG).show();
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");
                            if (success) {
                                AlertDialog.Builder builder = new AlertDialog.Builder(RegisterActivity.this);
                                dialog = builder.setMessage("사용할 수 있는 아이디입니다")
                                        .setPositiveButton("확인", null)
                                        .create();
                                dialog.show();
                                et_id.setEnabled(false);    //아이디값 바꿀수 없게함 (고정시켜줌)
                                validate = true;            //중복체크 완료
                                et_id.setBackgroundColor(getResources().getColor(R.color.colorGray));
                                validateButton.setBackgroundColor(getResources().getColor(R.color.colorGray));
                            } else
                            {
                                AlertDialog.Builder builder = new AlertDialog.Builder(RegisterActivity.this);
                                dialog = builder.setMessage("사용할 수 없는 아이디입니다")
                                        .setNegativeButton("확인", null)
                                        .create();
                                dialog.show();

                            }
                        } catch (Exception e) {
                            e.printStackTrace();
                        }
                    }
                };
                //서버로 Volley를 이용해서 요청을 함
                ValidateRequest validateRequest = new ValidateRequest(userID, responseListener);
                RequestQueue queue = Volley.newRequestQueue(RegisterActivity.this);
                queue.add(validateRequest);
            }
        });

        //회원가입 버튼 클릭시 수행
        Button btn_register = findViewById(R.id.btn_register);
        btn_register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                //EditText에 현재 입력 되어있는 값을 get(가져온다)해온다.
                String userID = et_id.getText().toString();
                String userPass = et_pass.getText().toString();
                String userName = et_name.getText().toString();
                String userMail = et_mail.getText().toString();
                String userPhone = et_phone.getText().toString();

                //ID 중복체크 확인여부
                if (!validate) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(RegisterActivity.this);
                    dialog = builder.setMessage("먼저 중복체크를 해주세요")
                            .setNegativeButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                }

                //미입력시
                if (userID.equals("") || userPass.equals("") || userName.equals("") || userMail.equals("") || userPhone.equals("")) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(RegisterActivity.this);
                    dialog = builder.setMessage("빈칸 없이 입력 해주세요")
                            .setNegativeButton("확인", null)
                            .create();
                    dialog.show();
                    return;
                }

                //회원가입 버튼
                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");
                            if (success) {   //회원등록에 성공한 경우
                                Toast.makeText(getApplicationContext(), "회원 등록에 성공하였습니다.", Toast.LENGTH_SHORT).show();
                                Intent intent = new Intent(RegisterActivity.this, LoginActivity.class);
                                startActivity(intent);
                            } else {    //회원등록에 실패한 경우
                                Toast.makeText(getApplicationContext(), "회원 등록에 실패하였습니다.", Toast.LENGTH_SHORT).show();
                                return;
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                    }
                };

                //서버로 Volley를 이용해서 요청을 함
                RegisterRequest registerRequest = new RegisterRequest(userID, userPass, userName, userMail, userPhone, responseListener);
                RequestQueue queue = Volley.newRequestQueue(RegisterActivity.this);
                queue.add(registerRequest);

            }
        });

    }
    //회원 등록창이 꺼지게되면 실행
//    @Override
//    protected void onStop(){
//        super.onStop();
//        if(dialog != null)
//        {
//            dialog.dismiss();
//            dialog = null;
//        }
//    }


}

