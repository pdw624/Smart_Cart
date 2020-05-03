package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.List;

public class SaleManagement extends AppCompatActivity {

    private static final String TAG = "Sale";
    private TextView theDate,date,order2, theProduct,order3,thePrice,order4,theBuydate;
    private Button btn_Calendar;

    private Button btn_sales,btn_stock,btn_userinfo,btn_home;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sale_management);
        Intent intent = getIntent();
        theDate = (TextView) findViewById(R.id.date);
        theProduct = (TextView) findViewById(R.id.order2);
        thePrice = (TextView) findViewById(R.id.order3);
        theBuydate = (TextView)findViewById(R.id.order4);

        btn_Calendar = (Button) findViewById(R.id.btn_Calendar);
        date = (TextView) findViewById(R.id.date);
        order2 =(TextView) findViewById(R.id.order2);
        order3 = (TextView) findViewById(R.id.order3);
        order4 = (TextView) findViewById(R.id.order4);

        btn_userinfo=(Button)findViewById(R.id.btn_userinfo);
        btn_stock=(Button)findViewById(R.id.btn_stock);
        btn_sales=(Button)findViewById(R.id.btn_sales);
        btn_home=(Button)findViewById(R.id.btn_home);

        String date = CalendarActivity.db_value_date;
        String order2 = CalendarActivity.db_value_product;
        String order3 = CalendarActivity.db_value_price;
        String order4 = CalendarActivity.db_value_buydate;

        theDate.setText(date);
        theProduct.setText(order2);
        thePrice.setText(order3);
        theBuydate.setText(order4);


        //하단 메뉴바 버튼
        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new SaleManagement.BackgroundTask().execute();
            }
        });
        btn_stock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new SaleManagement.BackgroundTask2().execute();
            }
        });
        btn_sales.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(SaleManagement.this, SaleManagement.class);
                startActivity(intent);
            }
        });
        btn_home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(SaleManagement.this,AdminMenu.class);
                startActivity(intent);
            }
        });


        //날짜 선택
        btn_Calendar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(SaleManagement.this, CalendarActivity.class);
                startActivity(intent);
            }
        });

    }
    class BackgroundTask extends AsyncTask<Void, Void, String> {
        String target;

        @Override
        protected void onPreExecute() {
            target = "http://192.168.0.201/List.php";
        }

        @Override
        protected String doInBackground(Void... voids) {
            try {
                URL url = new URL(target);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                InputStream inputStream = httpURLConnection.getInputStream();
                BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream));
                String temp;
                StringBuilder stringBuilder = new StringBuilder();
                while ((temp = bufferedReader.readLine()) != null) {
                    stringBuilder.append(temp + "\n");
                }
                bufferedReader.close();
                inputStream.close();
                httpURLConnection.disconnect();
                return stringBuilder.toString().trim();
            } catch (Exception e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        public void onProgressUpdate(Void... valus) {
            super.onProgressUpdate(valus);
        }

        @Override
        public void onPostExecute(String result) {
            Intent intent = new Intent(SaleManagement.this, Management.class);
            intent.putExtra("userList", result);
            SaleManagement.this.startActivity(intent);
        }
    }

    class BackgroundTask2 extends AsyncTask<Void, Void, String> {
        String target;

        @Override
        protected void onPreExecute() {
            target = "http://192.168.0.201/strokeList.php";
        }

        @Override
        protected String doInBackground(Void... voids) {
            try {
                URL url = new URL(target);
                HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
                InputStream inputStream = httpURLConnection.getInputStream();
                BufferedReader bufferedReader = new BufferedReader(new InputStreamReader(inputStream));
                String temp;
                StringBuilder stringBuilder = new StringBuilder();
                while ((temp = bufferedReader.readLine()) != null) {
                    stringBuilder.append(temp + "\n");
                }
                bufferedReader.close();
                inputStream.close();
                httpURLConnection.disconnect();
                return stringBuilder.toString().trim();
            } catch (Exception e) {
                e.printStackTrace();
            }
            return null;
        }

        @Override
        public void onProgressUpdate(Void... valus) {
            super.onProgressUpdate(valus);
        }

        @Override
        public void onPostExecute(String result) {
            Intent intent = new Intent(SaleManagement.this, StrokeManagement.class);
            intent.putExtra("strokeList", result);
            SaleManagement.this.startActivity(intent);
        }
    }
}
