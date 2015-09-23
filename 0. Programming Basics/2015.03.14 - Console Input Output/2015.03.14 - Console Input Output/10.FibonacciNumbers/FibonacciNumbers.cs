using System;
class FibonacciNumbers
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        if (n > 0)
        {
            Console.Write("Fibonacci Numbers: 0");
        }
        if (n > 1)
        {
            Console.Write(" 1");
        }
        int minus1 = 1;
        int minus2 = 0;
        for (int i = 2; i < n; i++)
        {
            int number = minus1 + minus2;
            Console.Write(" " + number);
            minus2 = minus1;
            minus1 = number;
        }
        Console.WriteLine();
    }
}
