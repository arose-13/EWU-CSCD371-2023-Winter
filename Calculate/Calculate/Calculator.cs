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

    public void Calculate(string calulation)
    {
        string[] calcuationParts = calulation.Split(' ');

        try
        {
            int a = int.Parse(calcuationParts[0]);
            int b = int.Parse(calcuationParts[2]);
            string operate = calcuationParts[1];

            if (string.IsNullOrWhiteSpace(operate))
                throw new FormatException();
        }
        catch (FormatException)
        {
            WriteLine("Invalid Operation");
        }
    }
}
