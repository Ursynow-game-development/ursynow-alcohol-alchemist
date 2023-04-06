namespace uaa;

public class Events
{
    public static string userAnswer = Program.userAnswer;
    
    public static void RandomEvent()
    {
        Console.Clear();
        Console.WriteLine("[GRA] - Nastapilo nieoczekiwane wydarzenie");
        Thread.Sleep(2000);
        int randomEventIndex = new Random().Next(5);
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
            case 3:
                Event_Bombilion();
                break;
            case 4:
                Event_Client();
                break;
        } 
        Thread.Sleep(3000);
        Console.Clear();
    }

    // Event 1 - złodziej
    public static void Event_Thief()
    {
        string randomPersonName = Program.persons[new Random().Next(Program.persons.Count)].Name;
        
        Thread.Sleep(2000);
        Console.WriteLine("Podchodzi do ciebie niezadowolony klient");
        Thread.Sleep(2000);
        Console.WriteLine("[" + randomPersonName + "] - Co to kur** jest za alkohol nie smakuje mi, zabije cie");
        Thread.Sleep(2000);
        Console.WriteLine("Musisz szybko wybrac co robic (1-3)");
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
                Console.WriteLine("[GRA] - Zapoznajesz elona muska z tajnikami pedzenia bimbru. Otrzymujesz 30 kasy ale tracisz 10 respektu poniewaz zdradziles tajemny przepis");
                Thread.Sleep(4000);
                Program.reputation -= 10;
                Program.cash += 30;
                break;
            case "2":
                Console.WriteLine("[GRA] - Mowisz elonowi aby poszedl dzieciom gadac te bajeczki o kosmosie");
                Thread.Sleep(2000);
                break;
        }
    }
    
    //Event 4 - Bombiliony
    public static void Event_Bombilion()
    {
        Console.WriteLine("[GRA] - Nad twoim stoiskiem przelatuje bombilion wyslany przez zadymiarzy z wrzeciona. Co robisz? (1-3)");
        Console.WriteLine("█ Zestrzeliwuje go uzywajac wyrzutni kalafiorow");
        Console.WriteLine("█ Chowam sie do bunkra");
        Console.WriteLine("█ Mam go gdzies");
        
        userAnswer = Console.ReadLine();
        Program.PlayClickSound();
        switch (userAnswer)
        {
            case "1":
                Console.Clear();
                int position = new Random().Next(1000, 2000);
                string positionBinary = Convert.ToString(position, 2);
                Console.WriteLine(positionBinary);
                Console.WriteLine("=== WYRZUTNIA KALAFIOROW ROCKET SYSTEM ===");
                Console.WriteLine("Pozycja bombiliona na radarze: " + positionBinary);
                Console.WriteLine("Aby wprowadzic pozycje do strzalu wprowadz liczbe w systemie dziesietnym:");
                userAnswer = Console.ReadLine();
                Program.PlayClickSound();

                if (userAnswer == position.ToString())
                {
                    Console.WriteLine("Bombilion zostal zestrzelony");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Wpisales zla pozycje, bombilion cie zestrzelil");
                    Thread.Sleep(2000);
                    Console.WriteLine("Umierasz");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
                break;
            case "2":
                Console.WriteLine("[GRA] - Chowajac sie do bunkra ratujesz swoje zycie ale tracisz wszystkie alkohole");
                Program.playerAlcohols = null;
                Thread.Sleep(2000);
                break;
            case "3":
                Console.WriteLine("Umierasz poniewaz stales jak slup na zestrzelenie");
                Thread.Sleep(2000);
                Environment.Exit(0);
                break;
        }
    }
    
    // Event 5 - Tajemniczy klient
    public static void Event_Client()
    {
        Console.WriteLine("[GRA] - Podchodzi do ciebie tajemniczy klient");
        Thread.Sleep(1500);
        Console.WriteLine("[KLIENT] - Potrzebuje najmocniejszy alkohol jaki tylko masz - mocarza");
        Thread.Sleep(1500);
        
        if (Program.playerAlcohols.Contains(new Alcohol("mocarz",2f, 2f, 11f, 38)))
        {
            Console.WriteLine("[GRA] - Akurat posiadasz na stanie, czy chcesz mu go dac? (1-2)");
            Console.WriteLine("█ Tak");
            Console.WriteLine("█ Nie");
            userAnswer = Console.ReadLine();
            Program.PlayClickSound();

            switch (userAnswer)
            {
                case "1":
                    Console.WriteLine("[KLIENT] - Dobra jednak nie chce zegnaj");
                    break;
                case "2":
                    Console.WriteLine("[KLIENT] - Dobra to ide do konkurencji");
                    break;
            }
        }
        else
            Console.WriteLine("[GRA - Niestety nie posiadasz tego alkoholu na stanie");
    }
}