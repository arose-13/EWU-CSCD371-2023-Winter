using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void Create_UsingDefaultConstructor_Success()
    {
        // Assemble
        Program program = new();

        // Assert
        Assert.IsNotNull(program);
    }

    [TestMethod]
    public void Create_GivenConsoleMethods_Success()
    {
        // Assemble
        Program program = new(Console.WriteLine, Console.ReadLine);

        // Assert
        Assert.IsNotNull(program);
    }

    [TestMethod]
    public void WriteLine_GivenWriteLineMethod_WriteLineSuccessfullyWrites()
    {
        // Assemble
        string text = "Dummy text.";
        Program program = new Program
        {
            WriteLine = (string input) => { text = input; },
            ReadLine = System.Console.ReadLine
        };

        // Act
        program.WriteLine("Hello World!");

        // Assert
        Assert.AreEqual<string>(text, "Hello World!");

    }
}
