package edu.gatech.seclass.wordfind6300;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.database.Cursor;
import android.graphics.Color;
import android.graphics.PorterDuff;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.text.method.ScrollingMovementMethod;
import android.util.TypedValue;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.database.sqlite.SQLiteDatabase;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.concurrent.ThreadLocalRandom;

import static java.lang.Math.ceil;
import static java.lang.Math.round;
import static java.lang.Thread.sleep;

public class GameBoard extends AppCompatActivity {

    Button scoreWordButton;
    Button exitGameButton;

    Button gameBoardButton;
    Button clickedButton;

    TextView wordDisplay;
    TextView timeDisplay;
    TextView scoreDisplay;
    Integer timeLeft;
    CountDownTimer timer;
    Integer wordLength = 0;
    Integer minWordLength = 1;
    Integer boardSize = 4;
    Integer[][] squareStatus = new Integer[8][8];     // 0=not-clickable (GRAY),  1=clickable (GREEN), 2=clicked (ORANGE)
    Integer currentScore;
    List<String> enteredWords = new ArrayList<String>();
    Integer highestWordScore=0;
    String  highestScoringWord;
    Integer resetCount=0;
    String maxMinutes;
    String letterWeightString;
    String letterDisplayString;
    String[][] squareValues;

    @Override
    public void onBackPressed() {
        //super.onBackPressed();
        exitGameButton.performClick();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        currentScore=0;
        // read configuration

        //String letterWeightString="1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
        // abcdefghijklmnopqrstuvwxyz
        // 01234567890123456789012345
        //           1         2
        maxMinutes = "3";
        boardSize=4;
        letterWeightString = "1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1";
        letterDisplayString = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Qu,R,S,T,U,V,W,X,Y,Z";
        SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE, null);
        Cursor res = db.rawQuery("SELECT * FROM GameSettings", null);
        if (res.getCount() != 0) {
            while (res.moveToNext()) {
                boardSize = Integer.parseInt(res.getString(2));
                maxMinutes = res.getString(1);
                letterDisplayString = res.getString(3);
                letterWeightString = res.getString(4);
            }
        }

        switch (boardSize) {
            case 4:
                setContentView(R.layout.game_board44);
                break;
            case 5:
                setContentView(R.layout.game_board55);
                break;
            case 6:
                setContentView(R.layout.game_board66);
                break;
            case 7:
                setContentView(R.layout.game_board77);
                break;
            case 8:
                setContentView(R.layout.game_board88);
                break;
            default:
                setContentView(R.layout.game_board44);
                break;
        }

        wordDisplay = (TextView) findViewById(R.id.wordDisplay);
        wordDisplay.setMovementMethod(new ScrollingMovementMethod());

        scoreDisplay = (TextView) findViewById(R.id.scoreDisplay);
        scoreDisplay.setText(String.format("%d", currentScore));

        exitGameButton = (Button) findViewById(R.id.buttonExitGame);
        scoreWordButton = (Button) findViewById(R.id.buttonScoreWord);

        timeDisplay = (TextView) findViewById(R.id.timeDisplay);

        exitGameButton.setOnClickListener((v) -> {
            //Intent intent = new Intent(this, GameBoard.class);
            timer.cancel();

            //SQLiteDatabase db = openOrCreateDatabase("WordGame.db", MODE_PRIVATE,null);
            StringBuilder sb = new StringBuilder("INSERT INTO GameHistory VALUES (");
            sb.append(currentScore);
            sb.append(",");
            sb.append(enteredWords.size());
            sb.append(",");
            sb.append(resetCount);
            sb.append(",");
            sb.append(boardSize);
            sb.append(",'");
            sb.append(highestScoringWord);
            sb.append("',");
            sb.append(Integer.parseInt(maxMinutes));
            sb.append(");");
            db.execSQL(sb.toString());
            db.close();

            Intent intent = new Intent(this, Game.class);
            startActivity(intent);
        });

        initializeGameBoard();

