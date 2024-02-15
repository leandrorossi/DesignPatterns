namespace DesignPatterns.Patterns.Creational;

public abstract class AbstractProduct
{
    protected string Name { get; init; } = string.Empty;
    public abstract void Create();
}

public class ConcreteAbstractProductA : AbstractProduct
{
    public ConcreteAbstractProductA()
    {
        Name = "Product A";
    }

    public override void Create() => Console.WriteLine($"Product {Name} created");
}

public class ConcreteAbstractProductB : AbstractProduct
{
    public ConcreteAbstractProductB()
    {
        Name = "Product B";
    }

    public override void Create() => Console.WriteLine($"Product {Name} created");
}

public static class ProductFactory
{
    public static AbstractProduct CreateProduct(string type)
    {
        AbstractProduct product = type switch
        {
            "A" => new ConcreteAbstractProductA(),
            "B" => new ConcreteAbstractProductB(),
            _ => throw new ApplicationException($"Product {type} invalid")
        };

        return product;
    }
}

public static class UsageSimpleFactory
{
    public static void Usage()
    {
        var productA = ProductFactory.CreateProduct("A");
        productA.Create();

        var productB = ProductFactory.CreateProduct("B");
        productB.Create();
    }
} 