namespace MathGame;

public class GameEngine
{
    private Random _random = new Random();

    public void StartGame(GameType gameType, GameDifficulty difficulty)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {gameType} Game (Difficulty: {difficulty})! Press q to quit.");
        Console.WriteLine(new string('-', 100));
        
        int questionNumber = 1;
        int correctAnswers = 0;
        int wrongAnswers = 0;
        bool quit = false;
        string[] operations = { "+", "-", "x", "/" }; // for random game mode
        
        while (true)
        {
            int userInput = 0, answer = 0;
            
            if (gameType == GameType.Addition)
            {
                (userInput, answer) = GenerateSingleQuestion(difficulty, "+", questionNumber, ref quit);
            }
            else if (gameType == GameType.Subtraction)
            {
                (userInput, answer) = GenerateSingleQuestion(difficulty, "-", questionNumber, ref quit);
            }
            else if (gameType == GameType.Multiplication)
            {
                (userInput, answer) = GenerateSingleQuestion(difficulty, "x", questionNumber, ref quit);
            }
            else if (gameType == GameType.Division)
            {
                (userInput, answer) = GenerateSingleQuestion(difficulty, "/", questionNumber, ref quit);
            }
            else
            {
                string randomOperation = operations[_random.Next(operations.Length)];
                (userInput, answer) = GenerateSingleQuestion(difficulty, randomOperation, questionNumber, ref quit);
            }
            
            if (quit)
            {
                break;
            }
            
            CheckAnswer(userInput, answer, ref correctAnswers, ref wrongAnswers, ref questionNumber);
        }
        
        Helpers.AddGameResult(gameType, difficulty, correctAnswers, wrongAnswers);
        Helpers.ShowLastGameResult();
    }

    private (int userInput, int answer) GenerateSingleQuestion(GameDifficulty difficulty, string operation, int questionNumber, ref bool quitGame)
    {
        int a, b;
        if (operation.Equals("/"))
        {
            do
            {
                a = _random.Next(-81, 81) * (int)difficulty;
                b = _random.Next(-9, 9) * (int)difficulty;
            } while (b == 0 || a % b != 0);
        }
        else
        {
            a = (operation.Equals("+") || operation.Equals("-")) ? _random.Next(-50, 50) * (int)difficulty : _random.Next(-9, 9) * (int)difficulty;
            b = (operation.Equals("+") || operation.Equals("-")) ? _random.Next(-50, 50) * (int)difficulty : _random.Next(-9, 9) * (int)difficulty;
        }

        Console.WriteLine($"Question #{questionNumber}: {a} {operation} {b}");
        Console.Write("Enter your answer (q to quit): ");
        string? userAnswer = Console.ReadLine();
        
        if (userAnswer?.ToLower().Trim() == "q")
        {
            quitGame = true;
            return (0, 0);
        }
        
        while (string.IsNullOrEmpty(userAnswer) || !float.TryParse(userAnswer, out _))
        {
            Console.WriteLine("Invalid answer. Please try again.");
            Console.WriteLine((operation.Equals("/")) ? $"Question #{questionNumber}: {a} {operation} {b}\t(Round to two decimal places if necessary)" :
                $"Question #{questionNumber}: {a} {operation} {b}");
            Console.Write("Enter your answer (q to quit): ");
            userAnswer = Console.ReadLine();
                
            if (userAnswer?.ToLower().Trim() == "q")
            {
                quitGame = true;
                return (0, 0);
            }
        }

        if (operation.Equals("+"))
        {
            return (Convert.ToInt32(userAnswer), a + b);
        }
        if (operation.Equals("-"))
        {
            return (Convert.ToInt32(userAnswer), a - b);
        }
        if (operation.Equals("x"))
        {
            return (Convert.ToInt32(userAnswer), a * b);
        }
        if (operation.Equals("/"))
        {
            return (Convert.ToInt32(userAnswer), a / b);
        }
        
        quitGame = true;
        return (0, 0);
    }

    private void CheckAnswer(int userInput, int answer, ref int correctAnswers, ref int wrongAnswers, ref int questionNumber)
    {
        if (userInput == answer)
        {
            Console.WriteLine("Correct!");
            correctAnswers++;
        }
        else
        {
            Console.WriteLine("Wrong!");
            wrongAnswers++;
        }
        
        questionNumber++;
        Console.WriteLine(new string('-', 100));
    }
}