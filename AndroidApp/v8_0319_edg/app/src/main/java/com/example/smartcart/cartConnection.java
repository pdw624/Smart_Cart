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
import java.io.PrintWriter;
import java.net.Socket;

public class cartConnection extends AppCompatActivity {

    //rasp - app 통신 변수입니다.
    public static Socket socket;

    private BufferedReader networkReader;
    private PrintWriter networkWriter;

    //private DataOutputStream dos;
    //private DataInputStream dis;
    public static DataOutputStream dos;
    public static DataInputStream dis;


    private String ip = "192.168.0.154";
    private int port = 9999;

    public static String str_num;

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
                        connect();
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
}
