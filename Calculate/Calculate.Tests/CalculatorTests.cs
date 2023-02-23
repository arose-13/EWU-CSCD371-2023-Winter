namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Calculate_GivenValidOperations_AllOperationsReturnCorrectResult()
    {
        // Assemble
        int result = 0;
        Program program = new Program
        {
            WriteLine = (string input) => { result = int.Parse(input); },
        };

        // Act and Assert
        program.WriteLine(program.calculator.TryCalculate("3 + 3"));
        Assert.AreEqual<int>(result, 6);

        program.WriteLine(program.calculator.TryCalculate("3 - 3"));
        Assert.AreEqual<int>(result, 0);

        program.WriteLine(program.calculator.TryCalculate("3 * 3"));
        Assert.AreEqual<int>(result, 9);

        program.WriteLine(program.calculator.TryCalculate("3 / 3"));
        Assert.AreEqual<int>(result, 1);
    }

    [TestMethod]
    public void Calculate_GivenOperationWithRemainder_WritesDecimal()
    {
        // Assemble
        int output = 0;
        Program program = new Program
        {
            WriteLine = (string input) => { output = int.Parse(input); },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate("5 / 2"));

        // Assert
        Assert.AreEqual<int>(output, 2);
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