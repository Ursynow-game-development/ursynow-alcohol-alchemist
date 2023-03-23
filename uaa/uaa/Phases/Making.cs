namespace uaa.Phases;

public class Making
{
    // Import zmiennych
    public static string userAnswer = Program.userAnswer;

    // Pętla główna
    public static void MakingAlcohol()
    {
        Console.Clear();

        while (true)
        {
            int alcoholsLength = Program.alcohols.Count;
            Program.OutputStatus();
            Console.WriteLine("[GRA] - Pedzenie bimbru - pole wyboru (1-"+(alcoholsLength+1)+")");
            OutputOptions();

            userAnswer = Console.ReadLine();
            Program.PlayClickSound();
            if (userAnswer == (alcoholsLength + 1).ToString())
            {
                break;
            }
            MakeAlcoholIfPossible();
        }
    }

    // Wyświetla dostępne opcje pędzenia bimbru
    public static void OutputOptions()
    {
        foreach (Alcohol a in Program.alcohols)
        {
            Console.WriteLine("█ " + a.Name + " (cukier - " + a.RequiredCukier + "; zboze - " + a.RequiredZboze + "; ziemniaki - " + a.RequiredZiemniaki + ")");
        }
        Console.WriteLine("█ Juz starczy pedzenia na dzis");
    }

    // Sprawdza czy masz składniki po czym tworzy alkohol
    public static void MakeAlcoholIfPossible ()
    {
        Alcohol selectedAlcohol = Program.alcohols[Convert.ToInt32(userAnswer) - 1];
        if (selectedAlcohol.RequiredCukier <= Program.cukier && selectedAlcohol.RequiredZboze <= Program.zboze && selectedAlcohol.RequiredZiemniaki <= Program.ziemniaki) 
        {
            Console.Clear();
            Program.playerAlcohols.Add(selectedAlcohol);   
            Program.cukier -= selectedAlcohol.RequiredCukier;
            Program.zboze -= selectedAlcohol.RequiredZboze;
            Program.ziemniaki -= selectedAlcohol.RequiredZiemniaki;
            Console.WriteLine("[GRA] - Udalo ci sie wytworzyc wybrany alkohol. Robimy cos jeszcze?");
        } 
        else 
        {
            Console.Clear();
            Console.WriteLine("[GRA] - Nie masz wystarczajaco skladnikow. Chcesz przyrzadzic jakis inny alkohol?");
        }
    }
}