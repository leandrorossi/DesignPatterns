namespace DesignPatterns.Patterns.Behavioral;

public interface ICompression
{
    void Compress();
}

public class RarCompression : ICompression
{
    public void Compress()
    {
        Console.WriteLine("File compressed with rar algorithm");
    }
}

public class ZipCompression : ICompression
{
    public void Compress()
    {
        Console.WriteLine("File compressed with zip algorithm");
    }
}

public class GZipCompression : ICompression
{
    public void Compress()
    {
        Console.WriteLine("File compressed with gzip algorithm");
    }
}

public class CompressionContext
{
    private ICompression _compression;

    public void SetCompression(ICompression compression)
    {
        _compression = compression;
    }

    public void Compress()
    {
        _compression.Compress();
    }
}

public static class UsageStrategy
{
    public static void Usage()
    {
        CompressionContext compression = new();

        compression.SetCompression(new RarCompression());
        compression.Compress();

        compression.SetCompression(new ZipCompression());
        compression.Compress();

        compression.SetCompression(new GZipCompression());
        compression.Compress();
    }
}