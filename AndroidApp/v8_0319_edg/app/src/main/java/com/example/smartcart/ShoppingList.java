package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;

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
import java.util.List;

import android.os.Bundle;
import android.widget.Toast;


public class ShoppingList extends AppCompatActivity {
    //총액 나타내는 텍스트뷰에 임시로 바코드 값 표기 (ListView 활용 불가 ㅠ)
    private TextView pay;

    //바코드 값 받아오기 위한 변수
    final static cartConnection cc = new cartConnection();
    static String barcode;// = cc.str_num;

    private DataOutputStream dos;
    private DataInputStream dis;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_shopping_list);

        pay = (TextView) findViewById((R.id.pay));

        setListView();
        //MainThreadException을 막기 위해 readBarcode()함수를 새로운 쓰레드에서 돌림
        new Thread() {
            public void run() {
                readBarcode();
            }
        }.start();
    }

    void setListView(){
        String[] strList = {"테스트01", "테스트02", "테스트03"};
        ArrayAdapter<String> listAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1,strList);
        ListView listView = (ListView) findViewById(R.id.listView);
        listView.setAdapter(listAdapter);
    }


    //기존의 connect 함수에는 데이터를 입력받는 함수까지 구현되어 있었음
    //socket생성부분 : connect(), data입력받는부분 : readBarcode() 으로 나누어 구현
    //Socket은 카트 선택창(cartConnection.java)에서 생성, DataOutputStream,DataInputStream은 장바구니(ShoppingList.java)에서 구현
    void readBarcode() {
        while (true) {
            try {
                dos = new DataOutputStream(cc.socket.getOutputStream());
                dis = new DataInputStream(cc.socket.getInputStream());
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
                             +이면 나간다....
                             */
                        if (a == 43) {
                            break;
                        }

                    } catch (Exception e) {
                    }
                }

                barcode = num.substring(0, num.length() - 1);
                //cc.str_num = nu;

                //Log.d("MainActivity", "ReadLine!!!! DATA....");

                //ui쓰레드 안에서 타 쓰레드가 UI제어하려고 하면 오류 발생. Handler작업 필요
                Message msg = handler.obtainMessage();
                handler.sendMessage(msg);


                //pay.setText(nu);

            } catch (IOException e) {
                e.printStackTrace();
                Log.w("MainActivity", "wrong buffer");
            }
            Log.w("MainActivity", "buffer created");

        }
    }

    Handler handler = new Handler() {

        public void handleMessage(Message msg) {

            // 내가 원하는 UI 변경 작업!!
              pay.setText(barcode);
            //list.add(barcode);
            //cc.str_num = "";
        }

    };

}




