namespace Calculate.Tests;

[TestClass]
public class CalculatorTests
{
    // ---------- Operations Tests ---------- \\
    [TestMethod]
    public void Add_GivenValidOperations_ReturnCorrectResult()
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

        program.WriteLine(program.calculator.TryCalculate("823 + 100"));
        Assert.AreEqual<int>(result, 923);

        program.WriteLine(program.calculator.TryCalculate("0 + 0"));
        Assert.AreEqual<int>(result, 0);

        program.WriteLine(program.calculator.TryCalculate("12 + 0"));
        Assert.AreEqual<int>(result, 12);
    }

    [TestMethod]
    public void Subtract_GivenValidOperations_ReturnCorrectResult()
    {
        // Assemble
        int result = 0;
        Program program = new Program
        {
            WriteLine = (string input) => { result = int.Parse(input); },
        };

        // Act and Assert
        program.WriteLine(program.calculator.TryCalculate("3 - 3"));
        Assert.AreEqual<int>(result, 0);

        program.WriteLine(program.calculator.TryCalculate("326 - 310"));
        Assert.AreEqual<int>(result, 16);

        program.WriteLine(program.calculator.TryCalculate("0 - 0"));
        Assert.AreEqual<int>(result, 0);

        program.WriteLine(program.calculator.TryCalculate("12 - 0"));
        Assert.AreEqual<int>(result, 12);
    }

    [TestMethod]
    public void Multiply_GivenValidOperations_ReturnCorrectResult()
    {
        // Assemble
        int result = 0;
        Program program = new Program
        {
            WriteLine = (string input) => { result = int.Parse(input); },
        };

        // Act and Assert
        program.WriteLine(program.calculator.TryCalculate("3 * 3"));
        Assert.AreEqual<int>(result, 9);

        program.WriteLine(program.calculator.TryCalculate("350 * 100"));
        Assert.AreEqual<int>(result, 35000);

        program.WriteLine(program.calculator.TryCalculate("0 * 0"));
        Assert.AreEqual<int>(result, 0);

        program.WriteLine(program.calculator.TryCalculate("12 * 0"));
        Assert.AreEqual<int>(result, 0);
    }

    [TestMethod]
    public void Divide_GivenValidOperations_ReturnCorrectResult()
    {
        // Assemble
        int result = 0;
        Program program = new Program
        {
            WriteLine = (string input) => { result = int.Parse(input); },
        };

        // Act and Assert
        program.WriteLine(program.calculator.TryCalculate("9 / 3"));
        Assert.AreEqual<int>(result, 3);

        program.WriteLine(program.calculator.TryCalculate("799 / 100"));
        Assert.AreEqual<int>(result, 7);

        program.WriteLine(program.calculator.TryCalculate("1 / 1"));
        Assert.AreEqual<int>(result, 1);

        program.WriteLine(program.calculator.TryCalculate("0 / 12"));
        Assert.AreEqual<int>(result, 0);
    }

    // ---------- Error Checking ---------- \\

    [TestMethod]
    public void Calculate_GivenCharacters_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Program program = new Program
        {
            WriteLine = (string input) => { output = input; },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate("abcd"));

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
    }

    [TestMethod]
    public void Calculate_GivenJustNumbers_WritesErrorMessage()
    {
        // Assemble
        string output = "Dummy test.";
        Program program = new Program
        {
            WriteLine = (string input) => { output = input; },
        };

        // Act
        program.WriteLine(program.calculator.TryCalculate("1 244"));

        // Assert
        Assert.IsTrue(output.Contains("Error: "));
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