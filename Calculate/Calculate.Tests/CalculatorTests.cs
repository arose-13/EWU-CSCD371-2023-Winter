using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Calculate_GivenValidOperations_AllOperationsReturnCorrectResult()
    {
        // Assemble
        double result = 0;
        Program program = new Program
        {
            WriteLine = (string input) => { result = double.Parse(input); },
        };

        // Act and Assert
        program.WriteLine(program.calculator.TryCalculate("3 + 3"));
        Assert.AreEqual<double>(result, 6);

        program.WriteLine(program.calculator.TryCalculate("3 - 3"));
        Assert.AreEqual<double>(result, 0);

        program.WriteLine(program.calculator.TryCalculate("3 * 3"));
        Assert.AreEqual<double>(result, 9);

        program.WriteLine(program.calculator.TryCalculate("3 / 3"));
        Assert.AreEqual<double>(result, 1);
    }

    [TestMethod]
    public void Calculate_GivenOperationWithRemainder_WritesDecimal()
    {
        // Assemble
        double output = 0;
        Program program = new Program
        {
            WriteLine = (string input) => { output = double.Parse(input); },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate("5 / 2"));

        // Assert
        Assert.AreEqual<double>(output, 2.5);
    }

    [TestMethod]
    public void Calculate_GivenInvalidOperation_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Program program = new Program
        {
            WriteLine = (string input) => { output = input; },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate("1 & 2"));

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    [TestMethod]
    public void Calculate_DivideByZero_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Program program = new Program
        {
            WriteLine = (string input) => { output = input; },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate("6 / 0"));

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    [TestMethod]
    public void Calculate_GivenNull_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Program program = new Program
        {
            WriteLine = (string input) => { output = input; },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate(null));

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    [TestMethod]
    public void Calculate_GivenOperationWithoutWhiteSpace_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Program program = new Program
        {
            WriteLine = (string input) => { output = input; },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate("1+1"));

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    [TestMethod]
    public void Calculate_GivenOperationWithOnlyWhiteSpace_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Program program = new Program
        {
            WriteLine = (string input) => { output = input; },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate("        "));

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }
}