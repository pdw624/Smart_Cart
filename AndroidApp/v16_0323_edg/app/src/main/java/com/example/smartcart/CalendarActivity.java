package com.example.smartcart;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.CalendarView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.Calendar;

public class CalendarActivity extends AppCompatActivity {
    private static final String TAG = "CalendarActivity";
    public static String db_value_date = "";
    public static String db_value_sum = "";
    private CalendarView mCalendarView;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.calendar_layout);
        mCalendarView = (CalendarView) findViewById(R.id.calendarView);

        mCalendarView.setOnDateChangeListener(new CalendarView.OnDateChangeListener() {
            @Override
            public void onSelectedDayChange(@NonNull CalendarView view, int year, int month, int dayOfMonth) {
                String date = (year) + "/" + (month + 1) + "/" + dayOfMonth;
                Log.d(TAG, "onSelectedDayChange: mm/dd/yyyy: " + date);
                Intent intent = new Intent(CalendarActivity.this, Sale.class);
//                intent.putExtra("date", date);
                db_value_date = date;
//                startActivity(intent);

                new BackgroundTask3().execute();
                //new BackgroundTask4().execute();
            }
        });
    }

    class BackgroundTask3 extends AsyncTask<Void, Void, String> {
        String target;

        @Override
        protected void onPreExecute() {
            target = "http://192.168.0.23/orderList.php";
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
            Intent intent = new Intent(CalendarActivity.this, Sale.class);
            intent.putExtra("orderList", result);
            CalendarActivity.this.startActivity(intent);
        }
    }
    class BackgroundTask4 extends AsyncTask<Void, Void, String> {
        String target;

        @Override
        protected void onPreExecute() {
            target = "http://192.168.0.23/sumList.php";
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
            Intent intent = new Intent(CalendarActivity.this, Sale.class);
            intent.putExtra("sumList", result);
           // db_value_sum = result;
            CalendarActivity.this.startActivity(intent);
        }
    }
}
