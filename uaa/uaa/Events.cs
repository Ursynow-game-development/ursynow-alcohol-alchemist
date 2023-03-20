namespace uaa;

public class Events
{
    public static string userAnswer = Program.userAnswer;
    
    // Losowanie niespodziewanego wydarzenia
    public static void RandomEvent()
    {
        Console.Clear();
        Console.WriteLine("[GRA] - Nastapilo nieoczekiwane wydarzenie");
        Thread.Sleep(2000);
        int randomEventIndex = new Random().Next(3);
        switch (randomEventIndex)
        {
            case 0:
                Event_Thief();
                break;
            case 1:
                Event_Potatoes();
                break;
            case 2:
                Event_ElonMusk();
                break;
        }
        
        Thread.Sleep(3000);
        Console.Clear();
    }

    // Event 1 - złodziej
    public static void Event_Thief()
    {
        string randomPersonName = Program.person[new Random().Next(Program.person.Count)].Name;
        
        Thread.Sleep(2000);
        Console.WriteLine("Podchodzi do ciebie niezadowolony klient");
        Thread.Sleep(2000);
        Console.WriteLine("[" + randomPersonName + "] - Co to kur** jest za alkohol nie smakuje mi, zabije cie");
        Thread.Sleep(2000);
        Console.WriteLine("Musisz szybko wybrac co  (1-3)");
        Console.WriteLine("█ Bije sie z typem");
        Console.WriteLine("█ Mowie mu aby wsadzil sobie ten alkohol wiadomo gdzie");
        Console.WriteLine("█ Proponuje znizke 10% na nastepny alkohol w ramach zadoscuczynienia");

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

    // Event 2 - Ziemniaki
    public static void Event_Potatoes()
    {
        Console.WriteLine("Znalazles na ulicy 4 ziemniaki");
        Program.ziemniaki += 4;
        Thread.Sleep(2000);
        Console.WriteLine("Jestes farciarzem gratuluje");
    }

    // Event 3 - Elon musk
    public static void Event_ElonMusk()
    {
        Console.WriteLine("[Elon Musk] - witam chcialbym abys nauczyl mnie jak robic bimber z ktorego bede mogl zrobic paliwo rakietowe");
        Thread.Sleep(3500);
        Console.WriteLine("[GRA] - Co odpowiadasz?");
        Console.WriteLine("█ No dobra");
        Console.WriteLine("█ Nie ma mowy");

        userAnswer = Console.ReadLine();
        Program.PlayClickSound();
        switch (userAnswer)
        {
            case "1":
                Console.WriteLine("[GRA] - Zapoznajesz elona muska z tajnikami pedzenia bimbru. Otrzymujesz 40 kasy ale tracisz 15 respektu poniewaz zdradziles tajemny przepis");
                Thread.Sleep(4000);
                Program.reputation -= 15;
                Program.cash += 40;
                break;
            case "2":
                Console.WriteLine("[GRA] - Mowisz elonowi aby poszedl dzieciom gadac te bajeczki o kosmosie");
                Thread.Sleep(2000);
                break;
        }
    }
}