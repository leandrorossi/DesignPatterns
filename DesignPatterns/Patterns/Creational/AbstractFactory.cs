namespace DesignPatterns.Patterns.Creational;

public interface ICake
{
    public void Print();
}

public class ChocolateCake : ICake
{
    public void Print() => Console.WriteLine("Chocolate cake created");
}

public class OrangeCake : ICake
{
    public void Print() => Console.WriteLine("Orange cake created");
}

public interface IPie
{
    public void Print();
}

public class ChocolatePie : IPie
{
    public void Print() => Console.WriteLine("Chocolate pie created");
}

public class OrangePie : IPie
{
    public void Print() => Console.WriteLine("Orange pie created");
}

public interface IAbstractFactory
{
    public ICake CreateCake();
    public IPie CreatePie();
}

public sealed class ChocolateFactory : IAbstractFactory
{
    public ICake CreateCake()
    {
        return new ChocolateCake();
    }

    public IPie CreatePie()
    {
        return new ChocolatePie();
    }
}

public sealed class OrangeFactory : IAbstractFactory
{
    public ICake CreateCake()
    {
        return new OrangeCake();
    }

    public IPie CreatePie()
    {
        return new OrangePie();
    }
}

public static class UsageAbstractFactory
{
    public static void Usage()
    {
        var chocolateFactory = new ChocolateFactory();
        var chocolateCake = chocolateFactory.CreateCake();
        var chocolatePie = chocolateFactory.CreatePie();

        chocolateCake.Print();
        chocolatePie.Print();
        
        var orangeFactory = new OrangeFactory();
        var orangeCake = orangeFactory.CreateCake();
        var orangePie = orangeFactory.CreatePie();
        
        orangeCake.Print();
        orangePie.Print();
    }
}
