using System.Reflection;

namespace RPSChallenge
{
    internal class GameProgram
    {
        enum MoveSelection { Rock = 1, Paper = 2, Scissors = 3 }
        enum MatchResult { User = 1, AI = 2, Tie = 3 }

        struct GameTurn
        {
            public int TurnNumber;
            public MoveSelection UserMove;
            public MoveSelection AIMove;
            public MatchResult Victor;
            public string VictorName;
        }

        struct FinalScore
        {
            public short TotalTurns;
            public short UserVictories;
            public short AIVictories;
            public short TieCount;
            public MatchResult OverallWinner;
            public string ChampionName;
        }

        static Random rng = new Random();
        static int GenerateRandom(int min, int max)
        {
            return rng.Next(min, max + 1);
        }

        static MatchResult DetermineTurnWinner(GameTurn turn)
        {
            if (turn.UserMove == turn.AIMove)
                return MatchResult.Tie;

            switch (turn.UserMove)
            {
                case MoveSelection.Rock:
                    if (turn.AIMove == MoveSelection.Paper)
                        return MatchResult.AI;
                    break;
                case MoveSelection.Paper:
                    if (turn.AIMove == MoveSelection.Scissors)
                        return MatchResult.AI;
                    break;
                case MoveSelection.Scissors:
                    if (turn.AIMove == MoveSelection.Rock)
                        return MatchResult.AI;
                    break;
            }
            return MatchResult.User;
        }

        static MatchResult CalculateGameWinner(int userWins, int aiWins)
        {
            if (userWins > aiWins)
                return MatchResult.User;
            else if (aiWins > userWins)
                return MatchResult.AI;
            else
                return MatchResult.Tie;
        }

        static MoveSelection GetUserSelection()
        {
            int input;
            do
            {
                Console.WriteLine("\nSelect your move: [1]:Rock, [2]:Paper, [3]:Scissors?");
                input = Convert.ToInt32(Console.ReadLine());
            } while (input < 1 || input > 3);

            return (MoveSelection)input;
        }

        static MoveSelection GenerateAIMove()
        {
            return (MoveSelection)GenerateRandom(1, 3);
        }

        static string NameWinner(MatchResult result)
        {
            string[] names = { "User", "AI", "Tie" };
            return names[(int)result - 1];
        }

        static string NameMove(MoveSelection move)
        {
            string[] moves = { "Rock", "Paper", "Scissors" };
            return moves[(int)move - 1];
        }

        static void ApplyVictoryColor(MatchResult result)
        {
            switch (result)
            {
                case MatchResult.User:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case MatchResult.AI:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Beep();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
        }

        static void DisplayTurnOutcome(GameTurn turn)
        {
            Console.WriteLine($"\n=== Turn [{turn.TurnNumber}] ===");
            Console.WriteLine($"Your Move : {NameMove(turn.UserMove)}");
            Console.WriteLine($"AI Move   : {NameMove(turn.AIMove)}");
            Console.WriteLine($"Winner    : [{turn.VictorName}]");
            Console.WriteLine("====================");
            ApplyVictoryColor(turn.Victor);
        }

        static FinalScore CompileResults(int turns, int userWins, int aiWins, int ties)
        {
            FinalScore score = new FinalScore
            {
                TotalTurns = (short)turns,
                UserVictories = (short)userWins,
                AIVictories = (short)aiWins,
                TieCount = (short)ties
            };
            score.OverallWinner = CalculateGameWinner(userWins, aiWins);
            score.ChampionName = NameWinner(score.OverallWinner);
            return score;
        }

        static FinalScore ExecuteGame(int turnCount)
        {
            GameTurn currentTurn = new GameTurn();
            int userWins = 0, aiWins = 0, ties = 0;

            for (int turn = 1; turn <= turnCount; turn++)
            {
                Console.WriteLine($"\nTurn [{turn}] starting:");
                currentTurn.TurnNumber = turn;
                currentTurn.UserMove = GetUserSelection();
                currentTurn.AIMove = GenerateAIMove();
                currentTurn.Victor = DetermineTurnWinner(currentTurn);
                currentTurn.VictorName = NameWinner(currentTurn.Victor);

                if (currentTurn.Victor == MatchResult.User)
                    userWins++;
                else if (currentTurn.Victor == MatchResult.AI)
                    aiWins++;
                else
                    ties++;

                DisplayTurnOutcome(currentTurn);
            }
            return CompileResults(turnCount, userWins, aiWins, ties);
        }

        static void ShowEndScreen()
        {
            Console.WriteLine("\n\t=== MATCH CONCLUDED ===");
        }

        static void PresentFinalStats(FinalScore score)
        {
            Console.WriteLine("\t=== FINAL SCORE ===");
            Console.WriteLine($"\tTotal Turns    : {score.TotalTurns}");
            Console.WriteLine($"\tUser Victories : {score.UserVictories}");
            Console.WriteLine($"\tAI Victories   : {score.AIVictories}");
            Console.WriteLine($"\tTies           : {score.TieCount}");
            Console.WriteLine($"\tChampion       : {score.ChampionName}");
            Console.WriteLine("\t==================");
            ApplyVictoryColor(score.OverallWinner);
        }

        static int PromptTurnCount()
        {
            int turns;
            do
            {
                Console.WriteLine("How many turns (1-10)?");
                turns = Convert.ToInt32(Console.ReadLine());
            } while (turns < 1 || turns > 10);

            return turns;
        }

        static void ClearDisplay()
        {
            Console.Clear();
            Console.ResetColor();
        }

        static void LaunchGame()
        {
            char replay = 'Y';
            do
            {
                ClearDisplay();
                FinalScore finalScore = ExecuteGame(PromptTurnCount());
                ShowEndScreen();
                PresentFinalStats(finalScore);
                Console.WriteLine("\n\tPlay again? (Y/N)");
                replay = Convert.ToChar(Console.ReadLine().ToUpper());
            } while (replay == 'Y');
        }

        static void Main(string[] args)
        {
            LaunchGame();
        }
    }
}