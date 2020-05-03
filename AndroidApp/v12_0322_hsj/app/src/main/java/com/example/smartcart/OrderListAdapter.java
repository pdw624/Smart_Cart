package com.example.smartcart;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

public class OrderListAdapter extends BaseAdapter {
    private Context context3;
    private List<Order> orderList;

    public OrderListAdapter(Context context, List<Order>orderList){
        this.context3 = context;
        this.orderList = orderList;
    }
    @Override
    public int getCount() {
        return orderList.size();
    }

    @Override
    public Object getItem(int i) {
        return orderList.get(i);
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        View v = View.inflate(context3,R.layout.order,null);
        TextView product = (TextView)v.findViewById(R.id.product);
        TextView price = (TextView)v.findViewById(R.id.price);
        TextView buydate = (TextView)v.findViewById(R.id.buydate);

        product.setText(orderList.get(i).getProduct());
        price.setText(orderList.get(i).getPrice());
        buydate.setText(orderList.get(i).getBuydate());

        v.setTag(orderList.get(i).getProduct());
        return v;
    }
}
