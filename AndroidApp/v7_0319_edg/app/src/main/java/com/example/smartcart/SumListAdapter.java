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
        TextView sum = (TextView)v.findViewById(R.id.sumTotal);

        sum.setText(sumList.get(i).getSum());

        v.setTag(sumList.get(i).getSum());
        return v;
    }
}
