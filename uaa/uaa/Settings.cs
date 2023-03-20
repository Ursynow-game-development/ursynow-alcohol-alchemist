namespace uaa;

public class Settings
{
    public static string userAnswer = Program.userAnswer;
    
    // Wyświetla ustawienia
    public static void OutputSettings()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("▓▓▓ USTAWIENIA - Wybierz opcje (1-2) ▓▓▓");
        Console.WriteLine("█ Dzwiek");
        Console.WriteLine("█ Powrot");
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");

        userAnswer = Console.ReadLine();
        Program.PlayClickSound();
        switch (userAnswer)
        {
            case "1": 
                ChangeAudioSettings();
                break;
            case "2": 
                Console.Clear();
                Program.OutputMenu();
                break;
        }
    }

    // Ustawienia - dźwięk
    public static void ChangeAudioSettings()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("▓▓▓ Ustawienia dzwieku ▓▓▓");
        Console.WriteLine("█ Wlacz");
        Console.WriteLine("█ Wylacz");
        Console.WriteLine("▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓");
        
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
        Thread.Sleep(1500);
        OutputSettings();
    }
}