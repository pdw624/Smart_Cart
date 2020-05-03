package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.accessibility.AccessibilityManager;
import android.widget.CalendarView;
import android.widget.ImageButton;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class CalendarActivity extends AppCompatActivity {
    private static final String TAG = "CalendarActivity";
    public static String db_value_date = "";
    public static String db_value_product = "";
    public static String db_value_price = "";
    public static String db_value_buydate = "";

    private AlertDialog dialog;
    private CalendarView mCalendarView;
    private ImageButton btn_back;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calendar_layout);

        //뒤로가기
        btn_back = findViewById(R.id.backspace1);
        btn_back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(CalendarActivity.this, SaleManagement.class);
                startActivity(intent);
            }
        });


        mCalendarView = (CalendarView) findViewById(R.id.calendarView);
        mCalendarView.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {

                final String date = (year) + "/" + (month + 1) + "/" + dayOfMonth;
                db_value_date = (year) + "-" + (month + 1) + "-" + dayOfMonth;
                Log.d(TAG, "onSelectedDayChange: mm/dd/yyyy: " + date);


                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonObject = new JSONObject(response);

                            //boolean success = jsonObject.getBoolean("success");

                            Log.d("Response", "## response: " + response);
                            //Log.d("Response", "success: " + success1);
                            //////////////////////////////////
                            String success = jsonObject.getString("response");
                            JSONArray obj = new JSONArray(success);

                            String result="";
                            String result1="";
                            String result2="";

                            Log.d("Response","success.length : " + success.length());
                            if (obj.length() > 0) {
                                Log.d("Response", "if ok");
                                Log.d("Response", "obj.length : " + obj.length());

                                List<String> list = new ArrayList<>();
                                for (int i = 0; i < obj.length(); i++) {
                                    JSONObject order = obj.getJSONObject(i);

                                    list.add(obj.getString(i));
                                    Log.d("Response", "list : " + list);
                                    result += order.getString("product") + "\n";
                                    result1 += order.getString("price") + "원\n";
                                    result2 += order.getString("buydate") + "\n";
                                    Log.d("Response", "getstring : " + result);
                                    db_value_product = result;
                                    db_value_price = result1;
                                    db_value_buydate = result2;
                                }

                                Intent intent = new Intent(CalendarActivity.this, SaleManagement.class);
                                startActivity(intent);
                            } else {
                                Log.d("Response", "obj.length : " + obj.length());
                                Toast.makeText(getApplicationContext(),"해당 날짜에는 판매량이 없습니다.", Toast.LENGTH_LONG).show();
                                return;
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                CalendarRequest mdateRequest = new CalendarRequest(date,responseListener);
                RequestQueue queue = Volley.newRequestQueue(CalendarActivity.this);
                queue.add(mdateRequest);
            }
        });
    }
}
