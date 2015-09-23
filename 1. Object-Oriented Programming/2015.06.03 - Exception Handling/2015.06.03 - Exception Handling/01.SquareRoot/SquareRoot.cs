using System;
class SquareRoot
{
    static void Main()
    {
        Console.Write("Please enter an integer: ");
        try
        {
            int num = int.Parse(Console.ReadLine());
            if (num < 0)
            {
                Console.WriteLine("Invalid number.");
            }
            else
            {
                double result = Math.Sqrt(num);
                Console.WriteLine("Square root of {0} is {1}.", num, result);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number.");
        }
        finally
        {
            Console.WriteLine("Good bye.");
        }
    }
}
