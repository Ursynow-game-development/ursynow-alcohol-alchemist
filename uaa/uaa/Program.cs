﻿using uaa.Phases;

namespace uaa
{
    class Program
    {
        public static string userAnswer;
        public static int cash = 25;
        public static int reputation;
        public static int day = 1;
        public static float cukier = 10f;
        public static float zboze = 10f;
        public static float ziemniaki = 10f;
        public static List<Alcohol> playerAlcohols = new();
        public static bool soundOn = true;
        public static int playerAlcoholsNumber;
        
        public static IList<Alcohol> alcohols = new[] {
            new Alcohol("mieczak",8f, 2f, 2f, 21),
            new Alcohol("kopniak",2f, 5f, 4f, 27),
            new Alcohol("jasne",6f, 3f, 3f, 25),
            new Alcohol("ciemne",7f, 6f, 7f, 50),
            new Alcohol("kielich",5f, 5f, 8f, 48),
            new Alcohol("mocarz",2f, 2f, 11f, 38)
        };
        
        public static IList<Person> persons = new [] {
           new Person("seba",0.1f,0.23f),
           new Person("prof. gucio",0,0.45f),
           new Person("iwanbillion",0.34f,0),
           new Person("janusz",0.18f,0.2f),
           new Person("mieczyslaw",0.03f,0.16f)
        };

        static void Main()
        {
            ReadData();
            OutputLogo();
            OutputMenu();

            while (true)
            {
                Making.MakingAlcohol();
                Selling.SellingAlcohol();
                Events.RandomEvent();
                Buying.BuyingIngredients();
                WriteData();
                day++;
            }
        }

        public static void OutputLogo()
        {
            Console.WriteLine("██    ██ ██████  ███████ ██    ██ ███    ██  ██████  ██     ██     ███████ ████████ ██    ██ ██████  ██  ██████  ███████ ");
            Console.Beep(500,100);
            Console.WriteLine("██    ██ ██   ██ ██       ██  ██  ████   ██ ██    ██ ██     ██     ██         ██    ██    ██ ██   ██ ██ ██    ██ ██      ");
            Console.Beep(400,100);
            Console.WriteLine("██    ██ ██████  ███████   ████   ██ ██  ██ ██    ██ ██  █  ██     ███████    ██    ██    ██ ██   ██ ██ ██    ██ ███████ ");
            Console.Beep(300,150);
            Console.WriteLine("██    ██ ██   ██      ██    ██    ██  ██ ██ ██    ██ ██ ███ ██          ██    ██    ██    ██ ██   ██ ██ ██    ██      ██ ");
            Console.Beep(400,250);
            Console.WriteLine(" ██████  ██   ██ ███████    ██    ██   ████  ██████   ███ ███      ███████    ██     ██████  ██████  ██  ██████  ███████ ");
            Console.Beep(500,500);
            Thread.Sleep(1000);
            Console.Clear();
        }

        public static void OutputMenu()
        {
            Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("░░░░░░░░▓     URSYNOW ALCOHOL ALCHEMIST     ▓░░░░░░░░");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine("");
            Console.WriteLine("Stworzone przez Nefr0l, wersja 1.0");
            Console.WriteLine("Wybierz opcje (1-3)");
            Console.WriteLine("█ Graj");
            Console.WriteLine("█ Poradnik");
            Console.WriteLine("█ Ustawienia");

            userAnswer = Console.ReadLine();
            PlayClickSound();
            
            switch (userAnswer)
            {
                case "2": 
                    OutputTutorial(); 
                    break;
                case "3": 
                    Settings.OutputSettings();
                    break;
            }
        }

        public static void OutputStatus()
        {
            Console.WriteLine("");
            Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
            Console.WriteLine("Dzien " + day + ", masz " + cash + "zl oraz " + reputation + " punktow reputacji");
            Console.WriteLine("Stan surowcow: Cukier = " + cukier + ", Zboze = " + zboze + ", Ziemniaki = " + ziemniaki);
            Console.WriteLine("░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
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
            PlayClickSound();
            Console.Clear();
            OutputMenu();
        }

        public static void PlayClickSound()
        {
            if (soundOn)
                Console.Beep(550, 125);
        }

        public static void WriteData()
        {
            Console.Clear();
            Console.WriteLine("[GRA] - Trwa zapisywanie danych");
            string filename = "data.txt";
            
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(cash);
                writer.WriteLine(soundOn);
                writer.WriteLine(reputation);
                writer.WriteLine(ziemniaki);
                writer.WriteLine(zboze);
                writer.WriteLine(cukier);
                writer.WriteLine(playerAlcohols.Count);
                for (int i = 0; i < playerAlcohols.Count; i++)
                {
                    writer.WriteLine(playerAlcohols[i].Name);
                    writer.WriteLine(playerAlcohols[i].RequiredZiemniaki);
                    writer.WriteLine(playerAlcohols[i].RequiredZboze);
                    writer.WriteLine(playerAlcohols[i].RequiredCukier);
                    writer.WriteLine(playerAlcohols[i].Cena);
                }
            }
            Thread.Sleep(500);
            Console.WriteLine("[GRA] - Gotowe");
            Thread.Sleep(800);
        }

        public static void ReadData()
        {
            long length = new FileInfo("data.txt").Length;
            using (StreamReader reader = new StreamReader("data.txt"))
            {
                for (int i = 0; i < length; i++)
                {
                    string line = reader.ReadLine();
                    if (i == 0 && line != null) { cash = int.Parse(line); }
                    if (i == 1 && line != null) { soundOn = Boolean.Parse(line); }
                    if (i == 2 && line != null) { reputation = int.Parse(line); }
                    if (i == 3 && line != null) { ziemniaki = int.Parse(line); }
                    if (i == 4 && line != null) { zboze = int.Parse(line); }
                    if (i == 5 && line != null) { cukier = int.Parse(line); }
                    if (i == 6 && line != null)
                    {
                        playerAlcoholsNumber = int.Parse(line);
                        for (int j = 0; j < playerAlcoholsNumber; j++)
                        {
                            string aName = reader.ReadLine();
                            float aZiemniaki = int.Parse(reader.ReadLine());
                            float aZboze = int.Parse(reader.ReadLine());
                            float aCukier = int.Parse(reader.ReadLine());
                            int aCash = int.Parse(reader.ReadLine());
                            playerAlcohols.Add(new Alcohol(
                                aName, aZiemniaki, aZboze, aCukier, aCash
                            ));
                        }
                    }
                }
            }
        }
    }
}