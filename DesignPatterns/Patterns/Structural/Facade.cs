namespace DesignPatterns.Patterns.Structural;

public class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("Subsystem A -> Operation A");
    }
}

public class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("Subsystem B -> Operation B");
    }
}


public class Facade
{
    private readonly SubsystemA _subsystemA;
    private readonly SubsystemB _subsystemB;

    public Facade(SubsystemA subsystemA, SubsystemB subsystemB)
    {
        _subsystemA = subsystemA;
        _subsystemB = subsystemB;
    }

    public void Operation()
    {
        _subsystemA.OperationA();
        _subsystemB.OperationB();
    }
}

public static class UsageFacade
{
    public static void Usage()
    {
        var subsystemA = new SubsystemA();
        var subsystemB = new SubsystemB();
        
        var facade = new Facade(subsystemA, subsystemB);
        facade.Operation();
    }
}