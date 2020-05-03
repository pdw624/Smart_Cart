package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

public class ShoppingList extends AppCompatActivity {

    //하단 메뉴바 버튼
    private Button btn_stock,btn_userinfo,btn_sales,btn_home;
    String orderTemp;

    private Button btn_order;
    //총액 나타내는 텍스트뷰에 임시로 바코드 값 표기 (ListView 활용 불가 ㅠ)
    private TextView pay;

    //바코드 값 받아오기 위한 변수
    final static cartConnection cc = new cartConnection();
    static String barcode_cartNum;// = cc.str_num;
    static String barcode;
    static String cartNum;

    //바코드 값을 주면 상품명, 가격을 넘겨받는 변수
    static String db_value_pdInfo;

    //id,상품명,가격,날짜 순으로 저장할 변수
    ArrayList<String> orderList = new ArrayList<>();

    private DataOutputStream dos;
    private DataInputStream dis;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_shopping_list);

        pay = (TextView) findViewById((R.id.pay));
        btn_order = (Button) findViewById(R.id.btn_order);
        //setListView();
        //MainThreadException을 막기 위해 readBarcode()함수를 새로운 쓰레드에서 돌림
        new Thread() {
            public void run() {
                readBarcode();
            }
        }.start();


        Intent intent = getIntent();
        final String userID = intent.getStringExtra("userID");

        btn_userinfo = findViewById(R.id.btn_userinfo);
        btn_stock = findViewById(R.id.btn_stock);
        btn_sales = findViewById(R.id.btn_sales);
        btn_home = findViewById(R.id.btn_home);


        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(ShoppingList.this, ShoppingList.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_stock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(ShoppingList.this, purchase_history.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_sales.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(ShoppingList.this, change_information.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(ShoppingList.this, UserMenu.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
            }
        });

        btn_order.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                for(int j=0; j<orderList.size();j++){
                    System.out.println(orderList.get(j));
                }

                //회원정보 수정 버튼
                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {

                        try {
                            JSONObject jsonObject = new JSONObject(response);
                            boolean success = jsonObject.getBoolean("success");

                            if (success) {
                                String orderTemp = jsonObject.getString("orderTemp");
                            }

                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                //서버로 Volley를 이용해서 요청함
                shoppingListAdapter shoppingListAdapter = new shoppingListAdapter(orderTemp, responseListener);
                RequestQueue queue = Volley.newRequestQueue(ShoppingList.this);
                queue.add(shoppingListAdapter);
                Log.d("Response","orderTemp"+orderTemp);
            }
        });
    }

//*************************************************************************************************************************

//    void setListView(){
//        String[] strList = {"테스트01", "테스트02", "테스트03"};
//        ArrayAdapter<String> listAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1,strList);
//        ListView listView = (ListView) findViewById(R.id.listView);
//        listView.setAdapter(listAdapter);
//    }


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

                barcode_cartNum = num.substring(0, num.length() - 1);
                //cc.str_num = nu;
                String temp[] = barcode_cartNum.split("/");
                barcode = temp[0];
                cartNum = temp[1];


                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                new Thread() {
                    public void run() {
                        getInfo();
                    }
                }.start();
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //Log.d("MainActivity", "ReadLine!!!! DATA....");

                //ui쓰레드 안에서 타 쓰레드가 UI제어하려고 하면 오류 발생. Handler작업 필요
                //Message msg = handler.obtainMessage();
                //handler.sendMessage(msg);


                //pay.setText(nu);

            } catch (IOException e) {
                e.printStackTrace();
                Log.w("MainActivity", "wrong buffer");
            }
            Log.w("MainActivity", "buffer created");

        }
    }



    public void getInfo(){
        Response.Listener<String> responseListener = new Response.Listener<String>() {
            @Override
            public void onResponse(String response) {
                try {
                    JSONObject jsonObject = new JSONObject(response);
                    String success = jsonObject.getString("response");

                    String result = "";
                    //     Log.d("Response","value : " + success);
                    if (success.length() > 0) {
                        JSONArray obj = new JSONArray(success);
                        for (int i = 0; i < obj.length(); i++) {
                            JSONObject user = obj.getJSONObject(i);

                            result += user.getString("name") + " " + user.getString("price");
                            Log.d("Response", "getstring : " + result);
                            //db_value_pdInfo = result;//상품명과 가격 저장
                            //Log.d("db_value_pdInfo", db_value_pdInfo);


                            db_value_pdInfo = result;

                            SimpleDateFormat sdf = new SimpleDateFormat ( "yyyy-MM-dd");
                            Date time = new Date();
                            String currentTime = sdf.format(time);

                            orderTemp = UserInfo.id + " " +db_value_pdInfo+" "+currentTime;
                            orderList.add(orderTemp);

                            Log.d("orderTemp", orderTemp);
                        }

                        Message msg = handler.obtainMessage();
                        handler.sendMessage(msg);

                        //Log.d("hello", db_value_pdInfo);
                        //Log.d("world", result);

                        //다른 화면으로 넘겨주기 위한 코드(지금은 필요 없음, 바코드 값을 change_information 클래스에서 사용할 수 있도록 이동시킴)
                        /*Intent intent = new Intent(ShoppingList.this, change_information.class);
                        intent.putExtra("barcode", barcode);
                        startActivity(intent);*/
                        Log.d("Response", "intent");
                    } /*else {
                        Intent intent = new Intent(ShoppingList.this, change_information.class);
                        intent.putExtra("barcode", barcode);
                        startActivity(intent);
                    }*/
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        };
        BarcodeRequest barcodeRequest = new BarcodeRequest(barcode, responseListener);
        RequestQueue queue = Volley.newRequestQueue(ShoppingList.this);
        queue.add(barcodeRequest);
        Log.d("Response", "getstring1 : " + barcode);

    }





    Handler handler = new Handler() {

        public void handleMessage(Message msg) {

            // 내가 원하는 UI 변경 작업!!
            pay.append(db_value_pdInfo+"\r\n");
            Log.d("hello",":"+db_value_pdInfo);
            //pay.append(barcode);
            //Log.d("hello",barcode);

            //list.add(barcode);
            //cc.str_num = "";
        }

    };



}
