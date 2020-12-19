package com.demo.weather.sync;

import android.content.ContentResolver;
import android.content.ContentValues;
import android.content.Context;

import com.demo.weather.utils.DateUtils;
import com.demo.weather.utils.NetUtils;
import com.demo.weather.utils.NotificationUtils;
import com.demo.weather.utils.OpenWeatherJsonUtils;
import com.demo.weather.utils.PreferenceUtils;
import com.demo.weather.utils.WeatherContract;

import java.net.URL;


public class SyncTask {
    synchronized public static void syncWeather(Context context){
        try{
            URL weatherRequestURL = NetUtils.getUrl(context);
            String jsonWeatherResponse = NetUtils.getResponseFromHttpUrl(weatherRequestURL);
            ContentValues[] weatherValues = OpenWeatherJsonUtils.getWeatherDataFromJson(context,jsonWeatherResponse);

            if (weatherValues != null && weatherValues.length != 0) {

                ContentResolver weatherContentResolver = context.getContentResolver();


                weatherContentResolver.delete(
                        WeatherContract.WeatherEntry.CONTENT_URI,
                        null,
                        null);


                weatherContentResolver.bulkInsert(
                        WeatherContract.WeatherEntry.CONTENT_URI,
                        weatherValues);

                boolean notificationEnabled = PreferenceUtils.areNotificationsEnabled(context);
                long timeSinceLastNotification = PreferenceUtils
                        .getEllapsedTimeSinceLastNotification(context);
                boolean oneDayPassedSinceLastNotification = false;

                if (timeSinceLastNotification >= DateUtils.DAY_IN_MILLIS) {
                    oneDayPassedSinceLastNotification = true;
                }
                if (notificationEnabled && oneDayPassedSinceLastNotification) {
                    NotificationUtils.notifyUserOfNewWeather(context);
                }

            }

        }
        catch (Exception e) {
            e.printStackTrace();
        }
    }
}
