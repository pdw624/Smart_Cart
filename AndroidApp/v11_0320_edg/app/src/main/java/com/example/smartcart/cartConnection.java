package com.example.smartcart;

import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

public class cartConnection extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cart_connection);

        //1번카트
        Button button1 = (Button)findViewById(R.id.cart_btn1);
        button1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                show1();
            }
        });

        //2번카트
        Button button2 = (Button)findViewById(R.id.cart_btn2);
        button2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                show2();
            }
        });

        //3번카트
        Button button3 = (Button)findViewById(R.id.cart_btn3);
        button3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                show3();
            }
        });

        //4번카트
        Button button4 = (Button)findViewById(R.id.cart_btn4);
        button4.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                show4();
            }
        });
    }

    //1번 카트
    void show1()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("카트 연결");
        builder.setMessage("1번 카트를 연결하시겠습니까?");
        builder.setPositiveButton("예",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(),"1번 카트와 연결하였습니다.",Toast.LENGTH_SHORT).show();
                    }
                });
        builder.setNegativeButton("아니오",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(),"1번 카트를 취소하였습니다.",Toast.LENGTH_SHORT).show();
                    }
                });
        builder.show();
    }

    //2번 카트
    void show2()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("카트 연결");
        builder.setMessage("2번 카트를 연결하시겠습니까?");
        builder.setPositiveButton("예",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(),"2번 카트와 연결하였습니다.",Toast.LENGTH_SHORT).show();
                    }
                });
        builder.setNegativeButton("아니오",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(),"2번 카트를 취소하였습니다.",Toast.LENGTH_SHORT).show();
                    }
                });
        builder.show();
    }

    //3번카트
    void show3()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("카트 연결");
        builder.setMessage("3번 카트를 연결하시겠습니까?");
        builder.setPositiveButton("예",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(), "3번 카트와 연결하였습니다.", Toast.LENGTH_SHORT).show();
                    }
                });
        builder.setNegativeButton("아니오",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(), "3번 카트를 취소하였습니다", Toast.LENGTH_SHORT).show();
                    }
                });
        builder.show();

    }

    //4번 카트
    void show4()
    {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("카트 연결");
        builder.setMessage("4번 카트를 연결하시겠습니까?");
        builder.setPositiveButton("예",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(), "4번 카트와 연결하였습니다.", Toast.LENGTH_SHORT).show();
                    }
                });
        builder.setNegativeButton("아니오",
                new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(getApplicationContext(), "4번 카트를 취소하였습니다.", Toast.LENGTH_SHORT).show();
                    }
                });
        builder.show();
    }
}
