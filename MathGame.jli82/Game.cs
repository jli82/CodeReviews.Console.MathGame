namespace MathGame;

public class Game
{
    internal GameType GameType;
    internal GameDifficulty GameDifficulty;
    internal int CorrectAnswers;
    internal int WrongAnswers;
    internal int TotalQuestions;

    public Game(GameType gameType, GameDifficulty gameDifficulty, int correctAnswers, int wrongAnswers,  int totalQuestions)
    {
        GameType = gameType;
        GameDifficulty = gameDifficulty;
        CorrectAnswers = correctAnswers;
        WrongAnswers = wrongAnswers;
        TotalQuestions = totalQuestions;
    }

    public override string ToString()
    {
        string gameName = $"{GameType} ({GameDifficulty})";
        return $"{gameName, -30}- \t {CorrectAnswers} correct \t {WrongAnswers} wrong \t Correct Percentage: {((float)CorrectAnswers / TotalQuestions):P2}";
    }
}