namespace DesignPatterns.Patterns;

public class Product
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Product Name = {Name}, Price = {Price}, Description = {Description}";
    }
}

public class ProductBuilder
{
    private readonly Product _product = new();

    public ProductBuilder AddName(string name)
    {
        _product.Name = name;
        return this;
    }

    public ProductBuilder AddPrice(double price)
    {
        _product.Price = price;
        return this;
    }

    public ProductBuilder AddDescription(string description)
    {
        _product.Description = description;
        return this;
    }

    public Product Build()
    {
        return _product;
    }
}

public static class UsageBuilder
{
    public static void Usage()
    {
        var product = new ProductBuilder()
            .AddName("Product")
            .AddPrice(100.0)
            .AddDescription("Product A")
            .Build();
        
        Console.WriteLine(product.ToString());
    }
}