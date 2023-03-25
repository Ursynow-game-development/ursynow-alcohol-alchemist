namespace uaa;

public class Settings
{
    public static string userAnswer = Program.userAnswer;
    
    // Wyświetla ustawienia
    public static void OutputSettings()
    {
        Console.Clear();
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ Menu ustawien (1-3) ▓▓▓");
        Console.WriteLine("█ Dzwiek");
        Console.WriteLine("█ Dane");
        Console.WriteLine("█ Powrot");
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");

        userAnswer = Console.ReadLine();
        Program.PlayClickSound();
        switch (userAnswer)
        {
            case "1": 
                ChangeAudioSettings();
                break;
            case "2":
                DataSettings();
                break;
            case "3": 
                Console.Clear();
                Program.OutputMenu();
                break;
        }
    }

    // Ustawienia - dźwięk
    public static void ChangeAudioSettings()
    {
        Console.Clear();
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ Ustawienia dzwieku (1-2)  ▓▓▓");
        Console.WriteLine("█ Wlacz");
        Console.WriteLine("█ Wylacz");
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        
        userAnswer = Console.ReadLine();
        Program.PlayClickSound();
        switch (userAnswer)
        {
            case "1":
                Program.soundOn = true;
                break;
            case "2": 
                Program.soundOn = false;
                break;
        }
        
        Console.WriteLine("Ustawienie dzwieku zmienione na " + Program.soundOn);
        Thread.Sleep(1600);
        OutputSettings();
    }
    
    // Ustawienia - dane
    public static void DataSettings()
    {
        Console.Clear();
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ Ustawienia danych (1-2) ▓▓▓");
        Console.WriteLine("█ Wyczysc");
        Console.WriteLine("█ Powrot");
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        
        userAnswer = Console.ReadLine();
        Program.PlayClickSound();
        switch (userAnswer)
        {
            case "1":
                Console.WriteLine("CZY NA PEWNO CHCESZ WYCZYSCIC DANE? (1=TAK, 2=NIE)");
                userAnswer = Console.ReadLine();
                Program.PlayClickSound();
                
                switch (userAnswer)
                {
                    case "1":
                        using (var writer = new StreamWriter("data.txt", false))
                        {
                            writer.Write("");
                            Console.WriteLine("[GRA] - Gra zrestartuje sie za moment");
                            Thread.Sleep(1000);
                            Environment.Exit(0);
                        }
                        break;
                }
                break;
        }
    }
}