package com.example.smartcart;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.TextView;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

public class STManage extends AppCompatActivity {

    private ListView listView2;
    private StrokeListAdapter adapter2;
    private List<Stroke> strokeList;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_stmanage);
        Intent intent = getIntent();
        listView2=(ListView)findViewById(R.id.listView2);

        strokeList = new ArrayList<Stroke>();
        adapter2 = new StrokeListAdapter(getApplicationContext(),strokeList);
        listView2.setAdapter(adapter2);

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
        /*
        userList.add(new User("혁진","바보","ㄱㄷ","20"));
        userList.add(new User("혁진","바보","ㄱㄷ","20"));
        userList.add(new User("혁진","바보","ㄱㄷ","20"));
*/

    }
}
