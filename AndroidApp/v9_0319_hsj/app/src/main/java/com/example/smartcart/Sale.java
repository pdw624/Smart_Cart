package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONObject;
import org.w3c.dom.Text;

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

    private ListView listView4;
    private SumListAdapter adapter4;
    private List<Sum> sumList;

    private Button btn_stock,btn_userinfo,btn_sales,btn_home;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sale);
        Intent intent = getIntent();
        listView3=(ListView)findViewById(R.id.listView3);
        theDate = (TextView) findViewById(R.id.date);
        btn_sell = (Button) findViewById(R.id.btn_sell);
        btn_Calendar = (Button) findViewById(R.id.btn_Calendar);
        date = (TextView) findViewById(R.id.date);

        orderList = new ArrayList<Order>();
        adapter3 = new OrderListAdapter(getApplicationContext(),orderList);
        listView3.setAdapter(adapter3);


        sumList = new ArrayList<Sum>();
        adapter4 = new SumListAdapter(getApplicationContext(),sumList);
        String sumdb = CalendarActivity.db_value_sum;
       // listView4.setText(sumdb);

        Intent incomingIntent = getIntent();
        //String date = incomingIntent.getStringExtra("date");
        String date1 = CalendarActivity.db_value_date;
        theDate.setText(date1);

        btn_sell.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String dates = date.getText().toString();
            }
        });
        btn_Calendar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Sale.this, CalendarActivity.class);
                startActivity(intent);
            }
        });

        btn_userinfo = findViewById(R.id.btn_userinfo);
        btn_stock = findViewById(R.id.btn_stock);
        btn_sales = findViewById(R.id.btn_sales);
        btn_home = findViewById(R.id.btn_home);


        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Sale.this, Management.class);
                startActivity(intent);
            }
        });

        btn_stock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Sale.this, STManage.class);
                startActivity(intent);
            }
        });

        btn_sales.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Sale.this, Sale.class);
                startActivity(intent);
            }
        });

        btn_home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Sale.this, AdminMenu.class);
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

        try{
            JSONObject jsonObject = new JSONObject(intent.getStringExtra("sumList"));
            JSONArray jsonArray = jsonObject.getJSONArray("response");
            int count = 0;

            String sumTotal;
            while(count < jsonArray.length()){
                JSONObject object = jsonArray.getJSONObject(count);
                sumTotal = object.getString("sum");

                Sum sum = new Sum(sumTotal);
                sumList.add(sum);
                count++;
            }
        }catch (Exception e){
            e.printStackTrace();
        }

    }
}
