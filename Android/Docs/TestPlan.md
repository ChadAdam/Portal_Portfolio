# Test Plan

**Author**: Team 106

**Version: 2.0** - Added partial test cases

## 1 Testing Strategy

### 1.1 Overall strategy

I will be implementing the testing operations for our application.  Unit tests will be created for each method that performs a calculation relavent to the word game.  If the method launches another method or only displays UI elements a unit test will not be applied to it.  For the unit tests I will provide several sets of desired input and output values to be tested against with each method.  Integration tests will be performed with espresso.

Regression testing will be performed by individual developers as they develop or modify features of the application by ensuring that all the tests pass before pushing their code back to the repository.

### 1.2 Test Selection

We will be using white box testing in which unit tests are created for individual methods.

### 1.3 Adequacy Criterion

The intent is to write a unit test that will cover the entire scope of a method.

### 1.4 Bug Tracking

Bugs and feature requests will be tracked in the GaTech GitHub repository under the issues tab.

### 1.5 Technology

JUnit will be used for the unit tests.  Espresso is used for regression tests

## 2 Test Cases

All implemented test cases passed.

| Class       |  Method Name               |  Input         |      Output     |  Test type   | Implemented| Description                |
|:------------|:---------------------------|:--------------:|:----------------|:-------------|:-----------|:---------------------------|
| Game        | reRoll                     | void           | True            | Unit         | False      |                            |
| Game        | exitGame                   | void           | True            | Unit         | False      |                            |
| Game        | finalScore                 | void           | True            | Unit         | False      |                            |
| Game        | viewScoreStatistics        | void           | True            | Unit         | False      |                            |
| Game        | viewWordStatistics         | void           | True            | Unit         | False      |                            |
| Game        | inputWord                  | "TestWord"     | IntegerScoreTBD | Unit         | False      |                            |
| Game        | inputWord                  | null           | Null            | Unit         | False      |                            |
| Game        | inputWord                  | "TestWord"     | Null            | Unit         | False      |                            |
| GameSettings| UpdateNumberOfMinutes      | void           | int             | Unit         | False      |                            |
| GameSettings| verifyElementsAvailability | void           | Bool            | Regression   | True       |Tests if elements visible   |
| GameSettings| verifyBoardSizeErrors      | int            | Bool            | Regression   | True       |Test board size error msg   |
| GameSettings| verifyMaxTimeErrors        | int            | Bool            | Regression   | True       |Test max time error msg     |
| GameSettings| validateTime               | int            | Bool            | Unit         | True       |Tests 3 and 8 minutes       |
| GameSettings| validateWeight             | int            | Bool            | Unit         | True       |Tests weights 1 and 10      |
| GameSettings| validateBoardSize          | int            | Bool            | Unit         | True       |Tests 2x2 and 4x4           |
| GameSettings| updateBoardSize            | int = 5        | True            | Unit         | False      |                            |
| GameSettings| updateBoardSize            | int = 6        | True            | Unit         | False      |                            |
| GameSettings| updateBoardSize            | int = 7        | True            | Unit         | False      |                            |
| GameSettings| updateBoardSize            | int = 8        | True            | Unit         | False      |                            |
| GameSettings| updateLetterWeights        | int[26]        | Map<Char, int>  | Unit         | False      |                            |
| GameSettings| validateNumberOfMinutes    | void           | True            | Unit         | False      |                            |
| WordCounter | validateBoardSize          | void           | True            | Unit         | False      |                            |
| Application | Game                       | void           | True            | Regression   | True       | All board layouts and input|


