namespace DesignPatterns.Patterns;

public class Department
{
    public string Name { get; set; } = string.Empty;

    public object Clone()
    {
        return MemberwiseClone();
    }
}

public class ProductPrototype : ICloneable
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public Department Department { get; set; } = null!;
    
    public override string ToString()
    {
        return $"Product Name = {Name}, Price = {Price}, Description = {Description}, Department = {Department.Name}";
    }

    public object Clone()
    {
        var product = (ProductPrototype)MemberwiseClone();
        product.Department = (Department)Department.Clone();
        return product;
    }
}

public static class UsagePrototype
{
    public static void Usage()
    {
        var product = new ProductPrototype
        {
            Name = "Product", Price = 100.0, Description = "Product A",
            Department = new Department() { Name = "Department" }
        };

        var clone1 = (ProductPrototype)product.Clone();

        var clone2 = (ProductPrototype)product.Clone();
        clone2.Name = "Product B";
        clone2.Price = 200.0;
        clone2.Description = "Product B";
        clone2.Department.Name = "Department B";

        Console.WriteLine(product.ToString());
        Console.WriteLine(clone1.ToString());
        Console.WriteLine(clone2.ToString());
    }
}