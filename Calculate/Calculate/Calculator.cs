using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate;

public class Calculator
{
    public Action<string> WriteLine { get; init; }
    public Func<string> ReadLine { get; init; }
    public IReadOnlyDictionary<char, Func<int, int, int>> MathematicalOperations { get; }
        = new Dictionary<char, Func<int, int, int>>
        {
            { "+", Add() },
            { "-", Subtract() },
            { "*", Multiply() },
            { "/", Divide() },
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
}
