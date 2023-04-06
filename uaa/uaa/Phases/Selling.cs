namespace uaa.Phases;

public class Selling
{
    public static string userAnswer = Program.userAnswer;
    public static Alcohol selectedAlcoholToPerson;

    public static void SellingAlcohol()
    {
        while (Program.playerAlcohols.Count > 0)
        {
            Console.Clear();
            Program.OutputStatus();

            OutputPersons();
            userAnswer = Console.ReadLine();
            Program.PlayClickSound();

            if (userAnswer == (Program.persons.Count + 1).ToString())
                break;
            
            int selectedPerson = Convert.ToInt32(userAnswer) - 1;

            OutputPlayerAlcohols();
            userAnswer = Console.ReadLine();
            Program.PlayClickSound();
            selectedAlcoholToPerson = Program.playerAlcohols[Convert.ToInt32(userAnswer) - 1];
            
            bool isPlayerKilled = new Random().Next(100) < Program.persons[selectedPerson].killChance * 100 ;
            if (isPlayerKilled)
                KillPlayer();
            
            bool isPriceDropped = new Random().Next(100) < Program.persons[selectedPerson].dropPriceChance * 100 ;
            if (isPriceDropped)
                DropPrice();
            else
                SellAlcoholAtFullPrice();
            
            Program.playerAlcohols.Remove(selectedAlcoholToPerson);
        }
    }
    
    public static void OutputPersons()
    {
        Console.WriteLine("[GRA] - Przed twoim sklepem pojawila sie gromada ludzi. Komu decydujesz sie sprzedac alkohol? (1-" + Program.persons.Count + ")");
        
        foreach (Person b in Program.persons)
            Console.WriteLine("█ " + b.Name);
        
        Console.WriteLine("█ Juz wystarczy sprzedawania");
    }

    public static void OutputPlayerAlcohols()
    {
        Console.WriteLine("[GRA] - Jaki bimber chcesz opchnac? (1-" + Program.playerAlcohols.Count + ")");
        
        foreach (Alcohol c in Program.playerAlcohols)
            Console.WriteLine("█ " + c.Name + ", cena: " + c.Cena);
    }

    public static void KillPlayer()
    {
        Console.WriteLine("Dajesz do sprobowania bimber temu komus. Na to on ci mowi:");
        Thread.Sleep(2500);
        Console.WriteLine("'Ale slabe zabije cie'");
        Thread.Sleep(2000);
        Console.WriteLine("Giniesz");
        Thread.Sleep(2000);
        Environment.Exit(0);
    }

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
            Program.cash += newPrice;
            Program.reputation += 10;
        }
        else
            Console.WriteLine("[GRA] - Mowisz typowi aby poszedl sie walic, nie sprzedajesz alkoholu");
    }

    public static void SellAlcoholAtFullPrice()
    {
        Console.WriteLine("[GRA] - Klient jest zachwycony twoim bimbrem, dostajesz " + selectedAlcoholToPerson.Cena + "zl");
        Program.cash += selectedAlcoholToPerson.Cena;
        Program.reputation += 20;
    }
}