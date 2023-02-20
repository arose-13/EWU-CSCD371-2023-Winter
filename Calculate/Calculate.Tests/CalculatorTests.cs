namespace Calculate.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void GivenWriteLineMethod_WriteLineSuccessfullyWrites()
        {
            // Assemble
            Calculator calculator = new(System.Console.WriteLine, System.Console.ReadLine);

            // Act
            calculator.WriteLine("Hello World!");
            
        }

        [TestMethod]
        public void DefaultConstructor_WriteLineSuccessfullyWrites()
        {
            // Assemble
            Calculator calculator = new();

            // Act
            calculator.WriteLine("Hello World!");

        }
    }
}