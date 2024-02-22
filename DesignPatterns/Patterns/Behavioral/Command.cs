namespace DesignPatterns.Patterns.Behavioral;

public interface ICommand
{
    void Execute();
}

public class Command(Receiver receiver) : ICommand
{
    public void Execute()
    {
        receiver.DoSomething();
    }
}

public class Receiver
{
    public void DoSomething()
    {
        Console.WriteLine("Receiver doing something ...");
    }
}

public class Invoker(ICommand command)
{
    public void OnStart()
    {
        command.Execute();
    }
}

public static class UsageCommand
{
    public static void Usage()
    {
        Receiver receiver = new();
        Command command = new(receiver);

        Invoker invoker = new(command);
        invoker.OnStart();
    }
}