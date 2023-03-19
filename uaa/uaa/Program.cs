using uaa.Phases;

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
        public static List<Alcohol> playerAlcohols = new List<Alcohol>();
        public static IList<Alcohol> alcohols = new[] {
            new Alcohol("mieczak",8f, 2f, 2f, 20),
            new Alcohol("kopniak",2f, 5f, 4f, 25),
            new Alcohol("jasne",6f, 3f, 3f, 25),
            new Alcohol("ciemne",7f, 6f, 7f, 50),
            new Alcohol("kielich",5f, 5f, 8f, 45),
            new Alcohol("mocarz",2f, 2f, 11f, 46)
        };
        public static IList<Person> person = new [] {
           new Person("seba",0.1f,0.23f),
           new Person("prof. gucio",0,0.45f),
           new Person("iwanbillion",0.34f,0),
           new Person("janusz",0.18f,0.2f),
           new Person("mieczyslaw",0.03f,0.16f)
        };

        static void Main(string[] args)
        {
             OutputMenu();
             OutputTutorial();
             Thread.Sleep(5000);

             while (true)
             {
                 Making.MakingAlcohol();
                 Selling.SellingAlcohol();
                 Events.RandomEvent();
                 Buying.BuyingIngredients();
                 day++;
             }
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
            Console.WriteLine("Witaj w symulatorze pedzenia bimbru! Kazdy dzien w grze dzieli sie na: pedzenie, sprzedaz, kupno skladnikow.");
            Console.WriteLine("Kazdy typ bimbru wymaga roznej liczby skladnikow. Podczas twojej rutyny beda sie dziac nieprzemyslane rzeczy");
            Console.WriteLine("To juz wszystko. Zaczynamy");
        }
    }
}