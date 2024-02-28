namespace DesignPatterns.Patterns.Behavioral;

public abstract class VideoPlayer
{
    public void Execute()
    {
        Load();
        Decode();
        Play();
    }

    public void Load()
    {
        Console.WriteLine("The video is loading...");
    }

    public abstract void Decode();

    public void Play()
    {
        Console.WriteLine("The video is playing...");
    }
}

public class Mp4Player : VideoPlayer
{
    public override void Decode()
    {
        Console.WriteLine("Using mp4 decoder...");
    }
}

public class MkvPlayer : VideoPlayer
{
    public override void Decode()
    {
        Console.WriteLine("Using mkv decoder...");
    }
}

public static class UsageTemplateMethod
{
    public static void Usage()
    {
        Mp4Player mp4 = new();
        mp4.Execute();

        MkvPlayer mkv = new();
        mkv.Execute();
    }
}