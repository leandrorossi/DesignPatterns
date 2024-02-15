namespace DesignPatterns.Patterns.Structural;

public interface INewPaymentProcessor
{
    public void Pay(double amount);
}

public class OldPaymentProcessor
{
    public void MakePayment(int price)
    {
        Console.WriteLine($"Payment made {price}");
    }
}

public class Adapter : INewPaymentProcessor
{
    private readonly OldPaymentProcessor _oldPaymentProcessor;

    public Adapter(OldPaymentProcessor oldPaymentProcessor)
    {
        _oldPaymentProcessor = oldPaymentProcessor;
    }

    public void Pay(double amount)
    {
        _oldPaymentProcessor.MakePayment((int)amount);
    }
}

public static class UsageAdapter
{
    public static void Usage()
    {
        INewPaymentProcessor newPaymentProcessor = new Adapter(new OldPaymentProcessor());
        newPaymentProcessor.Pay(49.99);
    }
}