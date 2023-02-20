namespace Calculate;

class Program
{
    public static void Main()
    {
        Calculator calculator = new();
        calculator.WriteLine("This works!");
        string input = calculator.ReadLine();
        calculator.WriteLine($"You entered {input}");
    }

}