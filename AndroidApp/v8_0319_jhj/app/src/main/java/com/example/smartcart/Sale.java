package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONObject;
import org.w3c.dom.Text;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class Sale extends AppCompatActivity {

    private static final String TAG = "Sale";
    private TextView theDate,date;
    private Button btn_Calendar,btn_sell;

    private ListView listView3;
    private OrderListAdapter adapter3;
    private List<Order> orderList;
    private Button btn_sales,btn_stock,btn_userinfo;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sale);
        Intent intent = getIntent();
        listView3=(ListView)findViewById(R.id.listView3);
        theDate = (TextView) findViewById(R.id.date);
        btn_Calendar = (Button) findViewById(R.id.btn_Calendar);
        date = (TextView) findViewById(R.id.date);

        orderList = new ArrayList<Order>();
        adapter3 = new OrderListAdapter(getApplicationContext(),orderList);
        listView3.setAdapter(adapter3);

        btn_userinfo=(Button)findViewById(R.id.btn_userinfo);
        btn_stock=(Button)findViewById(R.id.btn_stock);
        btn_sales=(Button)findViewById(R.id.btn_sales);

        Intent incomingIntent = getIntent();
        //String date = incomingIntent.getStringExtra("date");
        String date = CalendarActivity.db_value_date;
        theDate.setText(date);
        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new Sale.BackgroundTask().execute();
            }
        });
        btn_stock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new Sale.BackgroundTask2().execute();
            }
        });
        btn_sales.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Sale.this,Sale.class);
                startActivity(intent);
            }
        });


        btn_Calendar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Sale.this, CalendarActivity.class);
                startActivity(intent);
            }
        });

        try{
            JSONObject jsonObject = new JSONObject(intent.getStringExtra("orderList"));
            JSONArray jsonArray = jsonObject.getJSONArray("response");
            int count = 0;

            String product,price,buydate;
            while(count < jsonArray.length()){
                JSONObject object = jsonArray.getJSONObject(count);
                product = object.getString("product");
                price = object.getString("price");
                buydate = object.getString("buydate");

                Order order = new Order(product,price,buydate);
                orderList.add(order);
                count++;
            }
        }catch (Exception e){
            e.printStackTrace();
        }
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
            Intent intent = new Intent(Sale.this, Management.class);
            intent.putExtra("userList", result);
            Sale.this.startActivity(intent);
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
            Intent intent = new Intent(Sale.this, STManage.class);
            intent.putExtra("strokeList", result);
            Sale.this.startActivity(intent);
        }
    }
}
