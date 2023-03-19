namespace uaa.Phases;

public class Making
{
    // Import zmiennych
    public static string userAnswer = Program.userAnswer;
    public static float cukier = Program.cukier;
    public static float zboze = Program.zboze;
    public static float ziemniaki = Program.ziemniaki;
    public static IList<Alcohol> alcohols = Program.alcohols;
    public static List<Alcohol> playerAlcohols = Program.playerAlcohols;

    // Pętla główna
    public static void MakingAlcohol()
    {
        Alcohol selectedAlcohol;
        Console.Clear();

        while (true)
        {
            int alcoholsLength = alcohols.Count;
            Program.OutputStatus();
            Console.WriteLine("[GRA] - Pedzenie bimbru - pole wyboru (1-"+(alcoholsLength+1)+"):");
            OutputOptions();

            userAnswer = Console.ReadLine();
            if (userAnswer == (alcoholsLength+1).ToString()) { break; }
            
            MakeAlcoholIfPossible();
        }
    }

    public static void OutputOptions()
    {
        foreach (Alcohol a in alcohols)
        {
            Console.WriteLine("█ " + a.Name + " (cukier - " + a.RequiredCukier + "; zboze - " + a.RequiredZboze + "; ziemniaki - " + a.RequiredZiemniaki + ")");
        }
        Console.WriteLine("█ Juz starczy pedzenia na dzis");
    }

    public static void MakeAlcoholIfPossible ()
    {
        Alcohol selectedAlcohol = alcohols[Convert.ToInt32(userAnswer) - 1];
        if (selectedAlcohol.RequiredCukier <= cukier && selectedAlcohol.RequiredZboze <= zboze && selectedAlcohol.RequiredZiemniaki <= ziemniaki) 
        {
            Console.Clear();
            playerAlcohols.Add(selectedAlcohol);   
            cukier -= selectedAlcohol.RequiredCukier;
            zboze -= selectedAlcohol.RequiredZboze;
            ziemniaki -= selectedAlcohol.RequiredZiemniaki;
            Console.WriteLine("[GRA] - Udalo ci sie wytworzyc wybrany alkohol. Robimy cos jeszcze?");
        } 
        else 
        {
            Console.Clear();
            Console.WriteLine("[GRA] - Nie masz wystarczajaco skladnikow. Chcesz przyrzadzic jakis inny alkohol?");
        }
    }
}