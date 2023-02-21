using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection.Metadata.Ecma335;
using static System.Net.Mime.MediaTypeNames;

namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void GivenWriteLineMethod_WriteLineSuccessfullyWrites()
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
        public void GivenInvalidOperation_WritesError()
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
            Assert.IsTrue(output.Contains("invalid"));
        }

        [TestMethod]
        public void GivenValidOperations_AllOperationsReturnCorrectResult()
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
    }
}