namespace uaa.Phases;

public class Buying
{
    public static string userAnswer = Program.userAnswer;
    public static float cukier = Program.cukier;
    public static float zboze = Program.zboze;
    public static float ziemniaki = Program.ziemniaki;
    public static int cash = Program.cash;

    public static void BuyingIngredients()
    {
        while (true)
        {
            Console.Clear();
            Program.OutputStatus();
            Console.WriteLine("[GRA] - Nadszedl czas na uzupelnienie zapasow. Co kupujesz? (1-4)");
            OutputOptions();

            userAnswer = Console.ReadLine();
            if (userAnswer == "4") { break; }

            if (userAnswer == "1")
            {
                ziemniaki += 2;
                cash -= 1;
                Console.WriteLine("[GRA] - Kupiono ziemniaki");
            } 
            else if (userAnswer == "2")
            {
                zboze += 2;
                cash -= 2;
                Console.WriteLine("[GRA] - Kupiono zboze");
            } 
            else if (userAnswer == "3")
            {
                cukier += 2;
                cash -= 3;
                Console.WriteLine("[GRA] - Kupiono cukier");
            }
            Thread.Sleep(1000);
        }
    }

    public static void OutputOptions()
    {
        Console.WriteLine("* Ziemniaki (2szt za 1zl)");
        Console.WriteLine("* Zboze (2szt za 2zl)");
        Console.WriteLine("* Cukier (2szt za 3zl)");
        Console.WriteLine("* Juz starczy zakupow");
    }
}