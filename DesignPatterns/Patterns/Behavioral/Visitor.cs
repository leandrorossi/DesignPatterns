namespace DesignPatterns.Patterns.Behavioral;

public interface IVisitor
{
    void Visit(Element element);
}

public class Visitor : IVisitor
{
    public void Visit(Element element)
    {
        Console.WriteLine($"{element.GetType().Name} visited by {this.GetType().Name}");
    }
}

public interface IElement
{
    void Accept(IVisitor visitor);
}

public class Element : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public static class UsageVisitor
{
    public static void Usage()
    {
        Element element = new Element();

        Visitor visitor = new();
        element.Accept(visitor);
    }
}