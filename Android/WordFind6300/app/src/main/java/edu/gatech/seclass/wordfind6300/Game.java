package edu.gatech.seclass.wordfind6300;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.content.Intent;
import android.widget.Button;

public class Game extends AppCompatActivity {
    Button playGameButton;
    Button gameHistoryButton;
    Button wordCounterButton;
    Button gameSettingsButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.game);

        createDatabase();

        playGameButton = (Button) findViewById(R.id.buttonPlayGame);

        playGameButton.setOnClickListener((v) -> {
            Intent intent;
            intent = new Intent(this, GameBoard.class);
                //**intent = new Intent(this, GameBoard44.class);
            startActivity(intent);
        });

        gameHistoryButton = (Button) findViewById(R.id.buttonGameHistory);

        gameHistoryButton.setOnClickListener((v) -> {
            Intent intent = new Intent(this, GameHistory.class);
            startActivity(intent);
        });


        wordCounterButton = (Button) findViewById(R.id.buttonWordCounter);

        wordCounterButton.setOnClickListener((v) -> {
            Intent intent = new Intent(this, WordCounter.class);
            startActivity(intent);
        });


        gameSettingsButton = (Button) findViewById(R.id.buttonGameSettings);

        gameSettingsButton.setOnClickListener((v) -> {
            Intent intent = new Intent(this, GameSettings.class);
            startActivity(intent);
        });


    }

    void createDatabase(){
        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
        //Can use these statements to clear out any old data we want removed.
        //Make sure our database as the correct tables.
        //db.execSQL("DROP TABLE GameHistory");
        db.execSQL("CREATE TABLE IF NOT EXISTS \"GameHistory\" (\n" +
                "\t\"FinalScore\"\tINTEGER NOT NULL,\n" +
                "\t\"WordCount\"\tINTEGER NOT NULL,\n" +
                "\t\"ResetCount\"\tINTEGER NOT NULL,\n" +
                "\t\"BoardSize\"\tINTEGER NOT NULL,\n" +
                "\t\"HighestWord\"\tTEXT NOT NULL,\n" +
                "\t\"Minutes\"\tINTEGER NOT NULL\n" +
                ")");

        db.execSQL("CREATE TABLE IF NOT EXISTS \"GameSettings\" (\n" +
                "\t\"Id\"\tINTEGER NOT NULL UNIQUE,\n" +
                "\t\"MaxMinutes\"\tINTEGER NOT NULL DEFAULT 3,\n" +
                "\t\"BoardSize\"\tINTEGER NOT NULL DEFAULT 4,\n" +
                "\t\"LetterDisplayString\"\tTEXT NOT NULL DEFAULT 'A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Qu,R,S,T,U,V,W,X,Y,Z',\n" +
                "\t\"LetterWeights\"\tTEXT NOT NULL DEFAULT '1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1',\n" +
                "\t\"ConsonantPool\"\tTEXT,\n" +
                "\t\"VowelPool\"\tTEXT,\n" +
                "\tPRIMARY KEY(\"Id\")\n" +
                ");");

        db.execSQL("CREATE TABLE IF NOT EXISTS \"WordCount\" (\n" +
                "\t\"Word\"\tTEXT NOT NULL,\n" +
                "\t\"Score\"\tINTEGER NOT NULL\n" +
                ");");
        db.close();
    }



}