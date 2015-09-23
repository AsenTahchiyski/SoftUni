using System;
class RockLq
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        // line 1
        for (int dots = 0; dots < n; dots++)
        {
            Console.Write(".");
        }
        for (int dots = 0; dots < n; dots++)
        {
            Console.Write("*");
        }
        for (int dots = 0; dots < n; dots++)
        {
            Console.Write(".");
        }
        Console.WriteLine();
        // upper half
        for (int row = 0; row < n / 2; row++)
        {
            for (int i = 0; i < n - 2 * (1 + row); i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int j = 0; j < n + 2 * (1 + 2 * row); j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int i = 0; i < n - 2 * (1 + row); i++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }
        // rakavi
        for (int row = 0; row < n / 2; row++)
        {
            Console.Write("*");
            for (int i = 0; i < n - 2 * (row + 1); i++)
            {
                Console.Write(".");
            }
            if (row > 0)
            {
                Console.Write("*");
                for (int k = 0; k < 1 + 2 * (row - 1); k++)
                {
                    Console.Write(".");
                }
            }
            Console.Write("*");
            for (int j = 0; j < n; j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            if (row > 0)
            {
                for (int k = 0; k < 1 + 2 * (row - 1); k++)
                {
                    Console.Write(".");
                }
                Console.Write("*");
            }
            for (int i = 0; i < n - 2 * (row + 1); i++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            Console.WriteLine();
        }
        //lower half
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - (1 + i); j++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int k = 0; k < n + 2 * i; k++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int j = 0; j < n - (1 + i); j++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }
        for (int i = 0; i < 3 * n; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
}
