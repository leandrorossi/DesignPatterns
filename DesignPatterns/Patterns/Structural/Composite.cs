namespace DesignPatterns.Patterns.Structural;

public abstract class Component
{
    public virtual void Add(Component component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(Component component)
    {
        throw new NotImplementedException();
    }

    public abstract void Operation();
}

public class Leaf : Component
{
    public override void Operation()
    {
        Console.WriteLine("Leaf");
    }
}

public class Composite : Component
{
    private readonly List<Component> _children = new();

    public override void Add(Component component)
    {
        _children.Add(component);
    }

    public override void Remove(Component component)
    {
        _children.Remove(component);
    }

    public override void Operation()
    {
        foreach (var item in _children)
        {
            Console.WriteLine($"Operation on {item} was processed");
        }
    }
}

public static class UsageComposite
{
    public static void Usage()
    {
        Composite tree = new();

        Composite branch1 = new();
        branch1.Add(new Leaf());
        branch1.Add(new Leaf());

        Composite branch2 = new();
        branch2.Add(new Leaf());
        branch2.Add(new Leaf());

        tree.Add(branch1);
        tree.Add(branch2);
        tree.Operation();
    }
}