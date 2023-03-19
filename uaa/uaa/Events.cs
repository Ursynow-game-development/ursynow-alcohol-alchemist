namespace uaa;

public class Events
{
    public static string userAnswer = Program.userAnswer;
    
    public static void RandomEvent()
    {
        Console.Clear();
        Console.WriteLine("[GRA] - Nastapilo nieoczekiwane wydarzenie");
        Thread.Sleep(2000);
        int randomEventIndex = new Random().Next(2);
        switch (randomEventIndex)
        {
            case 0:
                Event_Thief();
                break;
            case 1:
                Event_Potatoes();
                break;
        }
        
        Thread.Sleep(3000);
        Console.Clear();
    }

    public static void Event_Thief()
    {
        string randomPersonName = Program.person[new Random().Next(Program.person.Count)].Name;
        
        Thread.Sleep(2000);
        Console.WriteLine("Podchodzi do ciebie niezadowolony klient");
        Thread.Sleep(2000);
        Console.WriteLine("[" + randomPersonName + "] - Co to kur** jest za alkohol nie smakuje mi, zabije cie");
        Thread.Sleep(2000);
        Console.WriteLine("Musisz szybko wybrac co  (1-3)");
        Console.WriteLine("* Bije sie z typem");
        Console.WriteLine("* Mowie mu aby wsadzil sobie ten alkohol wiadomo gdzie");
        Console.WriteLine("* Proponuje znizke 10% na nastepny alkohol w ramach zadoscuczynienia");

        Thread.Sleep(1000);
        userAnswer = Console.ReadLine();
        Program.PlayClickSound();
        switch (userAnswer)
        {
            case "1":
                Console.WriteLine("Bijac sie z typem wygrywasz poniewaz to byl jakis lamus");
                Program.reputation += 30;
                break;
            case "2":
                Console.WriteLine("[" + randomPersonName + "] - dobra to pozegnaj sie z zyciem");
                Thread.Sleep(2000);
                Console.WriteLine("[GRA] - Dedasz");
                Thread.Sleep(2000);
                Environment.Exit(0);
                break;
            case "3":
                Console.WriteLine("[" + randomPersonName + "] - ale super oferta az z wrazenia cie zabije");
                Thread.Sleep(2000);
                Console.WriteLine("[GRA] - Dedasz");
                Thread.Sleep(2000);
                Environment.Exit(0);
                break;
        }
    }

    public static void Event_Potatoes()
    {
        Console.WriteLine("Znalazles na ulicy 4 ziemniaki");
        Program.ziemniaki += 4;
        Thread.Sleep(2000);
        Console.WriteLine("Jestes farciarzem gratuluje");
    }
}