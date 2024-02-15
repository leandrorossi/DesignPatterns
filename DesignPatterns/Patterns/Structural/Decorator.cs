namespace DesignPatterns.Patterns.Structural;

public interface ICoffee
{
    public double Price();
}

public class Coffee : ICoffee
{
    public double Price()
    {
        return 2.0;
    }
}

public class MilkDecorator : ICoffee
{
    private readonly ICoffee _coffee;

    public MilkDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public double Price()
    {
        return _coffee.Price() + 1.0;
    }
}

public class CreamDecorator : ICoffee
{
    private readonly ICoffee _coffee;

    public CreamDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }

    public double Price()
    {
        return _coffee.Price() + 3.0;
    }
}

public static class UsageDecorator
{
    public static void Usage()
    {
        var coffee = new Coffee();
        Console.WriteLine($"Coffee price = {coffee.Price()}");

        var coffeeWithMilk = new MilkDecorator(coffee);
        Console.WriteLine($"Coffee with milk price = {coffeeWithMilk.Price()}");

        var coffeeWithCream = new CreamDecorator(coffee);
        Console.WriteLine($"Coffee with cream price = {coffeeWithCream.Price()}");
    }
}