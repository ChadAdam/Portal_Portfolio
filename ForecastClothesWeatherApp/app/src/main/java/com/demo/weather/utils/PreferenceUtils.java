package com.demo.weather.utils;

import android.content.Context;
import android.content.SharedPreferences;
import android.support.v7.preference.PreferenceManager;
import android.widget.Toast;

import com.demo.weather.R.*;

import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

public class PreferenceUtils {

    public static final String PREF_CITY_NAME = "city_name";



    public static final String PREF_COORD_LAT = "coord_lat";
    public static final String PREF_COORD_LONG = "coord_long";


    private static final String DEFAULT_WEATHER_LOCATION = "New York City";
    private static final double[] DEFAULT_WEATHER_COORDINATES = {40.7128, 74.0060};


    static public void setLocationDetails(Context c, double lat, double lon) {
        SharedPreferences sp = android.preference.PreferenceManager.getDefaultSharedPreferences(c);
        SharedPreferences.Editor editor = sp.edit();

        editor.putLong(PREF_COORD_LAT, Double.doubleToRawLongBits(lat));
        editor.putLong(PREF_COORD_LONG, Double.doubleToRawLongBits(lon));
        editor.apply();
    }
    static public void setDefClothes(Context c , int head , int body , int arms , int legs){
        SharedPreferences sp = android.preference.PreferenceManager.getDefaultSharedPreferences(c);
        SharedPreferences.Editor editor = sp.edit();
        editor.putInt("h", head);
        editor.putInt("b", body);
        editor.putInt("a", arms);
        editor.putInt("l", legs);
        editor.apply();

    }
    static public void resetDefClothes(Context c){
        SharedPreferences sp = android.preference.PreferenceManager.getDefaultSharedPreferences(c);
        SharedPreferences.Editor editor = sp.edit();
        editor.remove("h");
        editor.remove("b");
        editor.remove("a");
        editor.remove("l");
        editor.apply();

    }

    static public String setSeason(Context c , String date){
        int indexStart = date.indexOf(",")+2;
        String month = date.substring(indexStart);
        DateFormat df = new SimpleDateFormat("MMM");
        DateFormat dateFormat = new SimpleDateFormat("M");
        try {
            Date month_date = df.parse(month);
            String newDateString = dateFormat.format(month_date);

           double season =  DateUtils.getSeason(c , Integer.valueOf(newDateString));
            return getStringSeason( c, season);

        } catch (ParseException e) {
            e.printStackTrace();
        }
        return null;
    }

public static String getStringSeason(Context c, double season){
    if(season >=1 && season<2){
        Toast.makeText(c , "Fall" , Toast.LENGTH_LONG).show();
        return "Fall";

    }
    else if (season>=2 && season<3){Toast.makeText(c , "Winter" , Toast.LENGTH_LONG).show();
    return "Winter";}
    else if (season>=3 && season<4){Toast.makeText(c , "Spring", Toast.LENGTH_LONG).show();
    return  "Spring";}
    else if (season>=4){Toast.makeText(c , "Summer", Toast.LENGTH_LONG).show();
    return "Summer";}
    return null;
}






    static public void resetLocationCoordinates(Context c) {
        SharedPreferences sp = android.preference.PreferenceManager.getDefaultSharedPreferences(c);
        SharedPreferences.Editor editor = sp.edit();

        editor.remove(PREF_COORD_LAT);
        editor.remove(PREF_COORD_LONG);
        editor.apply();
    }



    public static String getPreferredWeatherLocation(Context context) {

        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(context);
        String val = sharedPreferences.getString(context.getString(string.edit_text_key), DEFAULT_WEATHER_LOCATION);
        return val;



    }
    public static ArrayList<Integer> getDefClothes(Context context){
        ArrayList<Integer> arr = new ArrayList<Integer>();
        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(context);
        arr.add(sharedPreferences.getInt("h" , 0));
        arr.add(sharedPreferences.getInt("b" , 0));
        arr.add(sharedPreferences.getInt("a" , 0));
        arr.add(sharedPreferences.getInt("l" , 0));
        return  arr;
    }


    public static boolean isMetric(Context context) {

        SharedPreferences sharedPreferences = PreferenceManager.getDefaultSharedPreferences(context);
        String val = sharedPreferences.getString(context.getString(string.list_key), "");
        if(val.equals("Cels")) return true;
        return false;
    }


    public static double[] getLocationCoordinates(Context context) {
        SharedPreferences sp = android.preference.PreferenceManager.getDefaultSharedPreferences(context);

        double[] preferredCoordinates = new double[2];


        preferredCoordinates[0] = Double
                .longBitsToDouble(sp.getLong(PREF_COORD_LAT, Double.doubleToRawLongBits(0.0)));
        preferredCoordinates[1] = Double
                .longBitsToDouble(sp.getLong(PREF_COORD_LONG, Double.doubleToRawLongBits(0.0)));

        return preferredCoordinates;
    }


    public static boolean isLocationLatLonAvailable(Context context) {
        SharedPreferences sp = android.preference.PreferenceManager.getDefaultSharedPreferences(context);

        boolean spContainLatitude = sp.contains(PREF_COORD_LAT);
        boolean spContainLongitude = sp.contains(PREF_COORD_LONG);

        boolean spContainBothLatitudeAndLongitude = false;
        if (spContainLatitude && spContainLongitude) {
            spContainBothLatitudeAndLongitude = true;
        }

        return spContainBothLatitudeAndLongitude;
    }




    public static long getLastNotificationTimeInMillis(Context context) {

        String lastNotificationKey = "get_last_prefer";


        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(context);


        long lastNotificationTime = sp.getLong(lastNotificationKey, 0);

        return lastNotificationTime;
    }

    public static void saveLastNotificationTime(Context context, long timeOfNotification) {
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(context);
        SharedPreferences.Editor editor = sp.edit();
        String lastNotificationKey = "get_last_prefer";
        editor.putLong(lastNotificationKey, timeOfNotification);
        editor.apply();
    }
    public static boolean areNotificationsEnabled(Context context){
        String displayNotificationKey = "enable_notifications";
        boolean shouldDisplayNotificationsByDefault = true;
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(context);
        boolean shouldDisplayNotifications = sp
                .getBoolean(displayNotificationKey, shouldDisplayNotificationsByDefault);

        return shouldDisplayNotifications;
    }
    public static long getEllapsedTimeSinceLastNotification(Context context) {
        long lastNotificationTimeMillis =
                PreferenceUtils.getLastNotificationTimeInMillis(context);
        long timeSinceLastNotification = System.currentTimeMillis() - lastNotificationTimeMillis;
        return timeSinceLastNotification;
    }
}
