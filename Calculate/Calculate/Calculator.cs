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

    public static int Add(int leftOperand, int rightOperand) => leftOperand + rightOperand;
    public static int Subtract(int leftOperand, int rightOperand) => leftOperand - rightOperand;
    public static int Multiple(int leftOperand, int rightOperand) => leftOperand * rightOperand;
    public static int Divide(int leftOperand, int rightOperand) => leftOperand / rightOperand;

    public string TryCalculate(string? calculation)
    {
        if (string.IsNullOrWhiteSpace(calculation))
            return "Error: Cannot accept a null operation!";

        try
        {
            string[] calcuationParts = calculation.Split(' ');

            bool containsLeft = int.TryParse(calcuationParts[0], out int leftOperand);
            bool containsRight = int.TryParse(calcuationParts[2], out int rightOperand);
            bool containsOperation = char.TryParse(calcuationParts[1], out char operation);

            if (operation == '/' && rightOperand == 0)
                throw new DivideByZeroException();
            else if (!containsLeft || !containsRight || !containsOperation || calcuationParts.Length > 3)
                throw new FormatException();
            else
                return $"{MathematicalOperations[operation](leftOperand, rightOperand)}";

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
