using System.Security.Principal;

namespace uaa
{
    class Program
    {
        public static string userAnswer;
        public static int cash = 100;
        public static int reputation;
        public static int day = 1;

        public static float cukier = 20f;
        public static float zboze = 20f;
        public static float ziemniaki = 20f;

       public static IList<Alcohol> alcohols = new[]
        {
            new Alcohol("mieczak",8f, 2f, 2f, 15),
            new Alcohol("kopniak",2f, 6f, 4f, 16),
            new Alcohol("jasne",6f, 3f, 3f, 15),
            new Alcohol("ciemne",7f, 6f, 7f, 18),
            new Alcohol("kielich",5f, 5f, 8f, 22),
            new Alcohol("mocarz",2f, 2f, 11f, 28)
        };
       
       public static IList<Person> person = new []
       {
           new Person("seba",0.1f,0.23f),
           new Person("prof. gucio",0,0.45f),
           new Person("iwanbillion",0.34f,0),
           new Person("janusz",0.18f,0.2f),
           new Person("mieczyslaw",0.03f,0.16f)
       };

       public static List<Alcohol> playerAlcohols = new List<Alcohol>();
        
        static void Main(string[] args)
        {
             OutputMenu();
             OutputTutorial();
             Thread.Sleep(6000);

             MakingAlcohol();
             SellingAlcohol();

             Console.Read();
        }

        public static void OutputMenu()
        {
            Console.WriteLine("####################################");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("URSYNOW ALCOHOL ALCHEMIST SIMULATOR");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("          Made by Nefr0l           ");
            Console.WriteLine("####################################");
            Console.WriteLine(" Nacisnij any key aby rozpoczac gre ");
            Console.ReadKey();
        }

        public static void OutputStatus()
        {
            Console.WriteLine("");
            Console.WriteLine("====================================================================================");
            Console.WriteLine("Dzien " + day + ", Masz " + cash + " kasy oraz " + reputation + " punktow reputacji");
            Console.WriteLine("Stan surowcow: Cukier - " + cukier + ", Zboze - " + zboze + ", Ziemniaki - " + ziemniaki);
            Console.WriteLine("-------------------------------#===================================================");
        }

        public static void OutputTutorial()
        {
            Console.WriteLine("");
            Console.WriteLine("PORADNIK:");
            Console.WriteLine("Witaj w symulatorze pedzenia bimbru na ursynowie. Twoim zadanie jest o dziwo pedzenie bimbru");
            Console.WriteLine("Gra jest podzielona na dni a kazdy z nich na fazy: pedzenie bimbru, sprzedaz, kupno skladnikow.");
            Console.WriteLine("Bimber potrzebuje skladnikow, kazdy typ bimbru wymaga roznej liczby skladnikow. Podczas twojej rutyny moga dziac sie nieprzemyslane rzeczy");
            Console.WriteLine("To juz wszystko co potrzebujesz wiedziec. Zaczynamy");
        }

        public static void MakingAlcohol()
        {
            int selectedAlcohol;
            Console.Clear();

            while (true)
            {
                int alcoholsLength = alcohols.Count;
                OutputStatus();
                Console.WriteLine("[GRA] - Pedzenie bimbru - pole wyboru (1-"+(alcoholsLength+1)+"):");
                foreach (Alcohol a in alcohols)
                {
                    Console.WriteLine("* " + a.Name + " (cukier - " + a.RequiredCukier + "; zboze - " + a.RequiredZboze + "; ziemniaki - " + a.RequiredZiemniaki + ")");
                }
                Console.WriteLine("* Juz starczy pedzenia na dzis");

                userAnswer = Console.ReadLine();
                if (userAnswer == (alcoholsLength+1).ToString()) { break; }

                selectedAlcohol = Convert.ToInt32(userAnswer) - 1;
                if (alcohols[selectedAlcohol].RequiredCukier <= cukier &&
                    alcohols[selectedAlcohol].RequiredZboze <= zboze &&
                    alcohols[selectedAlcohol].RequiredZiemniaki <= ziemniaki)
                {
                    Console.Clear();
                    playerAlcohols.Add(alcohols[selectedAlcohol]);
                    
                    cukier -= alcohols[selectedAlcohol].RequiredCukier;
                    zboze -= alcohols[selectedAlcohol].RequiredZboze;
                    ziemniaki -= alcohols[selectedAlcohol].RequiredZiemniaki;
                    Console.WriteLine("[GRA] - Udalo ci sie wytworzyc wybrany alkohol. Robimy cos jeszcze?");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("[GRA] - Nie masz wystarczajaco skladnikow. Chcesz przyrzadzic jakis inny alkohol?");
                }
            }
        }

        public static void SellingAlcohol()
        {
            int selectedPerson;
            int selectedAlcoholToPerson;
            
            while (true)
            {
                Console.Clear();
                OutputStatus();
                Console.WriteLine("[GRA] - Przed twoim sklepem pojawila sie gromada ludzi. Komu decydujesz sie sprzedac alkohol? (1-" + person.Count + ")");
                foreach (Person b in person)
                {
                    Console.WriteLine("* " + b.Name);
                }
                Console.WriteLine("* Juz wystarczy sprzedawania");

                userAnswer = Console.ReadLine();
                if (userAnswer == (person.Count + 1).ToString()) { break; }
                selectedPerson = Convert.ToInt32(userAnswer) - 1;
                
                Console.WriteLine("[GRA] - Jaki bimber chcesz opchnac? (1-" + playerAlcohols.Count + ")");
                foreach (Alcohol c in playerAlcohols)
                {
                    Console.WriteLine("* " + c.Name + ", cena: " + c.Cena);
                }

                userAnswer = Console.ReadLine();
                selectedAlcoholToPerson = Convert.ToInt32(userAnswer) - 1;
                playerAlcohols.Remove(playerAlcohols[selectedAlcoholToPerson]);
                if (playerAlcohols.Count == 0) { Console.WriteLine("Koniec alkoholi!"); break;}

                bool isPlayerKilled = new Random().Next(100) < person[selectedPerson].killChance * 100 ;
                if (isPlayerKilled)
                {
                    Console.WriteLine("Dajesz do sprobowania bimber temu komus. Na to on ci mowi:");
                    Thread.Sleep(2500);
                    Console.WriteLine("Ale slabe zabije cie");
                    Thread.Sleep(2500);
                    Console.WriteLine("Giniesz");
                    Thread.Sleep(2500);
                    Environment.Exit(0);
                }
                
                bool isPriceDropped = new Random().Next(100) < person[selectedPerson].dropPriceChance * 100 ;
                if (isPriceDropped)
                {
                    // DO DOKOŃCZENIA
                }
            }
        }
    }
}