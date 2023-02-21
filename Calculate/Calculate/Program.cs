namespace Calculate;

class Program
{
    public static void Main()
    {
        Calculator calculator = new();
        calculator.WriteLine("---Welcome---");

        int sentenal = 1;
        while (sentenal == 1)
        {
            calculator.WriteLine("---Enter calculation or press q to quit---");
            string? input1 = calculator.ReadLine();
            if (input1 == "q")
            {
                sentenal--;
            }
            else
            {
                calculator.Calculate(input1);
            }
        }
    }

}