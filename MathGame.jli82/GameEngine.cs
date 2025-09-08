namespace MathGame;

public class GameEngine
{
    private Random _random = new Random();
    
    public void AdditionGame(GameDifficulty difficulty)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the Addition Game (Difficulty: {difficulty})! Press q to quit.");
        Console.WriteLine(new string('-', 100));
        
        int questionNumber = 1;
        int correctAnswers = 0;
        int wrongAnswers = 0;

        while (true)
        {
            (float userInput, float answer) = GenerateSingleQuestion(difficulty, "+", questionNumber);
            
            if (userInput == Int16.MaxValue && answer == Int16.MinValue)
            {
                break;
            }
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
        
        Helpers.AddGameResult(GameType.Addition, difficulty, correctAnswers, wrongAnswers);
        Helpers.ShowLastGameResult();
    }

    public void SubtractionGame(GameDifficulty difficulty) 
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Subtraction Game! Press q to quit.");
        Console.WriteLine(new string('-', 100));
        
        int questionNumber = 1;
        int correctAnswers = 0;
        int wrongAnswers = 0;

        while (true)
        {
            (float userInput, float answer) = GenerateSingleQuestion(difficulty, "-", questionNumber);
            
            if (userInput == Int16.MaxValue && answer == Int16.MinValue)
            {
                break;
            }
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
        
        Helpers.AddGameResult(GameType.Subtraction, difficulty, correctAnswers, wrongAnswers);
        Helpers.ShowLastGameResult();
    }

    public void MultiplicationGame(GameDifficulty difficulty) 
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Multiplication Game! Press q to quit.");
        Console.WriteLine(new string('-', 100));
        
        int questionNumber = 1;
        int correctAnswers = 0;
        int wrongAnswers = 0;

        while (true)
        {
            (float userInput, float answer) = GenerateSingleQuestion(difficulty, "x", questionNumber);
            
            if (userInput == Int16.MaxValue && answer == Int16.MinValue)
            {
                break;
            }
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
        
        Helpers.AddGameResult(GameType.Multiplication, difficulty, correctAnswers, wrongAnswers);
        Helpers.ShowLastGameResult();
    }

    public void DivisionGame(GameDifficulty difficulty) 
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Division Game! Press q to quit.");
        Console.WriteLine(new string('-', 100));
        
        int questionNumber = 1;
        int correctAnswers = 0;
        int wrongAnswers = 0;

        while (true)
        {
            (float userInput, float answer) = GenerateSingleQuestion(difficulty, "/", questionNumber);
            
            if (userInput == Int16.MaxValue && answer == Int16.MinValue)
            {
                break;
            }
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
        
        Helpers.AddGameResult(GameType.Division, difficulty, correctAnswers, wrongAnswers);
        Helpers.ShowLastGameResult();
    }

    private (float userInput, float answer) GenerateSingleQuestion(GameDifficulty difficulty, string operation, int questionNumber)
    {
        int a, b;
        if (operation.Equals("/"))
        {
            do
            {
                a = _random.Next(-81, 81) * (int)difficulty;
                b = _random.Next(-9, 9) * (int)difficulty;
            } while (b == 0);
        }
        else
        {
            a = (operation.Equals("+") || operation.Equals("-")) ? _random.Next(-50, 50) * (int)difficulty : _random.Next(-9, 9) * (int)difficulty;
            b = (operation.Equals("+") || operation.Equals("-")) ? _random.Next(-50, 50) * (int)difficulty : _random.Next(-9, 9) * (int)difficulty;
        }
        
        Console.WriteLine((operation.Equals("/")) ? $"Question #{questionNumber}: {a} {operation} {b}\t(Round to two decimal places if necessary)" :
            $"Question #{questionNumber}: {a} {operation} {b}");
        Console.Write("Enter your answer (q to quit): ");
        string? userAnswer = Console.ReadLine();
        
        if (userAnswer?.ToLower().Trim() == "q")
        {
            return (Int16.MaxValue, Int16.MinValue);
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
                return (Int16.MaxValue, Int16.MinValue);
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
            return ((float)Math.Round(Convert.ToDouble(userAnswer), 2), (float)Math.Round((float)a / b, 2));
        }
        
        return (Int16.MaxValue, Int16.MinValue);
    }

    public void RandomGame(GameDifficulty difficulty)
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the Random Game (Difficulty: {difficulty})! Press q to quit.");
        Console.WriteLine(new string('-', 100));
        
        int questionNumber = 1;
        int correctAnswers = 0;
        int wrongAnswers = 0;
        string[] operations = { "+", "-", "x", "/" };

        while (true)
        {
            string operation = operations[_random.Next(operations.Length)];
            
            (float userInput, float answer) = GenerateSingleQuestion(difficulty, operation, questionNumber);
            
            // if user enter "q", then userInput=Int16.MaxValue and answer=Int16.MinValue
            if (userInput == Int16.MaxValue && answer == Int16.MinValue)
            {
                break;
            }
            
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
        
        Helpers.AddGameResult(GameType.Random, difficulty, correctAnswers, wrongAnswers);
        Helpers.ShowLastGameResult();
    }
}