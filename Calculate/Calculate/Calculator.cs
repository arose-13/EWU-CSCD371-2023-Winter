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
    public static double Divide(int a, int b)
    {
        if (b is 0)
            return 0;

        return (double)a / b;
    }

    public void Calculate(string calculation)
    {
        if (!calculation.Contains(' ') || string.IsNullOrWhiteSpace(calculation))
        {
            WriteLine("The entered operation is invalid!");
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
            WriteLine("Invalid Operation");
        }
        catch (InvalidCastException)
        {
            WriteLine("Invalid Cast!");
        }
        catch (KeyNotFoundException)
        {
            WriteLine("An invalid operation was specified! (Key not found)");
        }
    }
}
