package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.CalendarView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
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
    public static String db_value_result = "";

    private CalendarView mCalendarView;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calendar_layout);
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

                            String success = jsonObject.getString("response");

                            String result="";
                       //     Log.d("Response","value : " + success);
                            if (success.length() > 0) {
                                JSONArray obj = new JSONArray(success);
                                List<String> list = new ArrayList<>();
                                for (int i =0; i<obj.length();i++){
                                    JSONObject order = obj.getJSONObject(i);

                                    list.add(obj.getString(i));
                                    Log.d("Response","list : " + list);
                                    result += "  " + order.getString("product") +"                    "+ order.getString("price")+"                    "
                                    + order.getString("buydate")+"  "+"\n\n";
                                    Log.d("Response","getstring : " + result);
                                    db_value_result = result;
                                }

                                Intent intent = new Intent(CalendarActivity.this,Sale.class);
                                startActivity(intent);
                            }
                            else{
                                Intent intent = new Intent(CalendarActivity.this,Sale.class);
                                startActivity(intent);
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                dateRequest mdateRequest = new dateRequest(date,responseListener);
                RequestQueue queue = Volley.newRequestQueue(CalendarActivity.this);
                queue.add(mdateRequest);
            }
        });
    }
}
