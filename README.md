# Tennis Calculator

## How to run this console app
- cd to the TennisCalculator folder
- run `dotnet run`
- type Query
- type `exit` to quit


## How to run tests
- cd to the TennisCalculator.Tests folder
- `dotnet tests`

## Explanation
I designed the project in this structure:
- Player: Contains player's name and total won/lost games scores
- Game: Add points (15, 30, 40,..) for each game and check if current game is ended with a winner
- Set: Add 1 game score if a player wins 1 game. End the set if any player first win 6 games
- Match: Add 1 set score if a player wins 1 set. End the match if any player first win 2 sets from out of three sets

Then, Reader reads contents from the txt file line by line:
- A new match will start if the current line starts with "Match"
- Get MatchId and players infomation from the first two line of each match
- If the current line is a number, add one point to the winner
- Returns the TennisResult object when the reader goes to the end of the file

Next, ProcessQuery will get the input from user from the console, and grab the matchId or Player's name to retrieve matched data.


## Assumption
- Assume the input file is in valid format
- Assume player's name won't contain (vs)
- Assume user inputs valid query

## Note
- When checking the winner for a match, the requirments mentioned the winner should win 2 sets from out of three sets. However, the first match in sample input file only contains two sets.
Thus, I didn't check if there are three sets to let the sample file work.
- Sorry I didn't do enough validation and enough tests this time due to the timebox issue.


