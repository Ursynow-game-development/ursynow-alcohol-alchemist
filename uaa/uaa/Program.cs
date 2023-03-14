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

       public static Array alcochols = new Alcochols[]
        {
            new Alcochols("mięczak",5f, 2f, 2f, 10),
            new Alcochols("kopniak",4f, 4f, 4f, 12),
            new Alcochols("jasne",6f, 3f, 8f, 20),
            new Alcochols("ciemne",7f, 7f, 8f, 25),
            new Alcochols("kielich",12f, 12f, 12f, 40),
            new Alcochols("mocarz",20f, 20f, 20f, 75)
        };

       public static Array playerAlcohols = new Alcochols[] {};
        
        static void Main(string[] args)
        {
             OutputMenu();
             OutputTutorial();
             
             OutputStatus();
             MakingAlcohol();
             
             
             Console.Read();
        }

        public static void OutputMenu()
        {
            Console.WriteLine("####################################");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("URSYNÓW ALCOHOL ALCHEMIST SIMULATOR");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("          Made by Nefr0l           ");
            Console.WriteLine("####################################");
            Console.WriteLine(" Naciśnij any key aby rozpocząć grę ");
            Console.ReadKey();
        }

        public static void OutputStatus()
        {
            Console.WriteLine("");
            Console.WriteLine("====================================================================================");
            Console.WriteLine("Dzień " + day + ", Masz " + cash + " kasy oraz " + reputation + " punktów reputacji");
            Console.WriteLine("Stan surowców: Cukier - " + cukier + ", Zboże - " + zboze + ", Ziemniaki - " + ziemniaki);
            Console.WriteLine("-------------------------------#===================================================");
        }

        public static void OutputTutorial()
        {
            Console.WriteLine("PORADNIK:");
            Console.WriteLine("Witaj w ursynów alcochol alchemist simulator! Twoim zadaniem jest tworzenie bimbru. Zdobywaj reputację oraz kasę i nie daj się złapać!");
            Console.WriteLine("Produkcja bimbru wymaga składników takich jak ziemniaki, zboże i cukier. Każdy dzień zaczynasz rutyną: Robienie bimbru, sprzedaż bimbru, kupno składników. Powodzenia!");
        }

        public static void MakingAlcohol()
        {
            Console.WriteLine("Jaki typ bimbru chciałbyś dziś przyrządzić? (1-6)");
            foreach (Alcochols a in alcochols)
            {
                Console.WriteLine(a.name + " (cukier - " + a.requiredCukier + "; zboze - " + a.requiredZboze + "; ziemniaki - " + a.requiredZiemniaki + ")");
            }
        }
    }
}