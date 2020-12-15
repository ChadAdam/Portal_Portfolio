package edu.gatech.seclass.wordfind6300;

import androidx.appcompat.app.AppCompatActivity;

import android.app.ActionBar;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.Typeface;
import android.os.Bundle;
import android.text.InputType;
import android.view.Gravity;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

public class GameHistory extends AppCompatActivity {
    Button gameHistoryExitButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.game_history);

        displayHistory();


        gameHistoryExitButton = (Button) findViewById(R.id.buttonGameHistoryExit);

        gameHistoryExitButton.setOnClickListener((v) -> {
            Intent intent = new Intent(this, Game.class);
            startActivity(intent);
        });


    }
    void displayHistory(){
        ArrayList<String> history = readHistory();
        Collections.reverse(history); //Show the newest history first
        TableLayout th1 = (TableLayout)findViewById(R.id.tableHeader);
        TableRow tHead = new TableRow(this);


        tHead.setId(10+1);
        //tHead.setBackgroundColor(Color.WHITE);
        tHead.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ActionBar.LayoutParams.WRAP_CONTENT));
        addTextToTableLayoutHeader(20,"Score", tHead);
        addTextToTableLayoutHeader(21,"Words", tHead);
        addTextToTableLayoutHeader(22,"Resets", tHead);
        addTextToTableLayoutHeader(23,"Size", tHead);
        addTextToTableLayoutHeader(24,"Highest word", tHead);
        addTextToTableLayoutHeader(25,"Minutes", tHead);

        th1.addView(tHead);

        TableLayout t1 = (TableLayout)findViewById(R.id.tableLayout);

        Map<Integer,ArrayList<Integer>> sortHistory = new TreeMap<Integer,ArrayList<Integer>>(Collections.reverseOrder());
        for(int i = 0; i < history.size(); i++) {
            String[] historyEntry = history.get(i).split(";");
            Integer score = Integer.parseInt(historyEntry[0]);
            ArrayList<Integer> idList =sortHistory.get(score);
            if (idList == null) {
                idList = new ArrayList<Integer>();
                idList.add(i);
                sortHistory.put(score, idList);
            } else {
                idList.add(i);
            }
        }

        boolean alt=false;
        int id = 26;
        //for(int i = 0; i < history.size(); i++) {
        int mapIndex=0;
        for (Map.Entry<Integer,ArrayList<Integer>> entry : sortHistory.entrySet()) {
            ArrayList<Integer> idList = entry.getValue();
            for (int l=0; l<idList.size(); l++) {
                mapIndex=idList.get(l);
                String[] historyEntry = history.get(mapIndex).split(";");
                TableRow trow = new TableRow(this);
                if (alt == true) {
                    trow.setBackgroundColor(Color.LTGRAY);
                    alt=false;
                } else {
                    alt = true;
                }
                trow.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ActionBar.LayoutParams.WRAP_CONTENT));
                addTextToTableLayout(id++, historyEntry[0], trow);
                addTextToTableLayout(id++, historyEntry[1], trow);
                addTextToTableLayout(id++, historyEntry[2], trow);
                addTextToTableLayout(id++, historyEntry[3], trow);
                if (historyEntry[4].equals("null") || historyEntry[4] == null || historyEntry[4].isEmpty()) {
                    addTextToTableLayout(id++, "", trow);
                } else {
                    addTextToTableLayout(id++, historyEntry[4], trow);
                }
                addTextToTableLayout(id++,historyEntry[5],trow);
                t1.addView(trow);
            }
        }
    }


    void addTextToTableLayoutHeader(int id, String text, TableRow row){
        TextView view = new TextView(this);
        view.setId(id);
        view.setBackgroundColor(Color.parseColor("#d07c5d"));
        view.setTypeface(Typeface.DEFAULT_BOLD);
        view.setPadding(5, 1, 5, 1);
        view.setText(text);
        row.addView(view);
    }

    void addTextToTableLayout(int id, String text, TableRow row){
        TextView view = new TextView(this);
        view.setId(id);
        view.setText(text);
        view.setPadding(1, 1, 1, 1);
        row.addView(view);
    }

    public ArrayList<String> readHistory(){
        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
        Cursor res = db.rawQuery("SELECT * FROM GameHistory",null);

        ArrayList<String> history = new ArrayList<String>();
        if(res.getCount() != 0){
            while (res.moveToNext()){
                StringBuilder sb = new StringBuilder();
                sb.append(res.getInt(0));
                sb.append(";");
                sb.append(res.getInt(1));
                sb.append(";");
                sb.append(res.getInt(2));
                sb.append(";");
                sb.append(res.getInt(3));
                sb.append(";");
                sb.append(res.getString(4));
                sb.append(";");
                sb.append(res.getInt(5));
                history.add(sb.toString());
            }

        }
        db.close();
        return history;
    }
}
