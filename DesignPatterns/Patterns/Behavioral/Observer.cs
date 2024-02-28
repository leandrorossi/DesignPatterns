namespace DesignPatterns.Patterns.Behavioral;

public interface IObserver
{
    void Update(string name);
}

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class Subject(string name, string availability) : ISubject
{
    public string Name = name;
    
    public string Availability
    {
        get => availability;
        set
        {
            availability = value;
            Notify();
        }
    }

    private List<IObserver> _observers = new();

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(Name);
        }
    }
}

public class Observer(string name) : IObserver
{
    public string Name = name;

    public void Update(string name)
    {
        Console.WriteLine($"Notified {Name}, {name} availability changed");
    }
}

public static class UsageObserver
{
    public static void Usage()
    {
        Subject product = new Subject("Samsung 23", "No stock");
        product.Attach(new Observer("John"));
        product.Attach(new Observer("Ana"));
        product.Attach(new Observer("Paul"));

        product.Availability = "Available";
        Console.WriteLine(product.Availability);
    }
}