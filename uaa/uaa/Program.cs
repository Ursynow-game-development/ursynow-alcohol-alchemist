using System.Runtime.InteropServices.JavaScript;

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

       public static IList<Alcochols> alcochols = new Alcochols[]
        {
            new Alcochols("mieczak",8f, 2f, 2f, 15),
            new Alcochols("kopniak",2f, 6f, 4f, 16),
            new Alcochols("jasne",6f, 3f, 3f, 15),
            new Alcochols("ciemne",7f, 6f, 7f, 18),
            new Alcochols("kielich",5f, 5f, 8f, 22),
            new Alcochols("mocarz",2f, 2f, 11f, 28)
        };

       public static IList<Alcochols> playerAlcohols = new Alcochols[] {};
        
        static void Main(string[] args)
        {
             OutputMenu();
             OutputTutorial();
             Thread.Sleep(6000);

             MakingAlcohol();

             Console.Read();
        }

        public static void OutputMenu()
        {
            Console.WriteLine("####################################");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("URSYNoW ALCOHOL ALCHEMIST SIMULATOR");
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
            Console.WriteLine("===================================");
            Console.WriteLine("Pedzenie bimbru - pole wyboru (1-7)");

            while (true)
            {
                OutputStatus();
                foreach (Alcochols a in alcochols)
                {
                    Console.WriteLine("* " + a.Name + " (cukier - " + a.RequiredCukier + "; zboze - " + a.RequiredZboze + "; ziemniaki - " + a.RequiredZiemniaki + ")");
                }
                Console.WriteLine("* Juz starczy na dzis");

                userAnswer = Console.ReadLine();
                if (userAnswer == "7")
                {
                    break;
                }

                selectedAlcohol = Convert.ToInt32(userAnswer);
                Console.WriteLine(selectedAlcohol);
                if (alcochols[selectedAlcohol].RequiredCukier >= cukier &&
                    alcochols[selectedAlcohol].RequiredZboze >= zboze &&
                    alcochols[selectedAlcohol].RequiredZiemniaki >= ziemniaki)
                {
                    playerAlcohols.Add(alcochols[selectedAlcohol]);
                    cukier -= alcochols[selectedAlcohol].RequiredCukier;
                    zboze -= alcochols[selectedAlcohol].RequiredZboze;
                    ziemniaki -= alcochols[selectedAlcohol].RequiredZiemniaki;
                }
                else
                {
                    Console.WriteLine("Nie masz wystarczajaco skladnikow");
                }
                Console.Clear();
            }
        }
    }
}