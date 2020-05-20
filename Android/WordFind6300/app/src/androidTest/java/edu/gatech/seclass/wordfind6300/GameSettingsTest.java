package edu.gatech.seclass.wordfind6300;

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


/**
 * This is a Georgia Tech provided code example for use in assigned private GT repositories. Students and other users of this template
 * code are advised not to share it with other students or to make it available on publicly viewable websites including
 * repositories such as github and gitlab.  Such sharing may be investigated as a GT honor code violation. Created for CS6300.
 */


@RunWith(AndroidJUnit4.class)
public class GameSettingsTest {

    @Rule
    public ActivityTestRule<GameSettings> tActivityRule = new ActivityTestRule<>(
            GameSettings.class);




    @Test
    public void verifyElementsAvailability() {
        onView(withId(R.id.viewTime)).perform(click()).check(matches(isDisplayed()));
        onView(withId(R.id.viewSize)).perform(click()).check(matches(isDisplayed()));
        onView(withId(R.id.inputSize)).perform(click()).check(matches(isDisplayed()));
        onView(withId(R.id.inputTime)).perform(click()).check(matches(isDisplayed()));
        Espresso.closeSoftKeyboard();
        onView(withId(R.id.buttonGameSettingsExit)).check(matches(isClickable()));
    }

    @Test
    public void verifyBoardSizeErrors() {

        onView(withId(R.id.inputSize)).perform(clearText(), replaceText("100"));
        Espresso.closeSoftKeyboard();
        onView(withId(R.id.buttonGameSettingsExit)).perform(click());
        onView(withId(R.id.inputSize)).check(matches(hasErrorText("Board size should be between 4 and 8.")));
    }

    @Test
    public void verifyMaxTimeErrors() {

        onView(withId(R.id.inputTime)).perform(clearText(), replaceText("100"));
        Espresso.closeSoftKeyboard();
        onView(withId(R.id.buttonGameSettingsExit)).perform(click());
        onView(withId(R.id.inputTime)).check(matches(hasErrorText("Minutes should be between 1 and 5.")));


    }

    @Test
    public void validateTime_True() {
        String testVal = "3";
        Assert.assertEquals(GameSettings.validateTime(testVal),true);
    }

    @Test
    public void validateTime_False() {
        String testVal = "8";
        Assert.assertEquals(GameSettings.validateTime(testVal),false);
    }

    @Test
    public void validateBoardSize_True() {
        String testVal = "4";
        Assert.assertEquals(GameSettings.validateBoardSize(testVal),true);
    }

    @Test
    public void validateBoardSize_False() {
        String testVal = "2";
        Assert.assertEquals(GameSettings.validateBoardSize(testVal),false);
    }

    @Test
    public void ValidateWeight_True() {
        Assert.assertEquals(GameSettings.validateWeight("1"),true);
    }

    @Test
    public void ValidateWeight_False() {
        Assert.assertEquals(GameSettings.validateWeight("10"),false);
    }

}