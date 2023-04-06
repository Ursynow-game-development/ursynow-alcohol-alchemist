namespace uaa.Phases;

public class Buying
{
    public static string userAnswer = Program.userAnswer;

    public static void BuyingIngredients()
    {
        while (true)
        {
            Program.OutputStatus();
            Console.WriteLine("[GRA] - Nadszedl czas na uzupelnienie zapasow. Co kupujesz? (1-4)");
            OutputOptions();
            userAnswer = Console.ReadLine();
            Program.PlayClickSound();
            
            if (userAnswer == "4") 
                break;
            
            Console.Clear();
            switch (userAnswer)
            {
                case "1":
                    Program.ziemniaki += 2;
                    Program.cash -= 1;
                    Console.WriteLine("[GRA] - Kupiono ziemniaki");
                    break;
                case "2":
                    Program.zboze += 2;
                    Program.cash -= 2;
                    Console.WriteLine("[GRA] - Kupiono zboze");
                    break;
                case "3":
                    Program.cukier += 2;
                    Program.cash -= 3;
                    Console.WriteLine("[GRA] - Kupiono cukier");
                    break;
            }
        }
    }

    // Wyświetla dostępne opcje składników do kupienia
    public static void OutputOptions()
    {
        Console.WriteLine("█ Ziemniaki (2szt / 1zl)");
        Console.WriteLine("█ Zboze (2szt / 2zl)");
        Console.WriteLine("█ Cukier (2szt / 3zl)");
        Console.WriteLine("█ Juz starczy zakupow");
    }
}