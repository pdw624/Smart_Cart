package com.example.smartcart;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

public class StrokeListAdapter extends BaseAdapter {
    private Context context2;
    private List<Stroke> strokeList;

    public StrokeListAdapter(Context context, List<Stroke>strokeList){
        this.context2 = context;
        this.strokeList = strokeList;
    }
    @Override
    public int getCount() {
        return strokeList.size();
    }

    @Override
    public Object getItem(int i) {
        return strokeList.get(i);
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        View v = View.inflate(context2,R.layout.stroke,null);
        TextView strokeName = (TextView)v.findViewById(R.id.strokeName);
        TextView strokePrice = (TextView)v.findViewById(R.id.strokePrice);
        TextView strokeQuantity = (TextView)v.findViewById(R.id.strokeQuantity);

        strokeName.setText(strokeList.get(i).getStrokeName());
        strokePrice.setText(strokeList.get(i).getStrokePrice());
        strokeQuantity.setText(strokeList.get(i).getStrokeQuantity());

        v.setTag(strokeList.get(i).getStrokeName());
        return v;
    }
}
