package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import com.android.volley.toolbox.StringRequest;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class STManage extends AppCompatActivity {
    private Button btn_sales,btn_stock,btn_userinfo,btn_home;
    private ListView listView2;
    private StrokeListAdapter adapter2;
    private List<Stroke> strokeList;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_stmanage);
        Intent intent = getIntent();
        listView2=(ListView)findViewById(R.id.listView2);
        btn_userinfo=(Button)findViewById(R.id.btn_userinfo);
        btn_stock=(Button)findViewById(R.id.btn_stock);
        btn_sales=(Button)findViewById(R.id.btn_sales);
        btn_home=(Button)findViewById(R.id.btn_home);

        strokeList = new ArrayList<Stroke>();
        adapter2 = new StrokeListAdapter(getApplicationContext(),strokeList);
        listView2.setAdapter(adapter2);

        btn_userinfo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new STManage.BackgroundTask().execute();
            }
        });
        btn_stock.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                new STManage.BackgroundTask2().execute();
            }
        });
        btn_sales.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(STManage.this,Sale.class);
                startActivity(intent);
            }
        });
        btn_home.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(STManage.this,AdminMenu.class);
                startActivity(intent);
            }
        });

        try{
            JSONObject jsonObject = new JSONObject(intent.getStringExtra("strokeList"));
            JSONArray jsonArray = jsonObject.getJSONArray("response");
            int count = 0;
            String strokeName,strokePrice,strokeQuantity;
            while(count < jsonArray.length()){
                JSONObject object = jsonArray.getJSONObject(count);
                strokeName = object.getString("strokeName");
                strokePrice = object.getString("strokePrice");
                strokeQuantity = object.getString("strokeQuantity");

                Stroke stroke = new Stroke(strokeName,strokePrice,strokeQuantity);
                strokeList.add(stroke);
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
            Intent intent = new Intent(STManage.this, Management.class);
            intent.putExtra("userList", result);
            STManage.this.startActivity(intent);
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
            Intent intent = new Intent(STManage.this, STManage.class);
            intent.putExtra("strokeList", result);
            STManage.this.startActivity(intent);
        }
    }
}
