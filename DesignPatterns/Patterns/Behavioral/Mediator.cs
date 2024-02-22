namespace DesignPatterns.Patterns.Behavioral;

public interface IMediator
{
    void Register(User user);
    void SendMessage(string message, User user);
}

public class ChatRoom : IMediator
{
    private List<User> _users = new();

    public void Register(User user)
    {
        _users.Add(user);
    }

    public void SendMessage(string message, User user)
    {
        foreach (var u in _users)
        {
            if (u != user)
            {
                u.Receive(message);
            }
        }
    }
}

public abstract class User(IMediator mediator, string name)
{
    protected string Name = name;
    protected IMediator Mediator = mediator;

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

public class ConcreteUser(IMediator mediator, string name) : User(mediator, name)
{
    public override void Receive(string message)
    {
        Console.WriteLine($"{name} received => {message}");
    }

    public override void Send(string message)
    {
        Console.WriteLine($"{name} sent => {message}");
        mediator.SendMessage(message, this);
    }
}

public static class UsageMediator
{
    public static void Usage()
    {
        ChatRoom chatRoom = new();

        User john = new ConcreteUser(chatRoom, "John");
        User alex = new ConcreteUser(chatRoom, "Alex");
        User peter = new ConcreteUser(chatRoom, "Peter");
        User maria = new ConcreteUser(chatRoom, "Maria");

        chatRoom.Register(john);
        chatRoom.Register(alex);
        chatRoom.Register(peter);
        chatRoom.Register(maria);

        john.Send("Hi guys");

        peter.Send("Hi john, how are you?");

        john.Send("I'm fine peter");
    }
}