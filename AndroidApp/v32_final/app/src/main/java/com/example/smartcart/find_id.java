package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageButton;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONObject;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

public class find_id extends AppCompatActivity {

    public static String db_value_userID;

    private ImageButton btn_back;
    private EditText find_id_name, find_id_email;
    private AlertDialog dialog;
    private Button btn_find_id;;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_find_id);

        //뒤로가기
        btn_back = findViewById(R.id.backspace1);
        btn_back.setOnClickListener(new View.OnClickListener() {
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
                final String userMail = find_id_email.getText().toString();
                Log.d("Response", "find_id --> userName:  " + userName);


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


                Log.d("Response", "gogo!! ");
                //4. 콜백 처리부분(volley 사용을 위한 ResponseListener 구현 부분)
                Response.Listener<String> responseListener = new Response.Listener<String>() {

                    //서버로부터 여기서 데이터를 받음
                    @Override
                    public void onResponse(String response) {


                        Log.d("Response", "gogo!!++ ");
                        try {

                            //서버로부터 받는 데이터는 JSON타입의 객체이다.
                            Log.d("TAG", "response : " + response);
                            JSONObject jsonObject = new JSONObject(response);

                            //그중 Key값이 "success"인 것을 가져온다.
                            boolean success = jsonObject.getBoolean("success");

                            Log.d("Response", "response: " + response);
                            Log.d("Response", "success: " + success);

                            //userName과 userMail값에 해당하는 정보가 있는 경우 success 값이 true
                            if (success) {
                                //그중 Key값이 "userID"인 것을 가져온다.
                                String userID = jsonObject.getString("userID");
                                Intent intent = new Intent(find_id.this, find_id_result.class);
                                intent.putExtra("userName", userName);
                                intent.putExtra("userID", userID);
                                startActivity(intent);


                                //userName과 userMail값에 해당 정보가 없는 경우 success 값이 false
                            } else {

                                AlertDialog.Builder builder = new AlertDialog.Builder(find_id.this);
                                dialog = builder.setMessage("입력하신 정보와 일치하는 아이디가없습니다.")
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
                FindRequest findRequest = new FindRequest(userName, userMail, responseListener);
                RequestQueue queue = Volley.newRequestQueue(find_id.this);
                queue.add(findRequest);

            }
        });


    }
}
