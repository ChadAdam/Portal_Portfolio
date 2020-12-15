package edu.gatech.seclass.wordfind6300;

import android.app.ActionBar;
import android.content.Context;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import androidx.annotation.Px;
import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Map;
import java.util.TreeMap;

public class WordCounter extends AppCompatActivity {
    Button wordCounterExitButton;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.word_counter);

        displayWordCount();
        wordCounterExitButton = (Button) findViewById(R.id.buttonWordCounterExit);

        wordCounterExitButton.setOnClickListener((v) -> {
            Intent intent = new Intent(this, Game.class);
            startActivity(intent);
        });


    }
    void displayWordCount(){
        ArrayList<String> wordCount = readWordCount();
        Collections.reverse(wordCount); //Show the newest history first=
        TableLayout th1 = (TableLayout)findViewById(R.id.tableHeader);
        TableRow tHead = new TableRow(this);
        tHead.setId(10+1);
        //tHead.setBackgroundColor(Color.WHITE);
        tHead.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ActionBar.LayoutParams.WRAP_CONTENT));
        TextView word = new TextView(this);
        word.setId(20+1);
        word.setText("Word");
        word.setBackgroundColor(Color.parseColor("#5d9cd0"));
        word.setTypeface(Typeface.DEFAULT_BOLD);
        word.setPadding(5, 1, 5, 1);
        tHead.addView(word);
        TextView score = new TextView(this);
        score.setId(21+1);
        score.setText("Frequency");
        score.setBackgroundColor(Color.parseColor("#5d9cd0"));
        score.setTypeface(Typeface.DEFAULT_BOLD);
        score.setPadding(5, 1, 5, 1);
        tHead.addView(score);
        th1.addView(tHead);


        TableLayout t1 = (TableLayout)findViewById(R.id.tableLayout);

        Map<Integer,ArrayList<Integer>> sortHistory = new TreeMap<Integer,ArrayList<Integer>>(Collections.reverseOrder());
        for(int i = 0; i < wordCount.size(); i++) {
            String[] historyEntry = wordCount.get(i).split(";");
            Integer count = Integer.parseInt(historyEntry[1]);
            ArrayList<Integer> idList =sortHistory.get(count);
            if (idList == null) {
                idList = new ArrayList<Integer>();
                idList.add(i);
                sortHistory.put(count, idList);
            } else {
                idList.add(i);
            }
        }

        boolean alt=false;
        int id = 22;
        //for(int i = 0; i < wordCount.size(); i++){
        int mapIndex=0;
        for (Map.Entry<Integer,ArrayList<Integer>> entry : sortHistory.entrySet()) {
            ArrayList<Integer> idList = entry.getValue();
            for (int l=0; l<idList.size(); l++) {
                mapIndex = idList.get(l);
                String[] historyEntry = wordCount.get(mapIndex).split(";");
                TableRow trow = new TableRow(this);
                if (alt == true) {
                    trow.setBackgroundColor(Color.LTGRAY);
                    alt = false;
                } else {
                    alt = true;
                }
                trow.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ActionBar.LayoutParams.WRAP_CONTENT));
                TextView fscore1 = new TextView(this);
                fscore1.setId(id++);
                fscore1.setText(historyEntry[0]);
                trow.addView(fscore1);
                TextView rcount1 = new TextView(this);
                rcount1.setId(id++);
                rcount1.setText(historyEntry[1]);
                trow.addView(rcount1);
                t1.addView(trow);
            }
        }
    }

    public void clearWordCount(){
        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
        db.execSQL("DELETE FROM WordCount");
        db.close();
    }

    public void writeWordCount(String word, int score){
        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
        StringBuilder sb = new StringBuilder("INSERT INTO WordCount VALUES ('");
        sb.append(word);
        sb.append("',");
        sb.append(score);
        sb.append(");");
        db.execSQL(sb.toString());
        db.close();
    }
    public ArrayList<String> readWordCount(){
        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
        Cursor res = db.rawQuery("SELECT * FROM WordCount",null);
        ArrayList<String> wordCount = new ArrayList<String>();
        if(res.getCount() != 0){
            while (res.moveToNext()){
                StringBuilder sb = new StringBuilder();
                sb.append(res.getString(0));
                sb.append(";");
                sb.append(res.getInt(1));
                wordCount.add(sb.toString());
            }
        }
        db.close();
        return wordCount;
    }
}
