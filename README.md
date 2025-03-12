#RPSChallenge

This is a simple console-based Rock-Paper-Scissors game implemented in C#. The user plays against an AI opponent, and the game keeps track of the score over multiple turns.

## Features

- User vs AI gameplay
- Random AI move generation
- Turn-based gameplay with score tracking
- Color-coded results display
- Option to replay the game

## How to Run

1. Clone the repository or download the source code.
2. Open the solution in Visual Studio 2022.
3. Build the solution to restore the necessary packages.
4. Run the project.

## Gameplay Instructions

1. When prompted, enter the number of turns you want to play (between 1 and 10).
2. For each turn, select your move by entering the corresponding number:
   - 1: Rock
   - 2: Paper
   - 3: Scissors
3. The AI will randomly select its move.
4. The result of each turn will be displayed, showing the moves and the winner.
5. After all turns are completed, the final score and overall winner will be displayed.
6. You will be prompted to play again. Enter 'Y' to replay or 'N' to exit.

## Code Structure

- `GameProgram`: The main class containing the game logic.
- `MoveSelection`: Enum representing the possible moves (Rock, Paper, Scissors).
- `MatchResult`: Enum representing the possible outcomes of a turn (User, AI, Tie).
- `GameTurn`: Struct representing a single turn in the game.
- `FinalScore`: Struct representing the final score after all turns.

## Example
How many turns (1-10)? 3
- Turn [1] starting: Select your move: [1]:Rock, [2]:Paper, [3]:Scissors? 1
- === Turn [1] ===
- Your Move : Rock
- AI Move   : Scissors
- Winner    : [User]
- Turn [2] starting: Select your move: [1]:Rock, [2]:Paper, [3]:Scissors? 2
- === Turn [2] ===
- Your Move : Paper
- AI Move   : Rock
- Winner    : [User]
- Turn [3] starting: Select your move: [1]:Rock, [2]:Paper, [3]:Scissors? 3
- === Turn [3] ===
- Your Move : Scissors
- AI Move   : Rock
- Winner    : [AI]
- === MATCH CONCLUDED ===
- === FINAL SCORE ===
- Total Turns    : 3
- User Victories : 2
- AI Victories   : 1
- Ties           : 0
- Champion       : User
- Play again? (Y/N)
