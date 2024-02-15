namespace DesignPatterns.Patterns.Creational;

public sealed class Singleton
{
    private static Singleton? _instance;
    private static readonly object LockObject = new();
    
    private Singleton()
    {
    }

    public static Singleton Instance
    {
        get
        {
            lock (LockObject)
            {
                return _instance ??= new Singleton();
            }
        }
    }
}

public static class UsageSingleton
{
    public static void Usage()
    {
        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;

        if (instance1 == instance2)
            Console.WriteLine("Variables have the same instance");
        else
            Console.WriteLine("Variables have different instances");
    }
}