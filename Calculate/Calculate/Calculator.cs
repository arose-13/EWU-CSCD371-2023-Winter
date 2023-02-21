using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;

public class Calculator
{
    public Action<string> WriteLine { get; init; }
    public Func<string?> ReadLine { get; init; }
    public IReadOnlyDictionary<char, Func<int, int, double>> MathematicalOperations { get; }
        = new Dictionary<char, Func<int, int, double>>
        {
            { '+', Add },
            { '-', Subtract },
            { '*', Multiple },
            { '/', Divide },
        };

    public Calculator()
    {
        WriteLine = System.Console.WriteLine;
        ReadLine = System.Console.ReadLine;
    }

    public Calculator(Action<string> writeLine, Func<string> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
    }

    public static double Add(int a, int b) => a + b;
    public static double Subtract(int a, int b) => a - b;
    public static double Multiple(int a, int b) => a * b;
    public static double Divide(int a, int b) => a / b;

    public void Calculate(string? calculation)
    {
        if (string.IsNullOrWhiteSpace(calculation))
        {
            WriteLine("Error: Cannot accept a null operation!");
            return;
        }
        else if (!calculation.Contains(' '))
        {
            WriteLine("Error: Operation must contain spaces between the numbers and the operator!");
            return;
        }

        string[] calcuationParts = calculation.Split(' ');

        try
        {
            int a = int.Parse(calcuationParts[0]);
            int b = int.Parse(calcuationParts[2]);
            char operate = char.Parse(calcuationParts[1]);

            WriteLine($"{MathematicalOperations[operate](a, b)}");

        }
        catch (FormatException)
        {
            WriteLine("Error: Invalid Format!");
        }
        catch (DivideByZeroException)
        {
            WriteLine("Error: Cannot divide by 0!");
        }
        catch (InvalidCastException)
        {
            WriteLine("Error: Invalid Cast!");
        }
        catch (KeyNotFoundException)
        {
            WriteLine("Error: An invalid operation was specified! (Key not found)");
        }
        catch (IndexOutOfRangeException)
        {
            WriteLine("Error: Please use correct amount of spacing!");
        }
    }
}
