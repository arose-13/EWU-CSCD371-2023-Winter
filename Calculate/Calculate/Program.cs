namespace Calculate;

public class Program
{
    public Action<string> WriteLine { get; init; }
    public Func<string?> ReadLine { get; init; }
    public Calculator calculator { get; set; }

    public Program()
    {
        WriteLine = System.Console.WriteLine;
        ReadLine = System.Console.ReadLine;
        calculator = new Calculator();
    }

    public Program(Action<string> writeLine, Func<string?> readLine)
    {
        WriteLine = writeLine;
        ReadLine = readLine;
        calculator = new Calculator();
    }

    public static void Main()
    {
        Program program = new();
        program.WriteLine("---Welcome---");

        int sentenal = 1;
        while (sentenal == 1)
        {
            program.WriteLine("---Enter calculation or press q to quit---");
            string? input1 = program.ReadLine();
            if (input1 == "q")
            {
                sentenal--;
            }
            else
            {
                program.WriteLine(program.calculator.TryCalculate(input1));
            }
        }
    }

}