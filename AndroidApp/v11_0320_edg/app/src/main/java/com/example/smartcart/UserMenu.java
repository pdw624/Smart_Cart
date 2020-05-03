package com.example.smartcart;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

import androidx.appcompat.app.AppCompatActivity;

public class UserMenu extends AppCompatActivity {

    public static String db_value_userinfo;

    private TextView idView;

    private Button btn_cart_connection;
    private Button btn_shopping_list;
    private Button btn_purchase_history;
    private Button btn_user_info;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_menu);

        idView = findViewById(R.id.idView);

        TextView name = (TextView) findViewById(R.id.idView);

        Intent intent = getIntent();
        final String userID = intent.getStringExtra("userID");
        String msg = UserInfo.id + " 님";
        Log.d("response", userID );

        name.setText(msg);

        btn_cart_connection = findViewById(R.id.btn_cart_connection);         //카트 연동
        btn_shopping_list = findViewById(R.id.btn_shopping_list);             //장바구니
        btn_purchase_history = findViewById(R.id.btn_purchase_history);       //주문 이력
        btn_user_info = findViewById(R.id.btn_user_info);                     //내 정보관리

        btn_cart_connection.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserMenu.this, cartConnection.class);
                startActivity(intent);
            }
        });

        btn_shopping_list.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserMenu.this, ShoppingList.class);
                startActivity(intent);
            }
        });


        //주문 이력
        btn_purchase_history.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserMenu.this, purchase_history.class);
                startActivity(intent);
            }
        });


        //내 정보관리
        btn_user_info.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonObject = new JSONObject(response);
                            String success = jsonObject.getString("response");

                            String result="";
                            //     Log.d("Response","value : " + success);
                            if (success.length() > 0) {
                                JSONArray obj = new JSONArray(success);
                                for (int i =0; i<obj.length();i++){
                                    JSONObject user = obj.getJSONObject(i);

                                    result += user.getString("userName") +"\n\n"+ user.getString("userMail")+ "\n\n"
                                            + user.getString("userPhone")+"\n\n";
                                    Log.d("Response","getstring : " + result);
                                    db_value_userinfo = result;
                                }

                                Intent intent = new Intent(UserMenu.this, change_information.class);
                                startActivity(intent);
                            }
                            else{
                                Intent intent = new Intent(UserMenu.this, change_information.class);
                                startActivity(intent);
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                UserInfoRequest userInfoRequest = new UserInfoRequest(userID,responseListener);
                RequestQueue queue = Volley.newRequestQueue(UserMenu.this);
                queue.add(userInfoRequest);
            }
        });


    }

    class BackgroundTask extends AsyncTask<Void, Void, String>
    {
        String target;

        @Override
        protected void onPreExecute(){
            target = "http://192.168.0.23/UserInfoList.php";

        }
        @Override
        protected String doInBackground(Void... voids){
            try{
                URL url = new URL(target);  //url 객체 만듬

                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection(); //파싱하는 부분

                InputStream inputStream = httpURLConnection.getInputStream();   //inputStream 객체만듬

                BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream)); //버퍼를 만들어 하나씩 읽어오게함

                String temp;    //매 열마다 입력받게함

                StringBuilder stringBuilder = new StringBuilder();


                while((temp = bufferedReader.readLine()) != null)
                {
                    stringBuilder.append(temp + "\n");
                    bufferedReader.close();
                    inputStream.close();
                    httpURLConnection.disconnect();
                    return stringBuilder.toString().trim();
                }

            } catch (Exception e){
                e.printStackTrace();
            }
            return null;
        }

        @Override
        public void onProgressUpdate(Void... values){
            super.onProgressUpdate(values);
        }

        @Override
        public void onPostExecute(String result){
            Intent intent = new Intent(UserMenu.this, change_information.class);
            intent.putExtra("userInfoList", result);

            UserMenu.this.startActivity(intent);
        }


    }
}
