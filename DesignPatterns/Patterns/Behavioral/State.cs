namespace DesignPatterns.Patterns.Behavioral;

public interface IState
{
    void Deposit();
    void Withdraw();
}

public class RedState : IState
{
    public void Deposit()
    {
        Console.WriteLine("Deposit made");
    }

    public void Withdraw()
    {
        Console.WriteLine("No funds available for withdraw");
    }
}

public class GreenState : IState
{
    public void Deposit()
    {
        Console.WriteLine("Deposit made");
    }

    public void Withdraw()
    {
        Console.WriteLine("Withdraw made");
    }
}

public class Account : IState
{
    public IState State = new RedState();

    public void Deposit()
    {
        State.Deposit();

        if (State is RedState)
            State = new GreenState();
    }

    public void Withdraw()
    {
        State.Withdraw();

        if (State is GreenState)
            State = new RedState();
    }
}

public static class UsageState
{
    public static void Usage()
    {
        Account account = new();

        Console.WriteLine($"Current state {account.State.GetType().Name}");
        account.Withdraw();
        account.Deposit();

        Console.WriteLine();
        Console.WriteLine($"Current state {account.State.GetType().Name}");
        account.Withdraw();
    }
}