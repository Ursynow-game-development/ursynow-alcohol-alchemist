namespace uaa.Phases;

public class Buying
{
    // Import zmiennych
    public static string userAnswer = Program.userAnswer;

    // Pętla główna
    public static void BuyingIngredients()
    {
        while (true)
        {
            Program.OutputStatus();
            Console.WriteLine("[GRA] - Nadszedl czas na uzupelnienie zapasow. Co kupujesz? (1-4)");
            OutputOptions();

            userAnswer = Console.ReadLine();
            Program.PlayClickSound();
            if (userAnswer == "4") { break; }
            switch (userAnswer)
            {
                case "1":
                    Program.ziemniaki += 2;
                    Program.cash -= 1;
                    Console.Clear();
                    Console.WriteLine("[GRA] - Kupiono ziemniaki");
                    break;
                case "2":
                    Program.zboze += 2;
                    Program.cash -= 2;
                    Console.Clear();
                    Console.WriteLine("[GRA] - Kupiono zboze");
                    break;
                case "3":
                    Program.cukier += 2;
                    Program.cash -= 3;
                    Console.Clear();
                    Console.WriteLine("[GRA] - Kupiono cukier");
                    break;
            }
        }
    }

    // Wyświetla dostępne opcje składników do kupienia
    public static void OutputOptions()
    {
        Console.WriteLine("█ Ziemniaki (2szt za 1zl)");
        Console.WriteLine("█ Zboze (2szt za 2zl)");
        Console.WriteLine("█ Cukier (2szt za 3zl)");
        Console.WriteLine("█ Juz starczy zakupow");
    }
}