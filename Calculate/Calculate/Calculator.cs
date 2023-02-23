namespace Calculate;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; }
        = new Dictionary<char, Func<int, int, int>>
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiple },
            { '/', Divide },
        };

    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiple(int a, int b) => a * b;
    public static int Divide(int a, int b) => a / b;

    public string TryCalculate(string? calculation)
    {
        if (string.IsNullOrWhiteSpace(calculation))
            return "Error: Cannot accept a null operation!";

        try
        {
            string[] calcuationParts = calculation.Split(' ');

            bool operand1 = int.TryParse(calcuationParts[0], out int a);
            bool operand2 = int.TryParse(calcuationParts[2], out int b);
            bool operation = char.TryParse(calcuationParts[1], out char operate);

            if (operate == '/' && b == 0)
                throw new DivideByZeroException();
            else if (!operand1 || !operand2 || !operation)
                throw new FormatException();
            else
                return $"{MathematicalOperations[operate](a, b)}";

        }
        catch (FormatException)
        {
            return "Error: Invalid Format!";
        }
        catch (DivideByZeroException)
        {
            return "Error: Cannot divide by 0!";
        }
        catch (KeyNotFoundException)
        {
            return "Error: An invalid operation was specified! (Key not found)";
        }
        catch (IndexOutOfRangeException)
        {
            return "Error: Please use correct amount of spacing!";
        }
    }
}
