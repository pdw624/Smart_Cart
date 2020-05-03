package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;
import android.content.Intent;
import android.os.Handler;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.HashMap;

import android.os.Bundle;

public class ShoppingList extends AppCompatActivity implements View.OnClickListener {

    Button cart_btn3;
    TextView pay;


    private String html = "";
    private Handler mHandler;

    private Socket socket;

    private BufferedReader networkReader;
    private PrintWriter networkWriter;

    private DataOutputStream dos;
    private DataInputStream dis;

    private String ip = "192.168.0.154";
    private int port = 9999;

    private String str_num;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_shopping_list);

        cart_btn3 = (Button) findViewById(R.id.cart_btn3);
        cart_btn3.setOnClickListener(this);

        pay = (TextView) findViewById((R.id.pay));

    }

    @Override
    public void onClick(View v) {
        switch (v.getId()) {
            case R.id.cart_btn3:
                connect();
        }
    }

    void connect() {
        mHandler = new Handler();
        Log.w("MainActivity", "connecting");

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

                while (true) {
                    try {
                        dos = new DataOutputStream(socket.getOutputStream());
                        dis = new DataInputStream(socket.getInputStream());
                        dos.writeUTF("connection request android to server");
                        String num = "";
                        String nu="";
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
                        nu = num.substring(0,num.length()-1);
                        str_num = nu;
                        //Log.d("MainActivity", "ReadLine!!!! DATA....");
                        if (str_num =="8801500102500")
                        {
                            str_num = "바나나";
                        }
                        //ui쓰레드 안에서 타 쓰레드가 UI제어하려고 하면 오류 발생. Handler작업 필요
                        Message msg = handler.obtainMessage();
                        handler.sendMessage(msg);

                        //pay.setText(num);

                    } catch (IOException e) {
                        e.printStackTrace();
                        Log.w("MainActivity", "wrong buffer");
                    }
                    Log.w("MainActivity", "buffer created");

                }

            }
        };

        checkUpdate.start();
    }
    Handler handler = new Handler() {

        public void handleMessage(Message msg) {

            // 내가 원하는 UI 변경 작업!!
            pay.setText(str_num);
        }

    };
}