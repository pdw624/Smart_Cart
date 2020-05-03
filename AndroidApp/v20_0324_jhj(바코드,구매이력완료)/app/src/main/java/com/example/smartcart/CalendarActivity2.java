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

public class CalendarActivity2 extends AppCompatActivity {
    private static final String TAG = "CalendarActivity2";
    public static String db_value_date2 = "";
    public static String db_value_result2 = "";

    private CalendarView mCalendarView;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calendar_layout_history);
        mCalendarView = (CalendarView) findViewById(R.id.calendarView2);

        mCalendarView.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {
                final String date = (year) + "/" + (month + 1) + "/" + dayOfMonth;
                String orderID = UserInfo.id;;  // 로그인한 유저 아이디로 바꾸면 됨
                Log.d("Response","orderID : "+orderID);
                db_value_date2 = (year) + "-" + (month + 1) + "-" + dayOfMonth;
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
                                    db_value_result2 = result;
                                }

                                Intent intent = new Intent(CalendarActivity2.this,purchase_history.class);
                                startActivity(intent);
                            }
                            else{
                                Intent intent = new Intent(CalendarActivity2.this,purchase_history.class);
                                startActivity(intent);
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                dateRequest2 mdateRequest = new dateRequest2(date,orderID,responseListener);
                RequestQueue queue = Volley.newRequestQueue(CalendarActivity2.this);
                queue.add(mdateRequest);
            }
        });
    }
}
