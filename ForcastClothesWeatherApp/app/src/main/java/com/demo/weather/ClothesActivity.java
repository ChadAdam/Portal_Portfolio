package com.demo.weather;

import android.content.Context;
import android.content.Intent;
import android.media.Image;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v7.app.AppCompatActivity;
import android.view.GestureDetector;
import android.view.Menu;
import android.view.MenuItem;
import android.view.MotionEvent;
import android.view.View;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.demo.weather.utils.MathWeatherUtils;

import java.util.ArrayList;

public class ClothesActivity extends AppCompatActivity implements GestureDetector.OnGestureListener {
    ImageView mHead_Reg;
    ImageView mHead_Lite;
    ImageView mHead_Blue;

    ImageView mBody_Reg;
    ImageView mBody_Lite;
    ImageView mBody_Blue;

    // Put Arms here
    ImageView mArmsR_Reg;
    ImageView mArmsR_Lite;
    ImageView mArmsR_Blue;

    ImageView mArmsL_Reg;
    ImageView mArmsL_Lite;
    ImageView mArmsL_Blue;

    ImageView mLegs_Reg;
    ImageView mLegs_Lite;
    ImageView mLegs_Blue;


    FrameLayout mFrameLayout;
    TextView mDate_TV;
    TextView mInfo_TV;
    private static double temp2Compare;
    private static final int ERROR_MATH_UTIL = -1000;
    private GestureDetector gestureDetector;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.clothes_activity);
        mHead_Reg= (ImageView) findViewById(R.id.outline_head_reg);
        mHead_Lite= (ImageView) findViewById(R.id.outline_head_lite);
        mHead_Blue = (ImageView)findViewById(R.id.outline_head_blue);

        mBody_Reg = (ImageView)findViewById(R.id.body_reg);
        mBody_Lite= (ImageView)findViewById(R.id.body_highlite);
        mBody_Blue = (ImageView) findViewById(R.id.body_blue);

        // Input Arms
        mArmsL_Reg= (ImageView)findViewById(R.id.left_arms_reg);
        mArmsL_Lite = (ImageView)findViewById(R.id.left_arms_highlite);
        mArmsL_Blue = (ImageView)findViewById(R.id.left_arms_blue);

        mArmsR_Reg= (ImageView)findViewById(R.id.right_arms_reg);
        mArmsR_Lite = (ImageView)findViewById(R.id.right_arms_highlite);
        mArmsR_Blue = (ImageView)findViewById(R.id.right_arms_blue);

        mLegs_Reg = (ImageView)findViewById(R.id.outline_legs);
        mLegs_Lite = (ImageView)findViewById(R.id.outline_legs_highlite);
        mLegs_Blue = (ImageView)findViewById(R.id.outline_legs_blue);

        mFrameLayout= (FrameLayout)  findViewById(R.id.root_view_head);
        mDate_TV = (TextView)  findViewById(R.id.date_figure_tv);
        mInfo_TV = (TextView) findViewById(R.id.tv_info);


        String extra = getIntent().getStringExtra("Date");
        final double temp = getIntent().getDoubleExtra("temp",-1);
        final double humid = getIntent().getDoubleExtra("humid",-1);
        final double wind = getIntent().getDoubleExtra("wind", -1);

        if(extra!=null) {
            mDate_TV.setText(extra);
        }

        if(temp!=-1 && humid !=-1 && wind!=-1) {
            double chilledTemp = MathWeatherUtils.applyWindChill(temp, wind);
            double humidTemp = MathWeatherUtils.applyHumid(temp, humid);
            if(chilledTemp == ERROR_MATH_UTIL && humidTemp==ERROR_MATH_UTIL){
                temp2Compare = temp;
            }
            else if (chilledTemp==ERROR_MATH_UTIL){
                temp2Compare= humidTemp;
            }
            else{
                temp2Compare = chilledTemp;
            }
            //Toast.makeText(getApplicationContext(), String.valueOf(temp2Compare), Toast.LENGTH_SHORT).show();
        }
        //else {Toast.makeText(getApplicationContext(), "error", Toast.LENGTH_SHORT).show();}

        mHead_Lite.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                //mHead_Lite.setVisibility(View.VISIBLE);
                if(temp!=-1 && humid !=-1 && wind!=-1) {
                    double chilledTemp = MathWeatherUtils.applyWindChill(temp, wind);
                    double humidTemp = MathWeatherUtils.applyHumid(temp, humid);
                    if(chilledTemp == ERROR_MATH_UTIL && humidTemp==ERROR_MATH_UTIL){
                        temp2Compare = temp;
                    }
                    else if (chilledTemp==ERROR_MATH_UTIL){
                        temp2Compare= humidTemp;
                    }
                    else{
                        temp2Compare = chilledTemp;
                    }
                   // Toast.makeText(getApplicationContext(), String.valueOf(temp2Compare), Toast.LENGTH_SHORT).show();
                }
               // else {Toast.makeText(getApplicationContext(), "error", Toast.LENGTH_SHORT).show();}
            }
        });
        mFrameLayout.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                highlightClick();
            }
        });
        gestureDetector = new GestureDetector(this);
    }

    @Override
    protected void onPostResume() {
        //Toast.makeText(this, "tem2compare = "+String.valueOf(temp2Compare), Toast.LENGTH_LONG).show();
        ArrayList<Integer> clothes_indicator = MathWeatherUtils.getWeatherIntArr(getApplicationContext(), temp2Compare);
        if(clothes_indicator != null){
        //head
        switch (clothes_indicator.get(0)){
            case 1:
                mHead_Blue.setVisibility(View.VISIBLE); // Change this. More clothes should == blue
                break;
            case 0:
                mHead_Lite.setVisibility(View.INVISIBLE);
                mHead_Blue.setVisibility(View.INVISIBLE);
                break;
            case -1:
                mHead_Lite.setVisibility(View.VISIBLE);
        }
            switch (clothes_indicator.get(1)){
                case 1:
                    mBody_Blue.setVisibility(View.VISIBLE); // Change this. More clothes should == blue
                    mInfo_TV.setTextColor(getResources().getColor(R.color.blue));
                    break;
                case 0:
                    mBody_Lite.setVisibility(View.INVISIBLE);
                    mBody_Blue.setVisibility(View.INVISIBLE);
                    mInfo_TV.setTextColor(getResources().getColor(R.color.tan));
                    break;
                case -1:
                    mBody_Lite.setVisibility(View.VISIBLE);
                    mInfo_TV.setTextColor(getResources().getColor(R.color.light_red));
            }

            // Input arms
            switch (clothes_indicator.get(2)){
                case 1:
                    mArmsR_Blue.setVisibility(View.VISIBLE);
                    mArmsL_Blue.setVisibility(View.VISIBLE);// Change this. More clothes should == blue
                    break;
                case 0:
                    mArmsR_Lite.setVisibility(View.INVISIBLE);
                    mArmsL_Lite.setVisibility(View.INVISIBLE);

                    mArmsL_Blue.setVisibility(View.INVISIBLE);
                    mArmsR_Blue.setVisibility(View.INVISIBLE);
                    
                    break;
                case -1:
                    mArmsR_Lite.setVisibility(View.VISIBLE);
                    mArmsL_Lite.setVisibility(View.VISIBLE);
            }

            switch (clothes_indicator.get(3)){
                case 1:
                    mLegs_Blue.setVisibility(View.VISIBLE); // Change this. More clothes should == blue
                    break;
                case 0:
                    mLegs_Lite.setVisibility(View.INVISIBLE);
                    mLegs_Blue.setVisibility(View.INVISIBLE);
                    break;
                case -1:
                    mLegs_Lite.setVisibility(View.VISIBLE);
            }
        //Toast.makeText(getApplicationContext(), clothes_indicator.get(0).toString()+" 1 = more clothes , 0 = perfect , -1 = less clothes", Toast.LENGTH_SHORT).show();




        }
        else {

            Toast.makeText(getApplicationContext(), "Clothes need to be set ", Toast.LENGTH_SHORT).show();
            Intent i = new Intent(this , ImagePreferenceActivity.class);
            startActivity(i);
        }
        super.onPostResume();
    }

    public void highlightClick(){
        if(mHead_Lite.getVisibility() == View.INVISIBLE){
        mHead_Lite.setVisibility(View.VISIBLE); }
        else{mHead_Lite.setVisibility(View.INVISIBLE);}
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu){
        getMenuInflater().inflate(R.menu.clothes_menu, menu);
        // MenuItem menuItem1 = menu.findItem(R.id.action_share);
        //menuItem.setIntent(createShareForecastIntent());
        return true;

    }
    @Override
    public boolean onOptionsItemSelected(MenuItem item){
        int id = item.getItemId();
        if(id ==R.id.clothes_action_settings){
            Intent i = new Intent(this , ImagePreferenceActivity.class);
            i.putExtra("pref_date" , mDate_TV.getText());

            startActivity(i);
            return true;
        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public boolean onDown(MotionEvent motionEvent) {
        return false;
    }

    @Override
    public void onShowPress(MotionEvent motionEvent) {

    }

    @Override
    public boolean onSingleTapUp(MotionEvent motionEvent) {
        return false;
    }

    @Override
    public boolean onScroll(MotionEvent motionEvent, MotionEvent motionEvent1, float v, float v1) {
        return false;
    }

    @Override
    public void onLongPress(MotionEvent motionEvent) {

    }

    @Override
    public boolean onFling(MotionEvent downEvent, MotionEvent moveEvent, float vX, float vY) {
        boolean result = false;
        final int SWIPE_THRESHOLD = 100;
        final int SWIPE_VELOCITY_THRESHOLD = 100;
        float diffY = moveEvent.getY() - downEvent.getY();
        float diffX = moveEvent.getX() - downEvent.getX();
        if (Math.abs(diffX) > Math.abs(diffY)) {
            // right or left swipe
            if (Math.abs(diffX)> SWIPE_THRESHOLD && Math.abs(vX) > SWIPE_VELOCITY_THRESHOLD) {
                if (diffX > 0) {
                    onSwipeRight();
                } else {
                    onSwipeLeft();
                }
                result = true;
            }
        } else {
            // up or down swipe
            if (Math.abs(diffY) > SWIPE_THRESHOLD && Math.abs(vY)> SWIPE_VELOCITY_THRESHOLD) {
                if (diffY > 0) {
                    onSwipeBottom();
                } else {
                    onSwipeTop();
                }
                result = true;
            }
        }

        return result;
    }
    private void onSwipeTop() {
        //Toast.makeText(this, "Swipe Left: Return to Main Menu\n Swipe Right: Clothes Visualizer", Toast.LENGTH_LONG).show();
    }

    private void onSwipeBottom() {
       // Toast.makeText(this, "Swipe Bottom", Toast.LENGTH_LONG).show();
    }


    private void onSwipeLeft() {
        Context c = this;
        Intent i = new Intent(c , MainActivity.class);
        startActivity(i);

    }

    private void onSwipeRight() {


    }
    @Override
    public boolean onTouchEvent(MotionEvent event) {
        gestureDetector.onTouchEvent(event);
        return super.onTouchEvent(event);
    }
}
