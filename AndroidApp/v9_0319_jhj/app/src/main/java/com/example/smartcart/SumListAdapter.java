package com.example.smartcart;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

public class SumListAdapter extends BaseAdapter {
    private Context context4;
    private List<Sum> sumList;

    public SumListAdapter(Context context, List<Sum>sumList){
        this.context4 = context;
        this.sumList = sumList;
    }
    @Override
    public int getCount() {
        return sumList.size();
    }

    @Override
    public Object getItem(int i) {
        return sumList.get(i);
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        View v = View.inflate(context4,R.layout.sum,null);
        TextView product = (TextView)v.findViewById(R.id.product);
        TextView price = (TextView)v.findViewById(R.id.price);
        TextView buydate = (TextView)v.findViewById(R.id.buydate);

        product.setText(sumList.get(i).getProduct());
        price.setText(sumList.get(i).getProduct());
        buydate.setText(sumList.get(i).getBuydate());

        v.setTag(sumList.get(i).getProduct());
        return v;
    }
}
