namespace uaa.Phases;

public class Selling
{
    // Import zmiennych
    public static string userAnswer = Program.userAnswer;
    public static int cash = Program.cash;
    public static int reputation = Program.reputation;
    public static IList<Alcohol> playerAlcohols = Program.playerAlcohols;
    public static IList<Person> person = Program.person;
    public static Alcohol selectedAlcoholToPerson;
    
    // Pętla główna
    public static void SellingAlcohol()
    {
        int selectedPerson;
        
            
        while (true)
        {
            Console.Clear();
            Program.OutputStatus();
            
            // Wybór osoby do sprzedania alkoholu
            Console.WriteLine("[GRA] - Przed twoim sklepem pojawila sie gromada ludzi. Komu decydujesz sie sprzedac alkohol? (1-" + person.Count + ")");
            OutputPersons();
            userAnswer = Console.ReadLine();
            Program.PlayClickSound();

            if (userAnswer == (person.Count + 1).ToString())
            {
                break;
            }
            selectedPerson = Convert.ToInt32(userAnswer) - 1;
                
            // Wybór alkoholu do sprzedania
            Console.WriteLine("[GRA] - Jaki bimber chcesz opchnac? (1-" + playerAlcohols.Count + ")");
            OutputPlayerAlcohols();
            userAnswer = Console.ReadLine();
            Program.PlayClickSound();
            selectedAlcoholToPerson = playerAlcohols[Convert.ToInt32(userAnswer) - 1];

            // Losowanie czy osoba zabije gracza
            bool isPlayerKilled = new Random().Next(100) < person[selectedPerson].killChance * 100 ;
            if (isPlayerKilled)
            {
                KillPlayer();
            }
                
            // Losowanie czy osoba będzie się targować
            bool isPriceDropped = new Random().Next(100) < person[selectedPerson].dropPriceChance * 100 ;
            if (isPriceDropped)
            {
                DropPrice();
            }
            else
            {
                SellAlcoholAtFullPrice();
            }
                
            // Usuwanie alkoholu z listy alkoholi gracza
            playerAlcohols.Remove(selectedAlcoholToPerson);
            if (playerAlcohols.Count == 0)
            {
                break;
            }
        }
    }

    // Wyświetla dostępne osoby którym możesz sprzedać alkohol
    public static void OutputPersons()
    {
        foreach (Person b in person)
        {
            Console.WriteLine("█ " + b.Name);
        }
        Console.WriteLine("█ Juz wystarczy sprzedawania");
    }

    // Wyświetla dostępne alkohole po wyvbraniu osoby
    public static void OutputPlayerAlcohols()
    {
        foreach (Alcohol c in playerAlcohols)
        {
            Console.WriteLine("█ " + c.Name + ", cena: " + c.Cena);
        }
    }

    // Osoba zabija gracza
    public static void KillPlayer()
    {
        Console.WriteLine("Dajesz do sprobowania bimber temu komus. Na to on ci mowi:");
        Thread.Sleep(2500);
        Console.WriteLine("Ale slabe zabije cie");
        Thread.Sleep(2500);
        Console.WriteLine("Giniesz");
        Thread.Sleep(2500);
        Environment.Exit(0);
    }

    // Osoba targuje się
    public static void DropPrice()
    {
        int priceDrop = new Random().Next(10);
        int newPrice = selectedAlcoholToPerson.Cena - priceDrop;
        Console.WriteLine("No chlopie, za to co najwyzej " + newPrice + "zl moge zaproponowac");
        Console.WriteLine("[GRA] - Przystajesz na oferte? (1 - Tak, 2 - Nie)");

        userAnswer = Console.ReadLine();
        Program.PlayClickSound();
        if (userAnswer == "1")
        {
            Console.WriteLine("[GRA] - Zgadzasz sie na sprzedanie i dostajesz " + newPrice + "zl");
            cash += newPrice;
            reputation += 10;
        }
        else
        {
            Console.WriteLine("[GRA] - Mowisz typowi aby poszedl sie walic, nie sprzedajesz alkoholu");
        }
    }

    // Osoba nic nie robi - sprzedajesz bez problemów
    public static void SellAlcoholAtFullPrice()
    {
        Console.WriteLine("[GRA] - Klient jest zachwycony twoim bimbrem, dostajesz " + selectedAlcoholToPerson.Cena + "zl");
        cash += selectedAlcoholToPerson.Cena;
        reputation += 20;
    }
}