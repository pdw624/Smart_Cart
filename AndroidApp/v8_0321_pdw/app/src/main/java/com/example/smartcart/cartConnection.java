package com.example.smartcart;

import android.content.DialogInterface;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class cartConnection extends AppCompatActivity {

    //rasp - app 통신 변수입니다.***************************
    public static Socket socket;

    private BufferedReader networkReader;
    private PrintWriter networkWriter;

    public static DataOutputStream dos;
    public static DataInputStream dis;

    private String ip = "192.168.0.154";// rasp ip주소
    private int port = 9999;

    public static String str_num;
    //app - pcApp 통신 변수입니다.***************************
    public Socket cSocket = null;
    private String server = "192.168.0.201"; // pc서버 ip주소
    //private int port = 9999; // 포트번호
    public static String cartNumber;
    public static String cartName;
    public static String usingName;

    public PrintWriter streamOut = null;
    public BufferedReader streamIn = null;

    public String nickName;
    ///////////////////////////////////////////////////////

    LoginActivity la = new LoginActivity();

    private Button button1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cart_connection);

        button1 = (Button)findViewById(R.id.cart_btn1);
        button1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                show1();
            }
        });


    }

    void show1()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("카트 연결");
        builder.setMessage("1번 카트를 연결하시겠습니까?");
        builder.setPositiveButton("예",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        //rasp - app 통신코드입니다.
                        connect();

                        //APP - PC통신 코드입니다.//////////////////////////////////////////////

                        if (cSocket == null) {
                            usingName = UserInfo.id;//로그인 할 때의 ID를 저장
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


                        ////////////////////////////////////////////////////////////////

                        Toast.makeText(getApplicationContext(),"1번 카트와 연결하였습니다.",Toast.LENGTH_LONG).show();
                        button1.setEnabled(false);
                    }
                });
        builder.setNegativeButton("아니오",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(),"1번 카트를 취소하였습니다.",Toast.LENGTH_LONG).show();
                    }
                });
        builder.show();
    }

    //rasp - app 통신 연결 함수입니다.
    void connect() {
        //mHandler = new Handler();
        Log.w("MainActivity", "connecting");

        checkUpdate.start();
    }

    Thread checkUpdate = new Thread() {
        public void run() {

            String newip = "192.168.0.154";//String.valueOf(ip_edit.getText());
            //String  send_msg = String.valueOf(send_edit.getText());

            try {
                socket = new Socket(newip, port);
                Log.w("MainActivity", "server connected");
            } catch (IOException e1) {
                Log.w("MainActivity", "server connection fail");
                e1.printStackTrace();
            }

            Log.w("MainActivity", "connection request android to server");

            //연결 시작시 카트 번호를 바로 받기 위한 소스
            try {
                dis = new DataInputStream(socket.getInputStream());
            } catch (IOException e) {
                e.printStackTrace();
            }
            String num = "";
            while (true) {
                try {
                    int a = (int) dis.read();
                    char ch = (char) a;
                    num += ch;
                    Thread.sleep(100);
                    Log.d("non1", "a : " + a);
                            /*
                             +이면 나간다....
                             */
                    if (a == 43) {
                        break;
                    }

                } catch (Exception e) {
                }
            }

            cartNumber = num.substring(0, num.length() - 1);
            sendMessage(cartNumber+"/"+cartName+"/"+usingName);//연결되는 '순간' 카트에 대한 정보를 pc로 보내준다.
            /*
            while (true) {
                try {
                    dos = new DataOutputStream(socket.getOutputStream());
                    dis = new DataInputStream(socket.getInputStream());
                    dos.writeUTF("connection request android to server");
                    String num = "";

                    while (true) {
                        try {
                            int a = (int) dis.read();
                            char ch = (char) a;
                            num += ch;
                            Thread.sleep(100);
                            Log.d("non1", "a : " + a);

                             //+이면 나간다....

                            if (a == 43) {
                                break;
                            }

                        } catch (Exception e) {
                        }
                    }

                    String nu = num.substring(0,num.length()-1);
                    str_num = nu;


                    //Log.d("MainActivity", "ReadLine!!!! DATA....");

                    //ui쓰레드 안에서 타 쓰레드가 UI제어하려고 하면 오류 발생. Handler작업 필요
                    //Message msg = handler.obtainMessage();
                    //handler.sendMessage(msg);

                    //pay.setText(num);

                } catch (IOException e) {
                    e.printStackTrace();
                    Log.w("MainActivity", "wrong buffer");
                }
                Log.w("MainActivity", "buffer created");

            }*/


        }
    };


    //pc-App 통신 연결 함수입니다.
    public void connect(String server, int port, String user) {
        try {
            cSocket = new Socket(server, port);
            streamOut = new PrintWriter(cSocket.getOutputStream(), true); // 출력용 스트림
            streamIn = new BufferedReader(new InputStreamReader(cSocket.getInputStream())); // 입력용 스트림

            //sendMessage("# 새로운 이용자[" + user + "]님이 들어왔습니다.");
            //sendMessage(cartNumber+"/"+cartName+"/"+usingName);//연결되는 '순간' 카트에 대한 정보를 pc로 보내준다.

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


    public class Connect extends Thread{

        private boolean flag = false; // 스레드 유지(종료)용 플래그

        public void run(){
            super.run();
            connect(server, port , usingName);
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
