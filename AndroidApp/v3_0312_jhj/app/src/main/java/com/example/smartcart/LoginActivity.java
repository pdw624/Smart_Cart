package com.example.smartcart;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONException;
import org.json.JSONObject;
import java.io.*;
import java.net.*;

import android.app.*;
import android.os.*;
import android.view.*;
import android.widget.*;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

public class LoginActivity extends AppCompatActivity {
    private EditText et_id,et_pass;
    private Button btn_login,btn_register;



    public Socket cSocket = null;
    private String server = "192.168.0.14"; // 서버 ip주소
    private int port = 9999; // 포트번호
    public static String cartNumber = "1";
    public static String cartName;
    public static String usingName;

    public PrintWriter streamOut = null;
    public BufferedReader streamIn = null;

    public String nickName;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        et_id = findViewById(R.id.et_id);
        et_pass = findViewById(R.id.et_pass);
        btn_login = findViewById(R.id.btn_login);
        btn_register = findViewById(R.id.btn_register);

        //회원가입 버튼 클릭시 수행
        btn_register.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(LoginActivity.this,RegisterActivity.class);
                startActivity(intent);
            }
        });
        //로그인 버튼 클릭시 수행
        btn_login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String userID = et_id.getText().toString();
                String userPass = et_pass.getText().toString();

                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonObject = new JSONObject(response);
                            boolean success = jsonObject.getBoolean("success");
                            if (success) {
                                String userID = jsonObject.getString("userID");
                                String userPass = jsonObject.getString("userPassword");
                                Toast.makeText(getApplicationContext(), "로그인에 성공하였습니다.", Toast.LENGTH_SHORT).show();

                                if (userID.equals("admin")) {
                                    Intent intent = new Intent(LoginActivity.this, AdminMenu.class);
                                    intent.putExtra("userID", userID);
                                    intent.putExtra("userPass", userPass);
                                    startActivity(intent);
                                }
                                else{
                                    Intent intent = new Intent(LoginActivity.this, UserMenu.class);
                                    intent.putExtra("userID", userID);
                                    intent.putExtra("userPass", userPass);
                                    startActivity(intent);
                                    //APP - PC통신 코드입니다.
                                    if (cSocket == null) {
                                        usingName = et_id.getText().toString();
                                        //logger("접속중입니다...");


                                        Connect c = new Connect();
                                        c.start();
                                    }

                                    cartName = "cartName_Test";



                                    if (cartName != null && !"".equals(cartName)) {

                                        new Thread(){
                                            public void run(){
                                                sendMessage("[" + usingName + "] " + cartName);
                                            }
                                        }.start();
                                        //msgText.setText("");
                                    }



                                }
                            }
                            else{
                                Toast.makeText(getApplicationContext(),"로그인에 실패하였습니다.", Toast.LENGTH_SHORT).show();
                                return;
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                LoginRequest loginRequest = new LoginRequest(userID,userPass, responseListener);
                RequestQueue queue = Volley.newRequestQueue(LoginActivity.this);
                queue.add(loginRequest);
            }
        });
    }

    public void connect(String server, int port, String user) {
        try {
            cSocket = new Socket(server, port);
            streamOut = new PrintWriter(cSocket.getOutputStream(), true); // 출력용 스트림
            streamIn = new BufferedReader(new InputStreamReader(cSocket.getInputStream())); // 입력용 스트림

            //sendMessage("# 새로운 이용자[" + user + "]님이 들어왔습니다.");
            sendMessage(cartNumber+"/"+cartName+"/"+usingName);//연결되는 '순간' 카트에 대한 정보를 pc로 보내준다.

            //cThread = new chatThread();
            //cThread.start();

        }catch (Exception ex) {
            //logger("접속이 제대로 이루어 지지 않았습니다." + ex);
        }
    }

    public void onDestroy() { // 앱이 소멸되면
        super.onDestroy();
        if (cSocket != null) {
            sendMessage("# [" + nickName + "]님이 나가셨습니다.");
        }
    }

    /*private void logger(String MSG) {
        tv.append(MSG + "\n"); // 텍스트뷰에 메세지를 더해줍니다.
        sv.fullScroll(ScrollView.FOCUS_DOWN); // 스크롤뷰의 스크롤을 내려줍니다.
    }*/

    private void sendMessage(String MSG) {
        try {
            streamOut.println(MSG); // 서버에 메세지를 보내줍니다.
        } catch (Exception ex) {
            //logger(ex.toString());
        }

    }

    Handler mHandler = new Handler() { // 스레드에서 메세지를 받을 핸들러.
        public void handleMessage(Message msg) {
            switch (msg.what) {
                case 0: // 채팅 메세지를 받아온다.
                    //logger(msg.obj.toString());
                    break;
                case 1: // 소켓접속을 끊는다.
                    try {
                        cSocket.close();
                        cSocket = null;

                        //logger("접속이 끊어졌습니다.");

                    } catch (Exception e) {
                        //logger("접속이 이미 끊겨 있습니다." + e.getMessage());
                        finish();
                    }
                    break;
            }
        }
    };



    class Connect extends Thread{

        private boolean flag = false; // 스레드 유지(종료)용 플래그

        public void run(){
            super.run();
            connect(server, port , nickName);
            //sendMessage("안녕하세요");
            try {
                while (!flag) { // 플래그가 false일경우에 루프
                    String msgs;
                    Message msg = new Message();
                    msg.what = 0;
                    msgs = streamIn.readLine(); // 서버에서 올 메세지를 기다린다.
                    msg.obj = msgs;

                    mHandler.sendMessage(msg); // 핸들러로 메세지 전송

                    if (msgs.equals("# [" + nickName + "]님이 나가셨습니다.")) { // 서버에서 온 메세지가 종료 메세지라면
                        flag = true; // 스레드 종료를 위해 플래그를 true로 바꿈.
                        msg = new Message();
                        msg.what = 1; // 종료메세지
                        mHandler.sendMessage(msg);
                    }
                }

            }catch(Exception e) {
                //logger(e.getMessage());
            }
        }
    }



}