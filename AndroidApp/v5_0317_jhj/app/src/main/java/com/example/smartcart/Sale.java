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

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class Sale extends AppCompatActivity {

    private static final String TAG = "Sale";
    private TextView theDate;
    private Button btn_Calendar;

    private ListView listView3;
    private OrderListAdapter adapter3;
    private List<Order> orderList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sale);
        Intent intent = getIntent();
        listView3=(ListView)findViewById(R.id.listView3);
        theDate = (TextView) findViewById(R.id.date);
        btn_Calendar = (Button) findViewById(R.id.btn_Calendar);

        orderList = new ArrayList<Order>();
        adapter3 = new OrderListAdapter(getApplicationContext(),orderList);
        listView3.setAdapter(adapter3);

        Intent incomingIntent = getIntent();
        //String date = incomingIntent.getStringExtra("date");
        String date = CalendarActivity.db_value_date;
        theDate.setText(date);

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

            String product,price,buyday,sum;
            while(count < jsonArray.length()){
                JSONObject object = jsonArray.getJSONObject(count);
                product = object.getString("product");
                price = object.getString("price");
                buyday = object.getString("buyday");

                Order order = new Order(product,price,buyday);
                orderList.add(order);
                count++;
            }
        }catch (Exception e){
            e.printStackTrace();
        }

    }
}
