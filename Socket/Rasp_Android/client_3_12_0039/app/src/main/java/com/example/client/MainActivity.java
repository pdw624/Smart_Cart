package com.example.client;
import android.content.Intent;
import android.os.Handler;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
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

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    Button connect_btn;
    //Button send_btn;

    EditText ip_edit;
    TextView show_text;
    TextView recv_test;
    //EditText send_edit;

    //boolean sendClicked = false;

    private String html = "";
    private Handler mHandler;

    private Socket socket;

    private BufferedReader networkReader;
    private PrintWriter networkWriter;

    private DataOutputStream dos;
    private DataInputStream dis;

    private String ip = "192.168.0.139";
    private int port = 9999;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        connect_btn = (Button)findViewById(R.id.connect_btn);
        connect_btn.setOnClickListener(this);

        //send_btn = (Button)findViewById(R.id.send_btn);
        //send_btn.setOnClickListener(this);

        ip_edit = (EditText)findViewById(R.id.ip_edit);
        show_text = (TextView)findViewById(R.id.show_text);
        recv_test = (TextView)findViewById(R.id.recv_test);
        //send_edit = (EditText)findViewById(R.id.send_edit);
    }

    @Override
    public void onClick(View v) {
        switch(v.getId()){
            case R.id.connect_btn:
                connect();
        }
    }


    void connect(){
        mHandler = new Handler();
        Log.w("MainActivity","connecting");

        Thread checkUpdate = new Thread() {
            public void run() {

                String newip = String.valueOf(ip_edit.getText());
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
                        while (true) {
                            try {
                                int a = (int) dis.read();
                                char ch = (char) a;
                                num += ch;
                                Thread.sleep(100);
                                Log.d("non1", "a : " + a);
                            /*
                            + 이면 나간다....
                             */
                                if (a == 43) {
                                    break;
                                }

                            } catch (Exception e) {
                            }
                        }

                        //Log.d("MainActivity", "ReadLine!!!! DATA....");
                        recv_test.setText("received :" + num);
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
}
