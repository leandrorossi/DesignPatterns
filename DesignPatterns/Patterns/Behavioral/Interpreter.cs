namespace DesignPatterns.Patterns.Behavioral;

public class Context(string expression, DateTime date)
{
    public string Expression { get; set; } = expression;

    public DateTime Date { get; set; } = date;
}

public interface IAbstractExpression
{
    void Interpret(Context context);
}

public class DayExpression : IAbstractExpression
{
    public void Interpret(Context context)
    {
        string expression = context.Expression;
        context.Expression = expression.Replace("DD", context.Date.Day.ToString("D2"));
    }
}

public class MonthExpression : IAbstractExpression
{
    public void Interpret(Context context)
    {
        string expression = context.Expression;
        context.Expression = expression.Replace("MM", context.Date.Month.ToString("D2"));
    }
}

public class YearExpression : IAbstractExpression
{
    public void Interpret(Context context)
    {
        string expression = context.Expression;
        context.Expression = expression.Replace("YYYY", context.Date.Year.ToString());
    }
}

public static class UsageInterpreter
{
    public static void Usage()
    {
        Context context = new("YYYY-MM-DD", DateTime.Now);
        Console.WriteLine($"Date before interpreter: {context.Date}");

        List<IAbstractExpression> list =
        [
            new DayExpression(),
            new MonthExpression(),
            new YearExpression()
        ];

        foreach (var obj in list)
        {
            obj.Interpret(context);
        }

        Console.WriteLine($"Date after interpreter: {context.Expression}");
    }
}