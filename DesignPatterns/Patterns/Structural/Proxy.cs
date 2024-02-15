namespace DesignPatterns.Patterns.Structural;

public interface ISharedFolder
{
    public void ReadAndWriteOperation(string role);
}

public class SharedFolder : ISharedFolder
{
    public void ReadAndWriteOperation(string role)
    {
        Console.WriteLine($"{role} = Access allowed to folder");
    }
}

public class SharedFolderProxy : ISharedFolder
{
    private readonly SharedFolder _sharedFolder;

    public SharedFolderProxy(SharedFolder sharedFolder)
    {
        _sharedFolder = sharedFolder;
    }

    public void ReadAndWriteOperation(string role)
    {
        if (role.ToUpper().Equals("ADMIN"))
        {
            _sharedFolder.ReadAndWriteOperation(role);
        }
        else
        {
            Console.WriteLine("Access denied");
        }
    }
}

public static class UsageProxy
{
    public static void Usage()
    {
        var sharedFolder = new SharedFolder();
        var proxyFolder = new SharedFolderProxy(sharedFolder);

        proxyFolder.ReadAndWriteOperation("user");

        proxyFolder.ReadAndWriteOperation("admin");
    }
}