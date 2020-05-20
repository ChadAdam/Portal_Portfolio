package edu.gatech.seclass.wordfind6300;
import android.os.Bundle;

import androidx.test.espresso.Espresso;
import androidx.test.rule.ActivityTestRule;
import androidx.test.runner.AndroidJUnit4;
import org.junit.Assert;
import org.junit.Rule;
import org.junit.Test;
import org.junit.runner.RunWith;
import static androidx.test.espresso.Espresso.*;
import static androidx.test.espresso.Espresso.onView;
import static androidx.test.espresso.action.ViewActions.*;
import static androidx.test.espresso.assertion.ViewAssertions.*;
import static androidx.test.espresso.matcher.ViewMatchers.*;
import static androidx.test.espresso.matcher.ViewMatchers.isDisplayed;
import static androidx.test.espresso.matcher.ViewMatchers.withId;
import static androidx.test.espresso.assertion.ViewAssertions.matches;
public class GameBoardTest {
    @Rule
    public ActivityTestRule<GameBoard> tActivityRule = new ActivityTestRule<>(GameBoard.class);

    @Test
    public void test4x4Board() {

        // Game board 4 X 4
        onView(withId(R.id.buttonGameBoard11)).perform(click());
        onView(withId(R.id.buttonGameBoard12)).perform(click());
        onView(withId(R.id.buttonGameBoard13)).perform(click());
        onView(withId(R.id.buttonGameBoard14)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard24)).perform(click());
        onView(withId(R.id.buttonGameBoard23)).perform(click());
        onView(withId(R.id.buttonGameBoard22)).perform(click());
        onView(withId(R.id.buttonGameBoard21)).perform(click());
        onView(withId(R.id.buttonGameBoard31)).perform(click());
        onView(withId(R.id.buttonGameBoard32)).perform(click());
        onView(withId(R.id.buttonGameBoard33)).perform(click());
        onView(withId(R.id.buttonGameBoard34)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard43)).perform(click());
        onView(withId(R.id.buttonGameBoard42)).perform(click());
        onView(withId(R.id.buttonGameBoard41)).perform(click());

        String displayWord = tActivityRule.getActivity().wordDisplay.getText().toString();
        onView(withText(displayWord)).check(matches(isDisplayed()));

        onView(withId(R.id.buttonScoreWord)).perform(click());
        onView(withId(R.id.buttonReRoll)).perform(click());

        String score = tActivityRule.getActivity().scoreDisplay.getText().toString();
        onView(withText(score)).check(matches(isDisplayed()));

        Espresso.closeSoftKeyboard();
        // Back in Game
        onView(withId(R.id.buttonExitGame)).perform(click());
        onView(withId(R.id.buttonGameSettings)).perform(click());

        // Game board 5 X 5
        onView(withId(R.id.inputSize)).perform(clearText(), replaceText("5"));
        onView(withId(R.id.buttonGameSettingsExit)).perform(click());

        onView(withId(R.id.buttonPlayGame)).perform(click());

        onView(withId(R.id.buttonGameBoard11)).perform(click());
        onView(withId(R.id.buttonGameBoard12)).perform(click());
        onView(withId(R.id.buttonGameBoard13)).perform(click());
        onView(withId(R.id.buttonGameBoard14)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard24)).perform(click());
        onView(withId(R.id.buttonGameBoard23)).perform(click());
        onView(withId(R.id.buttonGameBoard22)).perform(click());
        onView(withId(R.id.buttonGameBoard21)).perform(click());
        onView(withId(R.id.buttonGameBoard31)).perform(click());
        onView(withId(R.id.buttonGameBoard32)).perform(click());
        onView(withId(R.id.buttonGameBoard33)).perform(click());
        onView(withId(R.id.buttonGameBoard34)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard43)).perform(click());
        onView(withId(R.id.buttonGameBoard42)).perform(click());
        onView(withId(R.id.buttonGameBoard41)).perform(click());

        String displayWord2 = tActivityRule.getActivity().wordDisplay.getText().toString();
        onView(withText(displayWord2)).check(matches(isDisplayed()));
        String score2 = tActivityRule.getActivity().scoreDisplay.getText().toString();
        onView(withText(score2)).check(matches(isDisplayed()));

        Espresso.closeSoftKeyboard();
        // Back in Game
        onView(withId(R.id.buttonExitGame)).perform(click());
        onView(withId(R.id.buttonGameSettings)).perform(click());

        // Game board 6 X 6
        onView(withId(R.id.inputSize)).perform(clearText(), replaceText("6"));
        onView(withId(R.id.buttonGameSettingsExit)).perform(click());

        onView(withId(R.id.buttonPlayGame)).perform(click());

        onView(withId(R.id.buttonGameBoard11)).perform(click());
        onView(withId(R.id.buttonGameBoard12)).perform(click());
        onView(withId(R.id.buttonGameBoard13)).perform(click());
        onView(withId(R.id.buttonGameBoard14)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard24)).perform(click());
        onView(withId(R.id.buttonGameBoard23)).perform(click());
        onView(withId(R.id.buttonGameBoard22)).perform(click());
        onView(withId(R.id.buttonGameBoard21)).perform(click());
        onView(withId(R.id.buttonGameBoard31)).perform(click());
        onView(withId(R.id.buttonGameBoard32)).perform(click());
        onView(withId(R.id.buttonGameBoard33)).perform(click());
        onView(withId(R.id.buttonGameBoard34)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard43)).perform(click());
        onView(withId(R.id.buttonGameBoard42)).perform(click());
        onView(withId(R.id.buttonGameBoard41)).perform(click());

        String displayWord3 = tActivityRule.getActivity().wordDisplay.getText().toString();
        onView(withText(displayWord3)).check(matches(isDisplayed()));
        String score3 = tActivityRule.getActivity().scoreDisplay.getText().toString();
        onView(withText(score3)).check(matches(isDisplayed()));

        Espresso.closeSoftKeyboard();
        // Back in Game
        onView(withId(R.id.buttonExitGame)).perform(click());
        onView(withId(R.id.buttonGameSettings)).perform(click());

        // Game board 7 X 7
        onView(withId(R.id.inputSize)).perform(clearText(), replaceText("7"));
        onView(withId(R.id.buttonGameSettingsExit)).perform(click());

        onView(withId(R.id.buttonPlayGame)).perform(click());

        onView(withId(R.id.buttonGameBoard11)).perform(click());
        onView(withId(R.id.buttonGameBoard12)).perform(click());
        onView(withId(R.id.buttonGameBoard13)).perform(click());
        onView(withId(R.id.buttonGameBoard14)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard24)).perform(click());
        onView(withId(R.id.buttonGameBoard23)).perform(click());
        onView(withId(R.id.buttonGameBoard22)).perform(click());
        onView(withId(R.id.buttonGameBoard21)).perform(click());
        onView(withId(R.id.buttonGameBoard31)).perform(click());
        onView(withId(R.id.buttonGameBoard32)).perform(click());
        onView(withId(R.id.buttonGameBoard33)).perform(click());
        onView(withId(R.id.buttonGameBoard34)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard43)).perform(click());
        onView(withId(R.id.buttonGameBoard42)).perform(click());
        onView(withId(R.id.buttonGameBoard41)).perform(click());

        String displayWord4 = tActivityRule.getActivity().wordDisplay.getText().toString();
        onView(withText(displayWord4)).check(matches(isDisplayed()));
        String score4 = tActivityRule.getActivity().scoreDisplay.getText().toString();
        onView(withText(score4)).check(matches(isDisplayed()));


        Espresso.closeSoftKeyboard();
        // Back in Game
        onView(withId(R.id.buttonExitGame)).perform(click());
        onView(withId(R.id.buttonGameSettings)).perform(click());

        // Game board 8 X 8
        onView(withId(R.id.inputSize)).perform(clearText(), replaceText("8"));
        onView(withId(R.id.buttonGameSettingsExit)).perform(click());

        onView(withId(R.id.buttonPlayGame)).perform(click());

        onView(withId(R.id.buttonGameBoard11)).perform(click());
        onView(withId(R.id.buttonGameBoard12)).perform(click());
        onView(withId(R.id.buttonGameBoard13)).perform(click());
        onView(withId(R.id.buttonGameBoard14)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard24)).perform(click());
        onView(withId(R.id.buttonGameBoard23)).perform(click());
        onView(withId(R.id.buttonGameBoard22)).perform(click());
        onView(withId(R.id.buttonGameBoard21)).perform(click());
        onView(withId(R.id.buttonGameBoard31)).perform(click());
        onView(withId(R.id.buttonGameBoard32)).perform(click());
        onView(withId(R.id.buttonGameBoard33)).perform(click());
        onView(withId(R.id.buttonGameBoard34)).perform(click());
        onView(withId(R.id.buttonGameBoard44)).perform(click());
        onView(withId(R.id.buttonGameBoard43)).perform(click());
        onView(withId(R.id.buttonGameBoard42)).perform(click());
        onView(withId(R.id.buttonGameBoard41)).perform(click());

        String displayWord5 = tActivityRule.getActivity().wordDisplay.getText().toString();
        onView(withText(displayWord5)).check(matches(isDisplayed()));
        String score5 = tActivityRule.getActivity().scoreDisplay.getText().toString();
        onView(withText(score5)).check(matches(isDisplayed()));







    }
}