        scoreWordButton.setOnClickListener((v) -> {

            v.setEnabled(false);
            String wordToScore=wordDisplay.getText().toString();
            wordLength = 0;
            wordDisplay.setText("");

            // need to update word history here
            int wordScore=0;
            for (int r = 0; r < boardSize; r++) {
                for (int c = 0; c < boardSize; c++) {
                    if (squareStatus[r][c] == 3) {
                        if (squareValues[r][c].equals("Qu")) {
                            wordScore+=2;
                        } else {
                            wordScore+=1;
                        }
                    }
                    String stringButtonID = "buttonGameBoard" + (r + 1) + (c + 1);
                    int buttonID = getResources().getIdentifier(stringButtonID, "id", getPackageName());
                    gameBoardButton = (Button) findViewById(buttonID);
                    //gameBoardButton.setText(squareValues[r][c]);
                    int paddingBottom = gameBoardButton.getPaddingBottom();
                    int paddingLeft = gameBoardButton.getPaddingLeft();
                    int paddingRight = gameBoardButton.getPaddingRight();
                    int paddingTop = gameBoardButton.getPaddingTop();
                    gameBoardButton.setBackgroundColor(Color.GREEN);
                    gameBoardButton.setTextColor(Color.BLACK);
                    gameBoardButton.setPadding(paddingLeft, paddingTop, paddingRight, paddingBottom);
                    //gameBoardButton.getBackground().setColorFilter(gameBoardButton.getContext().getResources().getColor(R.color.colorAccent), PorterDuff.Mode.MULTIPLY);
                    //gameBoardButton.setBackgroundColor(getResources().getColor(R.color.red);
                    //gameBoardButton.setBackground(Color.GREEN);
                    squareStatus[r][c] = 1;
                    gameBoardButton.setEnabled(true);
                }
            }
            currentScore+=wordScore;
            enteredWords.add(wordToScore);
            scoreDisplay.setText(String.format("%d", currentScore));
            if (currentScore>highestWordScore) {
                highestScoringWord=wordToScore;
                highestWordScore=currentScore;
            }

            Cursor counter = db.rawQuery("SELECT COUNT(*) FROM WordCount WHERE Word = '"+wordToScore+"'",null);
            counter.moveToNext();

            if(counter.getInt (0) > 0){
                Cursor wordHistoryRes = db.rawQuery("SELECT score FROM WordCount WHERE Word = '"+wordToScore+"'", null);
                wordHistoryRes.moveToNext();
                Integer score = wordHistoryRes.getInt(0) + 1;
                db.execSQL("update WordCount set score = "+score+" WHERE Word = '"+wordToScore+"'");
            }else{
                db.execSQL("insert into WordCount values('"+wordToScore+"',1);");
            }




        });

