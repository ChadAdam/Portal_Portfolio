package com.demo.weather;

import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.LoaderManager;
import android.support.v4.content.CursorLoader;
import android.support.v4.content.Loader;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ProgressBar;

import com.demo.weather.sync.SyncUtils;
import com.demo.weather.utils.PreferenceUtils;
import com.demo.weather.utils.WeatherContract;


public class MainActivity extends AppCompatActivity implements WeatherAdapter.WeatherAdapterOnClickHandler ,
        LoaderManager.LoaderCallbacks<Cursor>  {

    private RecyclerView mWeatherRV;
   // private TextView mErrorTV;
    private ProgressBar mLoading;
    private WeatherAdapter mWeatherAdapter;
    private final int LOADERID = 1;
    private final String QUERYEXTRAID = "q";

    private int mPosition = RecyclerView.NO_POSITION;

    public static final String[] MAIN_FORECAST_PROJECTION = {
            WeatherContract.WeatherEntry.COLUMN_DATE,
            WeatherContract.WeatherEntry.COLUMN_MAX_TEMP,
            WeatherContract.WeatherEntry.COLUMN_MIN_TEMP,
            WeatherContract.WeatherEntry.COLUMN_HUMIDITY,

            WeatherContract.WeatherEntry.COLUMN_WEATHER_ID,
    };

    public static final int INDEX_WEATHER_DATE = 0;
    public static final int INDEX_WEATHER_MAX_TEMP = 1;
    public static final int INDEX_WEATHER_MIN_TEMP = 2;
    public static final int INDEX_WEATHER_HUM=3;
    public static final int INDEX_WEATHER_CONDITION_ID = 4;

    private static final int ID_FORECAST_LOADER = 44;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_weather);
        getSupportActionBar().setElevation(0f);
        //FakeDataUtils.insertFakeData(this);

    mWeatherRV =  (RecyclerView) findViewById(R.id.rv_weather_data);
   // mErrorTV = (TextView) findViewById(R.id.tv_weather_error);
    mLoading =  (ProgressBar) findViewById(R.id.progress_bar);
    //TextView mDetailTV = (TextView) findViewById(R.id.tv_detail);

    LinearLayoutManager layoutManager = new LinearLayoutManager(this , LinearLayoutManager.VERTICAL, false);
    mWeatherRV.setLayoutManager(layoutManager);
    //mWeatherRV.setHasFixedSize(true);
    mWeatherAdapter = new WeatherAdapter(this,this);
    mWeatherRV.setAdapter(mWeatherAdapter);
    showLoading();
    //if(savedInstanceState!=null){
      //  String query= (String) savedInstanceState.get(QUERYEXTRAID);
        //mDetailTV.setText(query);
    //}
    //LoaderCallbacks<ArrayList<String>> callback = MainActivity.this;
    getSupportLoaderManager().initLoader(ID_FORECAST_LOADER, null, this);
    //PreferenceManager.getDefaultSharedPreferences(this).registerOnSharedPreferenceChangeListener(this);

        SyncUtils.initialize(this);


    }

    private void errorVisible(){
            mWeatherRV.setVisibility(View.INVISIBLE);
          //  mErrorTV.setVisibility(View.VISIBLE);
    }
    private void showLoading() {

        mWeatherRV.setVisibility(View.INVISIBLE);

       // mErrorTV.setVisibility(View.VISIBLE);

        mLoading.setVisibility(View.VISIBLE);
    }
    private void messageVisible(){
        //mErrorTV.setVisibility(View.INVISIBLE);
        mWeatherRV.setVisibility(View.VISIBLE);
    }

    private void showWeatherDataView(){
        mLoading.setVisibility(View.INVISIBLE);
        mWeatherRV.setVisibility(View.VISIBLE);

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu){
        getMenuInflater().inflate(R.menu.main_menu, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item){
        int idclicked = item.getItemId();
      //  if(idclicked==R.id.action_refresh){

        //    mWeatherAdapter.setWeatherData(null);
          //  getSupportLoaderManager().restartLoader(LOADERID, null , this);
            //return true;
        //}
        //if(idclicked==R.id.action_map){
          //  openMap();
            //return true;
        //}
        if(idclicked==R.id.action_settings){
            Context c = this;
            Intent i = new Intent(c ,SettingsActivity.class);
            startActivity(i);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    private void  openMap(){

        String address =  PreferenceUtils.getPreferredWeatherLocation(this);
        Uri.Builder builder = new Uri.Builder();
        //Uri geo = builder.scheme("geo").path("0,0").appendQueryParameter("q", address).build();
        Uri geo =  Uri.parse("geo:0,0?q=" + address);

        Intent i = new Intent(Intent.ACTION_VIEW);
        i.setData(geo);
        i.setPackage("com.google.android.apps.maps");
        if(i.resolveActivity(getPackageManager())!=null){
            startActivity(i);
        }
        else{ Log.d("ERROR", "Couldn't call " + geo.toString() + ", no receiving apps installed!");}
    }


    @Override
    public void onClick(long weatherLine) {
        Context c = this;
        //Toast.makeText(c, weatherLine, Toast.LENGTH_LONG).show();
        Intent i = new Intent(c , DetailActivity.class);
        //i.putExtra(Intent.EXTRA_TEXT,weatherLine);
        Uri uriForDateClicked = WeatherContract.WeatherEntry.buildWeatherUriWithDate(weatherLine);
        i.setData(uriForDateClicked);
        startActivity(i);

    }



    @SuppressLint("StaticFieldLeak")
    @NonNull
    @Override
    public Loader<Cursor> onCreateLoader(int i, @Nullable final Bundle bundle) {
        switch (i) {

//
            case ID_FORECAST_LOADER:

                Uri forecastQueryUri = WeatherContract.WeatherEntry.CONTENT_URI;

                String sortOrder = WeatherContract.WeatherEntry.COLUMN_DATE + " ASC";

                String selection = WeatherContract.WeatherEntry.getSqlSelectForTodayOnwards();

                return new CursorLoader(this,
                        forecastQueryUri,
                        MAIN_FORECAST_PROJECTION,
                        selection,
                        null,
                        sortOrder);

            default:
                throw new RuntimeException("Loader Not Implemented: " + i);
        }
    }

    @Override
    public void onLoadFinished(@NonNull Loader<Cursor> loader, Cursor s) {
        mWeatherAdapter.swapCursor(s);

        if ( mPosition== RecyclerView.NO_POSITION) mPosition = 0;

        mWeatherRV.smoothScrollToPosition(mPosition);


        if (s.getCount() != 0) showWeatherDataView();
    }

    @Override
    public void onLoaderReset(@NonNull Loader<Cursor> loader) {
        mWeatherAdapter.swapCursor(null);

    }


    //@Override
    //public void onSharedPreferenceChanged(SharedPreferences sharedPreferences, String s) {
     //  PREFERENCES_HAVE_BEEN_UPDATED = true;

    //}

    //@Override
    //protected void onStart() {
      //  super.onStart();
        //if(PREFERENCES_HAVE_BEEN_UPDATED){
          //  getSupportLoaderManager().restartLoader(LOADERID,null , this);
            //PREFERENCES_HAVE_BEEN_UPDATED = false;
        //}

    //}

   // @Override
    //protected void onDestroy() {
      //  super.onDestroy();
        //PreferenceManager.getDefaultSharedPreferences(this).unregisterOnSharedPreferenceChangeListener(this);
    //}
}