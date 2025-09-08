using MathGame;

DateTime date = DateTime.Now;
string name = GetName().Trim();

// Game start
Menu menu = new Menu();
menu.ShowMenu(date, name);


string GetName()
{
    Console.Write("Enter your name to start the game (press enter to use default name \"Player\"): ");
    string? s = Console.ReadLine();
    if (s.Equals(""))
    {
        s = "Player";
    }

    return s;
}


