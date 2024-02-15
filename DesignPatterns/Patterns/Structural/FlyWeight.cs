namespace DesignPatterns.Patterns.Structural;

public class Shape
{
    private string Type { get; }
    private string Color { get; }

    public Shape(string type, string color)
    {
        Type = type;
        Color = color;
    }

    public void Draw()
    {
        Console.WriteLine($"Shape {Type} and color {Color} drawn");
    }
}

public class ShapeFactory
{
    private static readonly Dictionary<string, Shape> Shapes = new();

    public static Shape GetShape(string type, string color)
    {
        string key = $"{type}_{color}";

        if (!Shapes.ContainsKey(key))
        {
            Shapes[key] = new Shape(type, color);
        }

        return Shapes[key];
    }
}

public static class UsageFlyWeight
{
    public static void Usage()
    {
        for (int i = 0; i < 5; i++)
        {
            var shape = ShapeFactory.GetShape("Circle", "Red");
            shape.Draw();
        }

        for (int i = 0; i < 5; i++)
        {
            var shape = ShapeFactory.GetShape("Circle", "Green");
            shape.Draw();
        }

        for (int i = 0; i < 5; i++)
        {
            var shape = ShapeFactory.GetShape("Circle", "Blue");
            shape.Draw();
        }
    }
}