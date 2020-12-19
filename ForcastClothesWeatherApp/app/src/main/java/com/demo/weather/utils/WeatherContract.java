package com.demo.weather.utils;

import android.net.Uri;
import android.provider.BaseColumns;

import java.util.concurrent.TimeUnit;



public class WeatherContract {


    public static final String CONTENT_AUTHORITY = "com.demo.weather";


    public static final Uri BASE_CONTENT_URI = Uri.parse("content://" + CONTENT_AUTHORITY);

    public static final String PATH_WEATHER = "weather";

    public static final class WeatherEntry implements BaseColumns {


        public static final Uri CONTENT_URI = BASE_CONTENT_URI.buildUpon()
                .appendPath(PATH_WEATHER)
                .build();


        public static final String TABLE_NAME = "weather";


        public static final String COLUMN_DATE = "date";

        public static final String COLUMN_WEATHER_ID = "weather_id";


        public static final String COLUMN_MIN_TEMP = "min";
        public static final String COLUMN_MAX_TEMP = "max";


        public static final String COLUMN_HUMIDITY = "humidity";


        public static final String COLUMN_PRESSURE = "pressure";


        public static final String COLUMN_WIND_SPEED = "wind";


        public static final String COLUMN_DEGREES = "degrees";


        public static Uri buildWeatherUriWithDate(long date) {
            return CONTENT_URI.buildUpon()
                    .appendPath(Long.toString(date))
                    .build();
        }

        public static long normalizeDate(long date) {
            final long DAY_IN_MILLIS = TimeUnit.DAYS.toMillis(1);
            long daysSinceEpoch = elapsedDaysSinceEpoch(date);
            long millisFromEpochToTodayAtMidnightUtc = daysSinceEpoch * DAY_IN_MILLIS;
            return millisFromEpochToTodayAtMidnightUtc;
        }
        private static long elapsedDaysSinceEpoch(long utcDate) {
            return TimeUnit.MILLISECONDS.toDays(utcDate);
        }




        public static String getSqlSelectForTodayOnwards() {
            long normalizedUtcNow = normalizeDate(System.currentTimeMillis());
            return WeatherContract.WeatherEntry.COLUMN_DATE + " >= " + normalizedUtcNow;
        }
    }
}