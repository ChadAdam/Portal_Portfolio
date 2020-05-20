# 											<u>*WordPlay106*</u>

WordPlay106 is a challenging word game that will provide hours of entertainment while simultaneously improving your vocabulary. The objective of the game is to combine letters on the board to create as many words as possible within the given time limit.  The longer the word the more points you will get. Each board is randomly generated to truly test your skills, but don't worry you can reset the board for a price!

## Select Menu

The first screen the user will see when starting the application is the Menu screen.  This screen has 4 functionalities. :

- Play Word Game

- View Game Score Statistics

- View Word Statistics

- Adjust Game Settings

  <img src=..\Docs\images\Menu.PNG width="400" height="500" />



1. ### Play Word Game

   When the *Play Word game* is clicked the game screen appears. This screen shows the board which is a grid of letters whose number of rows and columns are equal to what the *Settings* for <u>board size</u> is. 
   
   The rules are:
   
   - You must pick more than 1 letter to form a word
   - You must only pick letters adjacent to the previous pick
   - You cannot pick the same letter twice
   
   When the user picks letter a light blue color surrounds the letter and all non-adjacent letters will turn red meaning they are disabled. These letters cannot be picked to build the word. The red letters will always be dependent on the last picked letter. 
   
   Underneath the board is an input field , a timer , and 3 buttons. The timer counts down from a time dependent on what the *Settings* for <u>max time</u> is. The 3 buttons are:
   
   A. Score Word
   
   B. Re-Roll Board
   
   C. Exit Game
   
   <img src="..\Docs\images\NewBoard2.png" width="400" height="500" />



##### Score Word

Once the the letters are picked the user clicks the *score word* button to add the word's points to the score. The score field will be updated in real-time. The user gets 1 point for every letter in the word and 'Qu' is counted as 2 letters in the points calculation.

##### Re-Roll Board

When clicked the board is regenerated and the user gets penalized 5 points from the score. The final score can be less than zero.  

##### Exit Game

When clicked the user is returned to the main menu. The final score is displayed.



### View Game Score Statistics 

When the *View Game Score Statistics* button is clicked the screen shows 6 columns. Final score , # of Words, # Resets , Board size , Highest word , and Minutes:

- Final score- The final score of the game
- Number of Words-The number of words the user made in game
- Number of Resets- The number of times the user clicked the *Re-Roll button* in game 
- Board Size- The board size of the game that was played
- Highest Word - The word entered during the game with the highest individual score
- Minutes - The number of minutes the game took 


When the user wants to return to the main menu they can click the *Exit Game History* button.

<img src="..\Docs\images\Score_1.png" width="400" height="500"/>



### View Word Statistics 

When the *View Word Statistics* button is clicked the screen shows 2 columns. One for the word and one for the word's frequency on the board. When the user wants to return to the main menu they can click the *Exit Word Counter* button.

<img src="..\Docs\images\WordCount1_1.png" width="400" height="500"/>





### Adjust Settings

When the *Adjust Game Settings* button is clicked the screen shows the Time field , Board Size field and a weight field for each displayed letter.

- Time- The user inputs the <u>max time</u> for all games
  - The input must be an integer and between 1 and 5 inclusive 
  - If input is less than 1 or greater than 5 error message "Minutes should be between 1 and 5" will appear
- Board Size- The user inputs the <u>board size</u> for all games
  - The input must be an integer and between 4 and 8 inclusive 
  - If input is less than 4 or greater than 8 error message "Board size should be between 4 and 8 " will appear
- Letter Weights- The user inputs how often each letter will appear
  - The weights table is scrollable and covers all letters
  - The input must be an positive integer
  - If input is less than 1 or not an integer than error message "Value should be between 1 and 5" will appear

<img src="..\Docs\images\NewSettings.png" width="400" height="700"/>



 When the user wants to return to the main menu they can click the *Exit Game Settings* button.

## Example of Use

The user starts on the menu screen and should first decide what settings they want from their games. How many points do they want each word to count as? How long do they want the games to last? What board size should they use? To start let's remember what we can not pick:

- We cannot pick a non-integer or negative integer for max minutes. 

<img src="..\Docs\images\MaxTime -Error.png" width="400" height="700"/>

- We cannot pick a non-integer or a negative integer for board size

  <img src="..\Docs\images\BoardSize-Error.png" width="400" height="700"/>

- We cannot pick a non-integer or a negative integer as a weight

  <img src="..\Docs\images\Weight-Error.png" width="400" height="700"/>



Let's say we want a game that's 4X4 , starts at 3 minutes and has a default weight of 1 for each letters. This means a board that is 4 columns of letters with each column being made up of 4 letters. The time will count down from 3 minutes and each letter will appear equally as often.

<img src="..\Docs\images\GameSetttings-Ex.png" width="400" height="700"/>

Now that we know what the details of our game will be it's time to play it. We will exit out of game settings and click *play word game* on the main menu. We should have have a board of random letters to play with.  I already see a word I will make. I will pick "Hi".

<img src="..\Docs\images\Start-ex.png" width="400" height="500"/>

To pick I will click on "H" first and when I do all letters that are not adjacent will turn red. Luckily "I" is adjacent and so I can pick it. As you can see once "I" is picked the boards enabled and disabled letters will change to be based on "I" no matter what letters were picked before it.  It requires a certain level of strategy to determine if it is an advantage to pick certain letters before others based on these rules. 



<img src="..\Docs\images\Board-Ex.png" width="400" height="500"/>



We are going to click *Score Word* button and see our points. Once picked all letters on the board will be enabled again and the score on the bottom of the screen will update in this case to 2. But now we don't see anything else I can pick. I guess we will have to click the *ReRoll* button.

<img src="..\Docs\images\22.png" width="400" height="500"/>

We click the <u>reroll</u> button and now we have a new board to work with. Unfortunately we also lost 5 points putting our score to -3.

<img src="..\Docs\images\Reroll-Ex.png" width="400" height="500"/>

Let's click *exit* and return to the main menu. Now we can play again , view statistics if we are done , or change the settings to create more of a challenge. How well do you think you can do in 1 minute instead?

