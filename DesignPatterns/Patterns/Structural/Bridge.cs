namespace DesignPatterns.Patterns.Structural;

public interface IGenerateFile
{
    public void GenerateFile();
}

public class GenerateXml : IGenerateFile
{
    public void GenerateFile()
    {
        Console.WriteLine("XML created");
    }
}

public class GenerateJson : IGenerateFile
{
    public void GenerateFile()
    {
        Console.WriteLine("JSON created");
    }
}

public abstract class Abstraction
{
    protected readonly IGenerateFile GenerateFile;

    protected Abstraction(IGenerateFile generateFile)
    {
        GenerateFile = generateFile;
    }

    public abstract void CreateFile();
}

public class ExtendAbstraction : Abstraction
{
    public ExtendAbstraction(IGenerateFile generateFile) : base(generateFile)
    {
    }

    public override void CreateFile()
    {
        GenerateFile.GenerateFile();
    }
}

public static class UsageBridge
{
    public static void Usage()
    {
        var extendAbstraction = new ExtendAbstraction(new GenerateXml());
        extendAbstraction.CreateFile();

        extendAbstraction = new ExtendAbstraction(new GenerateJson());
        extendAbstraction.CreateFile();
    }
}