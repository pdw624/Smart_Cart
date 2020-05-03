package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.example.smartcart.ShoppingList;
import com.example.smartcart.change_information;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class UserMenu extends AppCompatActivity {

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

        name.setText(msg);

        btn_cart_connection = findViewById(R.id.btn_cart_connection);         //카트 연동
        btn_shopping_list = findViewById(R.id.btn_shopping_list);             //장바구니
        btn_purchase_history = findViewById(R.id.btn_purchase_history);       //주문 목록
        btn_user_info = findViewById(R.id.btn_user_info);                     //회원정보 수정

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

        btn_purchase_history.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(UserMenu.this, purchase_history.class);
                startActivity(intent);
            }
        });

        btn_user_info.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Intent intent = new Intent(UserMenu.this, change_information.class);
                intent.putExtra("userID", userID);
                startActivity(intent);
                new BackgroundTask().execute();
            }
        });

    }

    class BackgroundTask extends AsyncTask<Void, Void, String>
    {
        String target1;
        String target2;
        String target3;

        @Override
        protected void onPreExecute(){
            target1 = "http://192.168.0.23/view_name.php";
            target2 = "http://192.168.0.23/view_mail.php";
            target3 = "http://192.168.0.23/view_phone.php";
        }
        @Override
        protected String doInBackground(Void... voids){
            try{
                URL url1 = new URL(target1);  //url 객체 만듬
                URL url2 = new URL(target2);
                URL url3 = new URL(target3);

                HttpURLConnection httpURLConnection1 = (HttpURLConnection) url1.openConnection(); //파싱하는 부분
                HttpURLConnection httpURLConnection2 = (HttpURLConnection) url2.openConnection(); //파싱하는 부분
                HttpURLConnection httpURLConnection3 = (HttpURLConnection) url3.openConnection(); //파싱하는 부분

                InputStream inputStream1 = httpURLConnection1.getInputStream();   //inputStream 객체만듬
                InputStream inputStream2 = httpURLConnection2.getInputStream();   //inputStream 객체만듬
                InputStream inputStream3 = httpURLConnection3.getInputStream();   //inputStream 객체만듬

                BufferedReader bufferedReader1 = new BufferedReader(new InputStreamReader(inputStream1)); //버퍼를 만들어 하나씩 읽어오게함
                BufferedReader bufferedReader2 = new BufferedReader(new InputStreamReader(inputStream2)); //버퍼를 만들어 하나씩 읽어오게함
                BufferedReader bufferedReader3 = new BufferedReader(new InputStreamReader(inputStream3)); //버퍼를 만들어 하나씩 읽어오게함

                String temp1;    //매 열마다 입력받게함
                String temp2;    //매 열마다 입력받게함
                String temp3;    //매 열마다 입력받게함

                StringBuilder stringBuilder1 = new StringBuilder();
                StringBuilder stringBuilder2 = new StringBuilder();
                StringBuilder stringBuilder3 = new StringBuilder();

                while((temp1 = bufferedReader1.readLine()) != null)
                {
                    stringBuilder1.append(temp1 + "\n");
                    bufferedReader1.close();
                    inputStream1.close();
                    httpURLConnection1.disconnect();
                    return stringBuilder1.toString().trim();
                }

                while((temp2 = bufferedReader2.readLine()) != null)
                {
                    stringBuilder2.append(temp2 + "\n");
                    bufferedReader2.close();
                    inputStream2.close();
                    httpURLConnection2.disconnect();
                    return stringBuilder2.toString().trim();
                }

                while((temp3 = bufferedReader3.readLine()) != null)
                {
                    stringBuilder3.append(temp3 + "\n");
                    bufferedReader3.close();
                    inputStream3.close();
                    httpURLConnection3.disconnect();
                    return stringBuilder3.toString().trim();
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
            intent.putExtra("viewName", result);
            intent.putExtra("viewMail", result);
            intent.putExtra("viewPhone", result);

            UserMenu.this.startActivity(intent);
        }


    }
}