        //timer = new Timer(300000, 1000);
        long maxMilliseconds = Integer.parseInt(maxMinutes) * 60 * 1000;
        timer = new Timer(maxMilliseconds, 1000);
        timer.start();
    }

    public class Timer extends CountDownTimer {

        private Integer balance;
        private Integer maxMinutes;

        public Timer(long millisInFuture, long countDownInterval) {
            super(millisInFuture, countDownInterval);
            maxMinutes = (int) (millisInFuture / 1000);
            timeDisplay.setTextSize(TypedValue.COMPLEX_UNIT_SP,72);
        }

        @Override
        public void onTick(long millisUntilFinished) {

            balance = (int) (millisUntilFinished / 1000);
            timeLeft = balance;
            int p1 = balance % 60;
            int p2 = balance / 60;
            int p3 = p2 % 60;
            timeDisplay.setText(String.format("%01d:%02d", p3, p1));

            int percent_remaining = ((100 * balance) / maxMinutes);
            if (percent_remaining < 15) {
                timeDisplay.setBackgroundColor(Color.RED);
                timeDisplay.setTextColor(Color.WHITE);
            } else if (percent_remaining <= 35) {
                timeDisplay.setBackgroundColor(Color.YELLOW);
                timeDisplay.setTextColor(Color.BLACK);
            } else {
                timeDisplay.setBackgroundColor(Color.GREEN);
                timeDisplay.setTextColor(Color.BLACK);
            }
            //progressBar.setProgress(progressBar.getMax()-progress);

        }

        @Override
        public void onFinish() {
            timeDisplay.setTextSize(TypedValue.COMPLEX_UNIT_SP,65);
            timeDisplay.setText("Time Expired!!!");
        }

    }

    public void onLetterClicked(View v) {

        if (timeLeft<=0) {
            return;
        }

        String wordText = wordDisplay.getText().toString();
        String buttonID = getResources().getResourceEntryName(v.getId());
        int row = Character.getNumericValue(buttonID.charAt(buttonID.length() - 2))-1;
        int col = Character.getNumericValue(buttonID.charAt(buttonID.length() - 1))-1;
        if (squareStatus[row][col] == 1) {
            clickedButton = (Button) findViewById(v.getId());
            wordText += clickedButton.getText().toString();
            wordDisplay.setText(wordText);
            wordLength++;
            if (wordLength > minWordLength) {
                if (enteredWords.contains(wordText)) {
                    scoreWordButton.setEnabled(false);
                } else {
                    scoreWordButton.setEnabled(true);
                }
            }
            clickedButton.setBackgroundColor(Color.CYAN);
            clickedButton.setEnabled(false);
            squareStatus[row][col]=4;
        }
        for (int r = 0; r < boardSize; r++) {
            for (int c = 0; c < boardSize; c++) {
                if (squareStatus[r][c]!=3 && squareStatus[r][c]!=4) {
                    if (   (r>0                            && squareStatus[r-1][c]   ==4)
                            || (r>0           && c<boardSize-1 && squareStatus[r-1][c+1] ==4)
                            || (r>0           && c>0           && squareStatus[r-1][c-1] ==4)
                            || (r<boardSize-1                  && squareStatus[r+1][c]   ==4)
                            || (r<boardSize-1 && c<boardSize-1 && squareStatus[r+1][c+1] ==4)
                            || (r<boardSize-1 && c>0           && squareStatus[r+1][c-1] ==4)
                            || (                 c>0           && squareStatus[r+0][c-1] ==4)
                            || (                 c<boardSize-1 && squareStatus[r+0][c+1] ==4)) {
                        squareStatus[r][c]=1;
                        setButtonClickable(buttonID,r,c);
                    } else {
                        squareStatus[r][c]=0;
                        setButtonNotClickable(buttonID,r,c);
                    }

                }
            }
        }
        squareStatus[row][col]=3;
    }

    public void setButtonClickable(String _buttonID, int _r, int _c) {
        String adjacentButtonStringID = _buttonID.substring(0, _buttonID.length() - 2) + (_r+1) + (_c+1);
        int adjacentButtonID = getResources().getIdentifier(adjacentButtonStringID, "id", getPackageName());
        Button adjacentButton = (Button) findViewById(adjacentButtonID);
        adjacentButton.setBackgroundColor(Color.GREEN);
        adjacentButton.setTextColor(Color.BLACK);
        adjacentButton.setEnabled(true);
    }

    public void setButtonNotClickable(String _buttonID, int _r, int _c) {
        String adjacentButtonStringID = _buttonID.substring(0, _buttonID.length() - 2) + (_r+1) + (_c+1);
        int adjacentButtonID = getResources().getIdentifier(adjacentButtonStringID, "id", getPackageName());
        Button adjacentButton = (Button) findViewById(adjacentButtonID);
        adjacentButton.setBackgroundColor(Color.RED);
        adjacentButton.setTextColor(Color.WHITE);
        adjacentButton.setEnabled(false);
    }

    public void initializeGameBoard() {

        // build letter pools
        int[] weights = new int[26];
        int consonantSize = 0;
        int vowelSize = 0;
        for (int l = 0; l < 26; l++) {

            int weight;
            try {
                weight = Integer.parseInt(letterWeightString.split(",")[l]);
            } catch (NumberFormatException e) {
                weight = 1;
            }

            weights[l] = weight;
            if (l == 0 || l == 4 || l == 8 || l == 14 || l == 20) {
                // vowelSize += 1;  //20200229_1225
                vowelSize += weight;
            } else {
                // consonantSize += 1;  //20200229_1225
                consonantSize += weight;
            }
        }

        int[] vowelPool = new int[vowelSize];
        int[] consonantPool = new int[consonantSize];
        int nextVowel = 0;
        int nextConsonant = 0;
        for (int l = 0; l < 26; l++) {
            if (l == 0 || l == 4 || l == 8 || l == 14 || l == 20) {
                for (int i = 0; i < weights[l]; i++) {
                    vowelPool[nextVowel++] = l;
                }
            } else {
                for (int i = 0; i < weights[l]; i++) {
                    consonantPool[nextConsonant++] = l;
                }
            }
        }

        // perform random letter selection
        int rows = boardSize;
        int cols = boardSize;
        int vowelCount = (int) ceil(((double) rows * (double) cols) / (double) 5);
        int maxVowels = vowelCount;
        int minVowels = 1;
        int consonantCount = (rows * cols) - vowelCount;
        int minConsonants = 1;
        int maxConsonants = consonantCount;
        squareValues = new String[rows][cols];
        String[][] squareTypes = new String[rows][cols];
        java.util.Random rand = new java.util.Random();
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                Boolean letterNotPicked = true;
                while (letterNotPicked) {
                    double v = rand.nextDouble();
                    if (v < 0.2 && vowelCount > 0) {
                        //int randomNumber = random.nextInt(max + 1 - min) + min;
                        //int randomVowel = rand.nextInt(maxVowels + 1 - minVowels) + minVowels;
                        //int randomVowel = ThreadLocalRandom.current().nextInt(minVowels, maxVowels); //20200229_1225
                        int randomVowel = ThreadLocalRandom.current().nextInt(1, vowelSize);
                        randomVowel-=1;
                        squareValues[r][c] = letterDisplayString.split(",")[vowelPool[randomVowel]];
                        squareTypes[r][c] = "v";
                        vowelCount--;
                        letterNotPicked = false;
                    } else if (consonantCount > 0) {
                        //int randomConsonant = rand.nextInt(maxConsonants + 1 - minVowels) + minVowels;
                        //int randomConsonant = ThreadLocalRandom.current().nextInt(minConsonants, maxConsonants); //20200229_1225
                        int randomConsonant = ThreadLocalRandom.current().nextInt(1, consonantSize);
                        randomConsonant-=1;
                        squareValues[r][c] = letterDisplayString.split(",")[consonantPool[randomConsonant]];
                        squareTypes[r][c] = "c";
                        consonantCount--;
                        letterNotPicked = false;
                    }
                }
                String stringButtonID = "buttonGameBoard" + (r + 1) + (c + 1);
                int buttonID = getResources().getIdentifier(stringButtonID, "id", getPackageName());
                gameBoardButton = (Button) findViewById(buttonID);
                gameBoardButton.setText(squareValues[r][c]);
                int paddingBottom = gameBoardButton.getPaddingBottom();
                int paddingLeft = gameBoardButton.getPaddingLeft();
                int paddingRight = gameBoardButton.getPaddingRight();
                int paddingTop = gameBoardButton.getPaddingTop();
                gameBoardButton.setBackgroundColor(Color.GREEN);
                gameBoardButton.setTextColor(Color.BLACK);
                gameBoardButton.setPadding(paddingLeft, paddingTop, paddingRight, paddingBottom);
                //gameBoardButton.getBackground().setColorFilter(gameBoardButton.getContext().getResources().getColor(R.color.colorAccent), PorterDuff.Mode.MULTIPLY);
                //gameBoardButton.setBackgroundColor(getResources().getColor(R.color.red);
                //gameBoardButton.setBackground(Color.GREEN);
                squareStatus[r][c] = 1;
            }
        }

        // need to check for repeated letters  (not sure about this one - can't click same letter twice)

        scoreWordButton.setEnabled(false);

    }

    public void onReRollClicked(View v) {
        if (timeLeft>0) {
            currentScore -= 5;
            scoreDisplay.setText(String.format("%d", currentScore));
            initializeGameBoard();
        }
    }

}

