package com.example.smartcart;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.CalendarView;
import android.widget.ImageButton;
import android.widget.Toast;

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
    public static String db_value_result1 = "";
    public static String db_value_result2 = "";
    public static String db_value_result3 = "";

    private CalendarView mCalendarView;
    private ImageButton btn_back;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calendar_layout_history);


        //뒤로가기
        btn_back = findViewById(R.id.backspace1);
        btn_back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(CalendarActivity2.this, purchase_history.class);
                startActivity(intent);
            }
        });

        mCalendarView = (CalendarView) findViewById(R.id.calendarView2);
        mCalendarView.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {
                final String date = (year) + "/" + (month + 1) + "/" + dayOfMonth;
                String orderID = UserInfo.id;;  // 로그인한 유저 아이디로 바꾸면 됨
                Log.d("Response","orderID : "+orderID);

                //입력받은 날짜 변수에 저장
                db_value_date2 = (year) + "-" + (month + 1) + "-" + dayOfMonth;
                Log.d(TAG, "onSelectedDayChange: mm/dd/yyyy: " + date);


                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    @Override
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonObject = new JSONObject(response);

                            String success = jsonObject.getString("response");
                            JSONArray obj = new JSONArray(success);

                            String result1="";
                            String result2="";
                            String result3="";
                            //     Log.d("Response","value : " + success);
                            if (obj.length() > 0) {

                                List<String> list = new ArrayList<>();
                                for (int i =0; i<obj.length();i++){
                                    JSONObject order = obj.getJSONObject(i);

                                    list.add(obj.getString(i));
                                    Log.d("Response","list : " + list);

                                    result1 += "  " + order.getString("product") +"\n";
                                    Log.d("Response","getstring : " + result1);
                                    db_value_result1 = result1;

                                    result2 += "  " + order.getString("price") +"원\n";
                                    Log.d("Response","getstring : " + result2);
                                    db_value_result2 = result2;

                                    result3 += "  " + order.getString("buydate") +"\n";
                                    Log.d("Response","getstring : " + result3);
                                    db_value_result3 = result3;

                                }

                                Intent intent = new Intent(CalendarActivity2.this,purchase_history.class);
                                startActivity(intent);
                            }
                            else{

                                Toast.makeText(getApplicationContext(),"해당 날짜에는 구매내역이 없습니다.", Toast.LENGTH_LONG).show();
                                return;

                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }
                    }
                };
                CalendarRequest2 mdateRequest = new CalendarRequest2(date,orderID,responseListener);
                RequestQueue queue = Volley.newRequestQueue(CalendarActivity2.this);
                queue.add(mdateRequest);
            }
        });
    }

}
