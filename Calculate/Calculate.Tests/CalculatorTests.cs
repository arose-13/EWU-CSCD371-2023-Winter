using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Create_UsingDefaultConstructor_Success()
    {
        // Assemble
        Calculator calculator = new();

        // Assert
        Assert.IsNotNull(calculator);
    }

    [TestMethod]
    public void Create_GivenConsoleMethods_Success()
    {
        // Assemble
        Calculator calculator = new(Console.WriteLine, Console.ReadLine);

        // Assert
        Assert.IsNotNull(calculator);
    }

    [TestMethod]
    public void WriteLine_GivenWriteLineMethod_WriteLineSuccessfullyWrites()
    {
        // Assemble
        string text = "Dummy text.";
        Calculator calculator = new Calculator
        {
            WriteLine = (string input) => { text = input; },
            ReadLine = System.Console.ReadLine
        };

        // Act
        calculator.WriteLine("Hello World!");

        // Assert
        Assert.AreEqual<string>(text, "Hello World!");
        
    }

    [TestMethod]
    public void Calculate_GivenValidOperations_AllOperationsReturnCorrectResult()
    {
        // Assemble
        double result = 0;
        Calculator calculator = new Calculator
        {
            WriteLine = (string input) => { result = double.Parse(input); },
            ReadLine = System.Console.ReadLine
        };

        // Act and Assert
        calculator.Calculate("3 + 3");
        Assert.AreEqual<double>(result, 6);

        calculator.Calculate("3 - 3");
        Assert.AreEqual<double>(result, 0);

        calculator.Calculate("3 * 3");
        Assert.AreEqual<double>(result, 9);

        calculator.Calculate("3 / 3");
        Assert.AreEqual<double>(result, 1);
    }

    [TestMethod]
    public void Calculate_GivenInvalidOperation_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Calculator calculator = new Calculator
        {
            WriteLine = (string input) => { output = input; },
            ReadLine = System.Console.ReadLine
        };

        // Act
        calculator.Calculate("1 & 2");

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    [TestMethod]
    public void Calculate_DivideByZero_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Calculator calculator = new Calculator
        {
            WriteLine = (string input) => { output = input; },
            ReadLine = System.Console.ReadLine
        };

        // Act
        calculator.Calculate("6 / 0");

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    [TestMethod]
    public void Calculate_GivenNull_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Calculator calculator = new Calculator
        {
            WriteLine = (string input) => { output = input; },
            ReadLine = System.Console.ReadLine
        };

        // Act
        calculator.Calculate(null);

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    [TestMethod]
    public void Calculate_GivenOperationWithoutWhiteSpace_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Calculator calculator = new Calculator
        {
            WriteLine = (string input) => { output = input; },
            ReadLine = System.Console.ReadLine
        };

        // Act
        calculator.Calculate("1+1");

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    public void Calculate_GivenOperationWithOnlyWhiteSpace_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Calculator calculator = new Calculator
        {
            WriteLine = (string input) => { output = input; },
            ReadLine = System.Console.ReadLine
        };

        // Act
        calculator.Calculate("        ");

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }
}