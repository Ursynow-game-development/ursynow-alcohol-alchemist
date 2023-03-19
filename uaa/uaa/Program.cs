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
             OutputLogo();
             OutputMenu();

             while (true)
             {
                 Making.MakingAlcohol();
                 Selling.SellingAlcohol();
                 Events.RandomEvent();
                 Buying.BuyingIngredients();
                 day++;
             }
        }

        public static void OutputLogo()
        {
            Console.WriteLine("██    ██ ██████  ███████ ██    ██ ███    ██  ██████  ██     ██     ███████ ████████ ██    ██ ██████  ██  ██████  ███████ ");
            Thread.Sleep(200);
            Console.WriteLine("██    ██ ██   ██ ██       ██  ██  ████   ██ ██    ██ ██     ██     ██         ██    ██    ██ ██   ██ ██ ██    ██ ██      ");
            Thread.Sleep(200);
            Console.WriteLine("██    ██ ██████  ███████   ████   ██ ██  ██ ██    ██ ██  █  ██     ███████    ██    ██    ██ ██   ██ ██ ██    ██ ███████ ");
            Thread.Sleep(200);
            Console.WriteLine("██    ██ ██   ██      ██    ██    ██  ██ ██ ██    ██ ██ ███ ██          ██    ██    ██    ██ ██   ██ ██ ██    ██      ██ ");
            Thread.Sleep(200);
            Console.WriteLine(" ██████  ██   ██ ███████    ██    ██   ████  ██████   ███ ███      ███████    ██     ██████  ██████  ██  ██████  ███████ ");
            Thread.Sleep(1500);
            Console.Clear();
        }
        
        public static void OutputMenu()
        {
            Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("░░░░░░░▓ URSYNOW ALCOHOL ALCHEMIST SIMULATOR ▓░░░░░░░");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine("");
            Console.WriteLine("Stworzone przez Nefr0l, wersja alpha");
            Console.WriteLine("Wybierz opcje (1-2)");
            Console.WriteLine("█ Graj");
            Console.WriteLine("█ Tutorial");

            userAnswer = Console.ReadLine();
            switch (userAnswer)
            {
                case "2": OutputTutorial(); 
                    break;
            }
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
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("▓▓▓▓▓▓▓▓▓ PORADNIK ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine("Witaj w symulatorze pedzenia bimbru. Gra sklada sie z dni a kazdy z nich z trzech faz:");
            Console.WriteLine("Pedzenie bimbru - Wybierasz alkohole jakie chcesz stworzyc, kazdy z nich potrzebuje innej liczby skladnikow");
            Console.WriteLine("Sprzedaz bimbru - Sprzedajesz roznym osobom alkohole. Kazda z nich ma rozne szanse na zabicie cie lub targowanie sie");
            Console.WriteLine("Kupowanie skaldnikow - Kupujesz skladniki za zarobione pieniadze");
            Console.WriteLine("+ Pomiedzy tymi fazami moga dziac sie rozne randomowe eventy");
            Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            
            Console.WriteLine("");
            Console.WriteLine("Gdy przeczytasz, nacisnij any key aby powrocic do menu");
            Console.ReadKey();
            Console.Clear();
            OutputMenu();
        }
    }
}