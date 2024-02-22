namespace DesignPatterns.Patterns.Behavioral;

public class Item(string name)
{
    public string Name = name;
}

public interface IAbstractIterator
{
    Item First();
    Item Next();
    bool IsDone { get; }
}

public interface IAbstractCollection
{
    Iterator CreateIterator();
}

public class Collection : IAbstractCollection
{
    private readonly List<Item> _items = new();

    public Iterator CreateIterator()
    {
        return new Iterator(this);
    }

    public int Count => _items.Count;

    public Item GetItem(int current) => _items[current];

    public void Add(Item item) => _items.Add(item);
}

public class Iterator(Collection collection) : IAbstractIterator
{
    private int _current;
    private int _step = 1;
    private Collection _collection = collection;

    public Item First()
    {
        _current = 0;
        return _collection.GetItem(_current);
    }

    public Item Next()
    {
        _current += _step;
        if (!IsDone)
        {
            return _collection.GetItem(_current);
        }

        return null;
    }

    public bool IsDone => _current >= _collection.Count;
}

public static class UsageIterator
{
    public static void Usage()
    {
        Collection collection = new();
        collection.Add(new Item("Item 1"));
        collection.Add(new Item("Item 2"));
        collection.Add(new Item("Item 3"));
        collection.Add(new Item("Item 4"));
        collection.Add(new Item("Item 5"));
        collection.Add(new Item("Item 6"));
        collection.Add(new Item("Item 7"));

        Iterator iterator = collection.CreateIterator();

        for (Item item = iterator.First(); !iterator.IsDone; item = iterator.Next())
        {
            Console.WriteLine(item.Name);
        }
    }
}