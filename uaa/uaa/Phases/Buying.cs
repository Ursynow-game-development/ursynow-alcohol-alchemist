﻿namespace uaa.Phases;

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
            Program.OutputStatus();
            Console.WriteLine("[GRA] - Nadszedl czas na uzupelnienie zapasow. Co kupujesz? (1-4)");
            OutputOptions();

            userAnswer = Console.ReadLine();
            Program.SelectSound();
            if (userAnswer == "4") { break; }
            switch (userAnswer)
            {
                case "1":
                    ziemniaki += 2;
                    cash -= 1;
                    Console.Clear();
                    Console.WriteLine("[GRA] - Kupiono ziemniaki");
                    break;
                case "2":
                    zboze += 2;
                    cash -= 2;
                    Console.Clear();
                    Console.WriteLine("[GRA] - Kupiono zboze");
                    break;
                case "3":
                    cukier += 2;
                    cash -= 3;
                    Console.Clear();
                    Console.WriteLine("[GRA] - Kupiono cukier");
                    break;
            }
        }
    }

    public static void OutputOptions()
    {
        Console.WriteLine("█ Ziemniaki (2szt za 1zl)");
        Console.WriteLine("█ Zboze (2szt za 2zl)");
        Console.WriteLine("█ Cukier (2szt za 3zl)");
        Console.WriteLine("█ Juz starczy zakupow");
    }
}