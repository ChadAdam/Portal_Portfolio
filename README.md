## Android Weather App with a Visual Feedback of how the Weather Data Affects What We Should Wear    

- The goal of the project is to help user know better which actions they should take when choosing clothes using the weather data they receive daily.

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607891172.png" width="300" height="500">

The first screen is the weekly weather forecast in a scrollable manner. The weather data for the current day is featured with more emphasis than the others. The weather data being the day's humidity percentage , max temperature  and min temperature. 

At the same time when you initially open the app you will get a notification showing this same information. These notifications will show every few hours to give you up to date information.  If you click the notification you will be sent to the screen that shows more information about the day or you can click on any other day to get the same information for that day.

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607891182.png" width="300" height="500">

Whether you clicked the notification or the screen days themselves you will end up in a screen with more details. The info added are the weather pressure and wind speed / direction. All this information will be used to determine the recommended clothes.

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607891261.png" width="300" height="500">

If you swipe right on the weather detail screen you will come to a visualization of the how an average human would react given the weather details and the clothes you chose to wear. Tan means you are wearing the perfect amount of clothes , blue means you will be cold( You need more clothes) , and red means you will be hot ( You need less clothes). 

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607985606.png" width="300" height="500">

It might be helpful to know that the screen where you customize the clothes you are wearing can be activated in 2 ways. The first is to click "Choose Clothes" on the figure screen shown prior. But you cannot get to this screen when you first activate the app since the app needs to know your clothes preferences to show you the figure screen. As such when you first use the app swiping right on the weather detail screen will send you to this screen with a message saying " Clothes need to be set". Every following activation of this screen will not show this message as there will be preferences set no matter if you restart the app or not. 

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607992090.png" width="300" height="500">

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607991453.png" width="300" height="500">

Let's say for example it is 55 degrees outside. You are for some reason only wearing a hat and tie.  As you would think you your arms , legs , chest and head would be freezing. 

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607991936.png" width="300" height="500">

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607992185.png" width="300" height="500">

But let's you realize your mistake and decide now to put on a coat. This time your chest and arms are wearing the appropriate amount of clothes but your head and legs are still cold. Makes sense since you are not wearing any pants. 

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607992653.png" width="300" height="500">

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607992677.png" width="300" height="500">

<img src="Forcast_Clothes_Weather_App\images\Screenshot_1607992666.png" width="300" height="500">

If you go back to the main screen you can change some settings by clicking on the 3 dots in the right corner of the screen. You can switch between Metric and Fahrenheit. You can also switch your location. At the start we were in New York City , but now let's change to Miami. The first image of the main screen is in Fahrenheit and the second is in Metric for Miami. 

# Graduates Study Portfolio

## Database Design and Management using PostgreSQL and C#       

- Implement schema and program features using EER model & Information Flow diagrams inspired by client spec. 

- Program GUI for database using C# and .NET framework with Winforms. 

 

[Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[DB](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB)/[BurdellsRamblinWrecks](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks)/[BurdellsRamblinWrecks](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks/BurdellsRamblinWrecks)/**team003_p2_schema.sql** 

​     ​  The schema used in the database.

[Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[DB](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB)/[BurdellsRamblinWrecks](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks)/[BurdellsRamblinWrecks](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks/BurdellsRamblinWrecks)/**Program.cs**      

​		Entry point to start database GUI.

[Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[DB](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB)/[BurdellsRamblinWrecks](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks)/[BurdellsRamblinWrecks](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks/BurdellsRamblinWrecks)/[Queries](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks/BurdellsRamblinWrecks/Queries)/**QueryExecutor.cs**          

​		In file is the connection to database :

| private readonly string conn_string = "Server=Server_Name; Port=Port_Number; User Id = DBUser; Password=Passwd; Database=DB"; |
| ------------------------------------------------------------ |
| This is the template we used to connect to the db for our group. The password cannot be shared online. |

 [Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[DB](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB)/[BurdellsRamblinWrecks](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks)/[BurdellsRamblinWrecks](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks/BurdellsRamblinWrecks)/[Queries](https://github.com/ChadAdam/Portal_Portfolio/tree/master/DB/BurdellsRamblinWrecks/BurdellsRamblinWrecks/Queries)/**SqlTextAll.cs**      

​		Queries that make up functionalities as per the spec requirements. 



## Android Game using Java and SQLite                                                      

- Translate requirements into Project plan, Test plan, Use Case Model, Design Document.

- Participated in complete Software Development Life Cycle (SDLC): Requirements, Design, Implementation, Test, Maintenance.

- Developed unit tests using Junit and UI tests using Espresso after project completion.

- Contributed to the program with clean and robust code using Java and XML with Android Studio.

[Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[Android](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android)/**Docs**/

​		Documents translated from spec requirements and used to manage project. 

[Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[Android](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android)/[WordFind6300](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300)/[app](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app)/[src](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src)/[main](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/main)/[java](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/main/java)/[edu](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/main/java/edu)/[gatech](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/main/java/edu/gatech)/[seclass](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/main/java/edu/gatech/seclass)/**wordfind6300**/

​		Source files for application.

[Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[Android](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android)/[WordFind6300](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300)/[app](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app)/[src](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src)/[androidTest](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/androidTest)/[java](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/androidTest/java)/[edu](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/androidTest/java/edu)/[gatech](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/androidTest/java/edu/gatech)/[seclass](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/WordFind6300/app/src/androidTest/java/edu/gatech/seclass)/**wordfind6300**/

​		Test files for Junit and Espresso testing.

[Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[Android](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android)/[Docs](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/Docs)/**UserManual.md** 

​		User manual for application.                   

[Portal_Portfolio](https://github.com/ChadAdam/Portal_Portfolio)/[Android](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android)/[APK](https://github.com/ChadAdam/Portal_Portfolio/tree/master/Android/APK)/**WordFind6300.apk**      

​		The apk file to run. 



## **Data Exploration and Network Analysis** using Python

https://github.com/ChadAdam/Network-Analysis

https://github.com/ChadAdam/Machine_Learning
