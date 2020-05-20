package edu.gatech.seclass.wordfind6300;

import android.app.ActionBar;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.graphics.Typeface;
import android.os.Bundle;
import android.view.Gravity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import androidx.appcompat.app.AppCompatActivity;

public class GameSettings extends AppCompatActivity {
    Button gameSettingsExitButton;
    private EditText timeInput;
    private EditText sizeInput;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.game_settings);

        // read game settings
        String value = readSettings();
        if(value.length() == 0){
            // insert a game setting with default values
            writeGameSettings();
            value = readSettings();
        }

        String[] tableValues = value.split(";");

        timeInput = (EditText) findViewById(R.id.inputTime);
        sizeInput = (EditText) findViewById(R.id.inputSize);
        //time
        timeInput.setText(tableValues[1]);
        //size
        sizeInput.setText(tableValues[2]);
        // display Letter Weight table with letter and Weight
        displayLetterWeight(tableValues[3], tableValues[4]);

        gameSettingsExitButton = (Button) findViewById(R.id.buttonGameSettingsExit);

        gameSettingsExitButton.setOnClickListener((v) -> {
            boolean hasError = saveSettings();
            if(!hasError){
                Intent intent = new Intent(this, Game.class);
                startActivity(intent);
            }
        });

    }
    public void clearSettings(){
        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
        db.execSQL("DELETE FROM GameSettings");
        db.close();
    }

    public String readSettings(){
        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
        Cursor res = db.rawQuery("SELECT * FROM GameSettings", null);
        if(res.getCount() == 0)
            return "";
        res.moveToNext();
        StringBuilder sb = new StringBuilder();
        sb.append(res.getInt(0)); //Id
        sb.append(";");
        sb.append(res.getInt(1)); //Minutes
        sb.append(";");
        sb.append(res.getInt(2)); //Boardsize
        sb.append(";");
        sb.append(res.getString(3));// Letter display string
        sb.append(";");
        sb.append(res.getString(4));// Letter weight string
        sb.append(";");
        sb.append(res.getString(5)); //Consonante pool
        sb.append(";");
        sb.append(res.getString(6)); //Vowel pool
        db.close();
        return sb.toString();
    }

    public void writeGameSettings(){
        int maxMinutes = 3;
        int boardSize =4;

        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
        StringBuilder sb = new StringBuilder("INSERT OR REPLACE INTO GameSettings VALUES (");
        sb.append(1);
        sb.append(",");
        sb.append(maxMinutes);
        sb.append(",");
        sb.append(boardSize);
        sb.append(",");
        sb.append("'A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Qu,R,S,T,U,V,W,X,Y,Z'");
        sb.append(",");
        sb.append("'1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1'");
        sb.append(",");
        sb.append("'YOU CAN PUT A POOL OF CONSONANTS HERE'");
        sb.append(",");
        sb.append("'YOU CAN PUT A POOL OF VOWELS HERE'");
        sb.append(");");
        db.execSQL(sb.toString());
        db.close();
    }

    void displayLetterWeight(String displayLetter, String weight){

        TableLayout t1 = (TableLayout)findViewById(R.id.tableLayout);

        TableRow tHeadTitle = new TableRow(this);

        tHeadTitle.setId(10+1);
        tHeadTitle.setBackgroundColor(Color.parseColor("#5dd0bc"));
        tHeadTitle.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ActionBar.LayoutParams.WRAP_CONTENT));
        TextView title = new TextView(this);
        title.setText("Letter Weight");

        tHeadTitle.addView(title);

        t1.addView(tHeadTitle);
        tHeadTitle.setGravity(Gravity.CENTER);

        TableRow tHead = new TableRow(this);

        tHead.setId(10+2);
        //tHead.setBackgroundColor(Color.WHITE);
        tHead.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ActionBar.LayoutParams.WRAP_CONTENT));
        TextView display = new TextView(this);
        display.setId(10+1);
        display.setText("Diaplay Letter");
        display.setBackgroundColor(Color.YELLOW);
        display.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT,TableRow.LayoutParams.MATCH_PARENT,10.0f));
        display.setPadding(10, 1, 10, 1);

        tHead.addView(display);

        TextView letterWeight = new TextView(this);
        letterWeight.setId(21+1);
        letterWeight.setText("Weight");
        letterWeight.setBackgroundColor(Color.CYAN);
        letterWeight.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.MATCH_PARENT,TableRow.LayoutParams.MATCH_PARENT,10.0f));

        letterWeight.setPadding(10, 1, 10, 1);
        tHead.addView(letterWeight);
        t1.addView(tHead);

        String[] letterArr = displayLetter.split(",");
        String[] weightArr = weight.split(",");
        int id = 0;

        for(int i = 0; i < letterArr.length; i++){
            TableRow trow = new TableRow(this);
            trow.setLayoutParams(new TableLayout.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT, ActionBar.LayoutParams.WRAP_CONTENT));
            TextView dispLetter = new TextView(this);
            dispLetter.setId(id++);
            dispLetter.setBackgroundColor(Color.LTGRAY);
            dispLetter.setText(letterArr[i]);
            dispLetter.setTypeface(Typeface.DEFAULT_BOLD);
            dispLetter.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT,TableRow.LayoutParams.WRAP_CONTENT,10.0f));
            dispLetter.setPadding(10, 1, 10, 1);

            trow.addView(dispLetter);

            EditText myEditText = new EditText(getApplicationContext());
            myEditText.getBackground().setColorFilter(Color.LTGRAY, PorterDuff.Mode.OVERLAY);
            myEditText.setTextColor(Color.BLACK);
            myEditText.setId(id++);
            myEditText.setTag("weightText"+ i);
            myEditText.setText(weightArr[i]);

            myEditText.setMaxLines(1);
            myEditText.setSingleLine(true);

            myEditText.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT,TableRow.LayoutParams.WRAP_CONTENT,10.0f));
            myEditText.setPadding(10, 1, 10, 1);
            trow.addView(myEditText);

            t1.addView(trow);

        }

    }

    // will return a boolean indicating errors
    public boolean saveSettings(){
        Boolean hasError = false;
        String weight = "";
        // validate time
        if(!validateTime(timeInput.getText().toString())){
            hasError = true;
            timeInput.setError("Minutes should be between 1 and 5.");
        }
        // validate board size
        if(!validateBoardSize(sizeInput.getText().toString())){
            hasError = true;
            sizeInput.setError("Board size should be between 4 and 8.");
        }

        TableLayout t1 = (TableLayout)findViewById(R.id.tableLayout);
        int childParts = t1.getChildCount();
        if (t1 != null) {
            for (int i = 0; i < childParts; i++) {
                View viewChild = t1.getChildAt(i);
                if (viewChild instanceof TableRow) {
                    int rowChildParts = ((TableRow) viewChild).getChildCount();
                    for (int j = 0; j < rowChildParts; j++) {
                        View viewChild2 = ((TableRow) viewChild).getChildAt(j);
                        if (viewChild2 instanceof EditText) {
                            // get text from edit text
                            String text = ((EditText) viewChild2).getText().toString();
                            // validate weight
                            if(!validateWeight(text)){
                                ((EditText) viewChild2).setError("Value should be between 1 and 5.");
                                hasError = true;
                            }
                            weight+= text+ ",";
                        }
                    }
                }
            }
        }
        weight= weight.substring(0, weight.length() - 1);

        if(!hasError){
            Integer timeLimit = Integer.valueOf(timeInput.getText().toString());
            Integer size = Integer.valueOf(sizeInput.getText().toString());

            // save to DB

            SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
            StringBuilder sb = new StringBuilder("UPDATE GameSettings SET MaxMinutes=");
            sb.append(timeLimit);
            sb.append(",");
            sb.append("BoardSize=");
            sb.append(size);
            sb.append(",");
            sb.append("LetterWeights=");
            sb.append("'");
            sb.append(weight);
            sb.append("'");
            sb.append(" WHERE Id = 1");

            db.execSQL(sb.toString());
            db.close();
        }

        return  hasError;

    }

    public static boolean validateTime(String timeLimit){

        try {
           if(Integer.valueOf(timeLimit) == (int)Integer.valueOf(timeLimit) ){
               if(Integer.valueOf(timeLimit) < 1 || Integer.valueOf(timeLimit) > 5) {
                   return false;
               }
               return true;
           }else{
               return false;
           }
        } catch (NumberFormatException e) {
           return false;
        }

    }

    public static boolean validateBoardSize(String size){
        try {
            if (Integer.valueOf(size)  == (int) Integer.valueOf(size)) {
                if (Integer.valueOf(size) < 4 || Integer.valueOf(size) > 8) {
                    return false;
                }
                return true;
            } else {
                return false;
            }
        } catch (NumberFormatException e) {
            return false;
        }

    }

    public static boolean validateWeight(String text){
        try{
            if(Integer.valueOf(text) == (int)Integer.valueOf(text) ){
                if(Integer.valueOf(text) < 1 || Integer.valueOf(text)>5){
                    return false;
                }
                return true;
            }else{
                return false;
            }
        } catch (NumberFormatException e) {
            return false;
        }

    }


}

