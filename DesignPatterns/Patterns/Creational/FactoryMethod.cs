namespace DesignPatterns.Patterns.Creational;

public abstract class House
{
    protected string? Name { get; init; }

    public void Print() => Console.WriteLine($"{Name} created");
}

public class WoodCheapHouse : House
{
    public WoodCheapHouse() => Name = "Wood Cheap House";
}

public class WoodExpensiveHouse : House
{
    public WoodExpensiveHouse() => Name = "Wood Expensive House";
}

public class StoneCheapHouse : House
{
    public StoneCheapHouse() => Name = "Stone Cheap House";
}

public class StoneExpensiveHouse : House
{
    public StoneExpensiveHouse() => Name = "Stone Expensive House";
}

public abstract class FactoryMethod
{
    public House OrderHouse(string cost)
    {
        var house = CreateHouse(cost); 
        return house;
    }
    
    protected abstract House CreateHouse(string cost);
}

public class StoneHouseFactory : FactoryMethod
{
    protected override House CreateHouse(string cost)
    {
        House house = cost switch
        {
            "Cheap" => new StoneCheapHouse(),
            "Expensive" => new StoneExpensiveHouse(),
            _ => throw new ApplicationException($"Stone {cost} House invalid")
        };
        return house;
    }
}

public sealed class WoodHouseFactory : FactoryMethod
{
    protected override House CreateHouse(string cost)
    {
        House house = cost switch
        {
            "Cheap" => new WoodCheapHouse(),
            "Expensive" => new WoodExpensiveHouse(),
            _ => throw new ApplicationException($"Wood {cost} House invalid")
        };
        return house;
    }
}

public sealed class SimpleFactory
{
    public static FactoryMethod Create(string type)
    {
        FactoryMethod factoryMethod = type switch
        {
            "Stone" => new StoneHouseFactory(),
            "Wood" => new WoodHouseFactory(),
            _ => throw new ApplicationException($"House {type} invalid")
        };
        return factoryMethod;
    }
}

public class UsageFactoryMethod
{
    public static void Usage()
    {
        var stoneFactoryMethod = SimpleFactory.Create("Stone");
        var stoneCheapHouse = stoneFactoryMethod.OrderHouse("Cheap");
        var stoneExpensiveHouse = stoneFactoryMethod.OrderHouse("Expensive");

        stoneCheapHouse.Print();
        stoneExpensiveHouse.Print();
        
        var woodFactoryMethod = SimpleFactory.Create("Wood");
        var woodCheapHouse = woodFactoryMethod.OrderHouse("Cheap");
        var woodExpensiveHouse = woodFactoryMethod.OrderHouse("Expensive");

        woodCheapHouse.Print();
        woodExpensiveHouse.Print();
    }
}