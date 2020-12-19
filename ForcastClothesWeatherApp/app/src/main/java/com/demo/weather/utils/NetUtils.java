package com.demo.weather.utils;

import android.content.Context;
import android.net.Uri;
import android.util.Log;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.Scanner;

public final class NetUtils {
    private static final String TAG = NetUtils.class.getSimpleName();
    //http://api.openweathermap.org/data/2.5/forecast?q=London,uk&appid=dce03d5b8fb545d127379db81b33c939
    private static final String APIKey="2fdaac186de11a5dcea4aa67a4567337";
    //private static final String WEATHER_URL = "http://api.openweathermap.org/data/2.5/weather";
    private static final String FORCAST_URL = "https://api.openweathermap.org/data/2.5/forecast";
            //?lat=35&lon=139&appid=2fdaac186de11a5dcea4aa67a4567337

    private static final String format = "json";

    private static final String units = "metric";

    private static final int numDays = 14;

    final static String CITYID_PARAM = "id";
    final static String CITY_PARAM = "q";

    final static String LAT_PARAM = "lat";
    final static String LON_PARAM = "lon";
    final static String FORMAT_PARAM = "mode";
    final static String UNITS_PARAM = "units";
    final static String DAYS_PARAM = "cnt";
    final static String KEY_PARAM = "appid";



    public static URL buildUrl(String locationQuery) {
        Uri builtUri = Uri.parse(FORCAST_URL).buildUpon()
                .appendQueryParameter(CITY_PARAM,locationQuery)
                .appendQueryParameter(KEY_PARAM,APIKey)
                .build();

        URL url = null;
        try {
            url = new URL(builtUri.toString());
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }

        return url;
    }


    public static URL buildUrl(Double lat, Double lon) {
        Uri builtUri = Uri.parse(FORCAST_URL).buildUpon()
                .appendQueryParameter(LAT_PARAM, String.valueOf(lat))
                .appendQueryParameter(LON_PARAM, String.valueOf(lon))
                .appendQueryParameter(KEY_PARAM,APIKey)
                .build();

        URL url = null;
        try {
            url = new URL(builtUri.toString());
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }

        return url;
    }


    public static String getResponseFromHttpUrl(URL url) throws IOException {
        HttpURLConnection urlConnection = (HttpURLConnection) url.openConnection();
        try {
            InputStream in = urlConnection.getInputStream();

            Scanner scanner = new Scanner(in);
            scanner.useDelimiter("\\A");

            boolean hasInput = scanner.hasNext();
            if (hasInput) {
                return scanner.next();
            } else {
                return null;
            }
        } finally {
            urlConnection.disconnect();
        }
    }


    public static URL getUrl(Context context) {
        if (PreferenceUtils.isLocationLatLonAvailable(context)) {
            double[] preferredCoordinates = PreferenceUtils.getLocationCoordinates(context);
            double latitude = preferredCoordinates[0];
            double longitude = preferredCoordinates[1];
            return buildUrlWithLatitudeLongitude(latitude, longitude);
        } else {
            String locationQuery = PreferenceUtils.getPreferredWeatherLocation(context);
            return buildUrlWithLocationQuery(locationQuery);
        }
    }


    private static URL buildUrlWithLatitudeLongitude(Double latitude, Double longitude) {
        Uri weatherQueryUri = Uri.parse(FORCAST_URL).buildUpon()
                .appendQueryParameter(LAT_PARAM, String.valueOf(latitude))
                .appendQueryParameter(LON_PARAM, String.valueOf(longitude))
                .appendQueryParameter(FORMAT_PARAM, format)
                .appendQueryParameter(UNITS_PARAM, units)
                .appendQueryParameter(DAYS_PARAM, Integer.toString(numDays))
                .appendQueryParameter(KEY_PARAM,APIKey)
                .build();

        try {
            URL weatherQueryUrl = new URL(weatherQueryUri.toString());
            Log.v(TAG, "URL: " + weatherQueryUrl);
            return weatherQueryUrl;
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return null;
        }
    }


    private static URL buildUrlWithLocationQuery(String locationQuery) {
        Uri weatherQueryUri = Uri.parse(FORCAST_URL).buildUpon()
                .appendQueryParameter(CITY_PARAM, locationQuery)
                .appendQueryParameter(FORMAT_PARAM, format)
                .appendQueryParameter(UNITS_PARAM, units)
                .appendQueryParameter(DAYS_PARAM, Integer.toString(numDays))
                .appendQueryParameter(KEY_PARAM,APIKey)
                .build();

        try {
            URL weatherQueryUrl = new URL(weatherQueryUri.toString());
            Log.v(TAG, "URL: " + weatherQueryUrl);
            return weatherQueryUrl;
        } catch (MalformedURLException e) {
            e.printStackTrace();
            return null;
        }
    }

}
