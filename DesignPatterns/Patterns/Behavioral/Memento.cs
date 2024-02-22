namespace DesignPatterns.Patterns.Behavioral;

public class Memento(int number1, int number2)
{
    public int Number1 { get; } = number1;
    public int Number2 { get; } = number2;
}

public class CareTaker
{
    public Memento Memento { get; set; }
}

public class Calculator
{
    public int Number1 { get; set; }
    public int Number2 { get; set; }

    public int Sum() => Number1 + Number2;

    public Memento SaveMemento()
    {
        return new Memento(Number1, Number2);
    }

    public void RestoreMemento(Memento memento)
    {
        Number1 = memento.Number1;
        Number2 = memento.Number2;
    }
}

public static class UsageMemento
{
    public static void Usage()
    {
        Calculator calculator = new();
        calculator.Number1 = 2;
        calculator.Number2 = 3;

        Console.WriteLine($"State 1 = {calculator.Sum()}");

        CareTaker memento = new();
        memento.Memento = calculator.SaveMemento();

        calculator.Number1 = 10;
        calculator.Number2 = 10;

        Console.WriteLine($"State 2 = {calculator.Sum()}");

        calculator.RestoreMemento(memento.Memento);
        Console.WriteLine($"State 1 restored = {calculator.Sum()}");
    }
}