namespace DesignPatterns.Patterns.Behavioral;

public abstract class Handler
{
    protected Handler _nextHandler;

    public void NextHandler(Handler handler)
    {
        _nextHandler = handler;
    }

    public abstract void Handle(string handler);
}

public class ConcreteHandler1 : Handler
{
    public override void Handle(string handler)
    {
        if (handler == "Handler 1")
        {
            Console.WriteLine("Process by the concrete handler 1");
        }
        else
        {
            _nextHandler.Handle(handler);
        }
    }
}

public class ConcreteHandler2 : Handler
{
    public override void Handle(string handler)
    {
        if (handler == "Handler 2")
        {
            Console.WriteLine("Process by the concrete handler 2");
        }
        else
        {
            _nextHandler.Handle(handler);
        }
    }
}

public class ConcreteHandler3 : Handler
{
    public override void Handle(string handler)
    {
        if (handler == "Handler 3")
        {
            Console.WriteLine("Process by the concrete handler 3");
        }
        else
        {
            Console.WriteLine("There is no concrete handler to process");
        }
    }
}

public static class UsageChainOfResponsibility
{
    public static void Usage()
    {
        ConcreteHandler1 concreteHandler1 = new();
        ConcreteHandler2 concreteHandler2 = new();
        ConcreteHandler3 concreteHandler3 = new();

        concreteHandler1.NextHandler(concreteHandler2);
        concreteHandler2.NextHandler(concreteHandler3);

        concreteHandler1.Handle("Handler 1");
        concreteHandler1.Handle("Handler 2");
        concreteHandler1.Handle("Handler 3");
        concreteHandler1.Handle("Handler 4");
    }
}