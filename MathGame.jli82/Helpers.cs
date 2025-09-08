namespace MathGame;

public static class Helpers
{
    private static List<Game> _gameHistory = new List<Game>() ;

    public static int GameCount()
    {
        return _gameHistory.Count;
    }
    
    public static void AddGameResult(GameType gameType, GameDifficulty gameDifficulty, int correctAnswers, int wrongAnswers)
    {
        _gameHistory.Add(new Game(gameType, gameDifficulty, correctAnswers, wrongAnswers, (correctAnswers + wrongAnswers)));
    }

    public static void ShowLastGameResult()
    {
        Game game = _gameHistory.Last();
        Console.Clear();
        Console.WriteLine(new string('-', 100));
        Console.WriteLine($"{game.GameType} Game Results:");
        Console.WriteLine($"Correct answers: {game.CorrectAnswers}\tWrong answers: {game.WrongAnswers}");
        Console.WriteLine($"Total number of questions: {game.TotalQuestions}\t" +
                          $"Correct Percentage: {((float)game.CorrectAnswers / game.TotalQuestions):P2}");
        Console.WriteLine(new string('-', 100));
        Console.WriteLine("\nPress any key to go back to main menu...");
        Console.ReadKey();
    }

    public static void ShowGameHistory()
    {
        Console.Clear();
        Console.WriteLine("Game History:");
        Console.WriteLine(new string('-', 100));
        foreach (Game game in _gameHistory)
        {
            Console.WriteLine(game);
        }
        Console.WriteLine(new string('-', 100));
        
        Console.WriteLine("Press any key to go back to main menu...");
        Console.ReadKey();
    }
}