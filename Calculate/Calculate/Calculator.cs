using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;

public class Calculator
{
    public IReadOnlyDictionary<char, Func<double, double, double>> MathematicalOperations { get; }
        = new Dictionary<char, Func<double, double, double>>
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiple },
            { '/', Divide },
        };

    public static double Add(double a, double b) => a + b;
    public static double Subtract(double a, double b) => a - b;
    public static double Multiple(double a, double b) => a * b;
    public static double Divide(double a, double b) => a / b;

    public string TryCalculate(string? calculation)
    {
        if (string.IsNullOrWhiteSpace(calculation))
            return "Error: Cannot accept a null operation!";

        try
        {
            string[] calcuationParts = calculation.Split(' ');

            bool operand1 = double.TryParse(calcuationParts[0], out double a);
            bool operand2 = double.TryParse(calcuationParts[2], out double b);
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
        catch (InvalidCastException)
        {
            return "Error: Invalid Cast!";
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
