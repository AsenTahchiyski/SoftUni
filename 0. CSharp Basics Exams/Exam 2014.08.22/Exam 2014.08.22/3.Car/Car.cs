using System;
class Car
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int counter = 0;
        Console.WriteLine("{0}{1}{0}", new string('.', n), new string('*', n));
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', n - 1 - i), new string('.', n + 2 * i));
            counter = n - 1 - i;
        }
        Console.WriteLine("{0}{1}{0}", new string('*', counter), new string('.', 3 * n - 2 * counter));
        for (int i = 0; i < n / 2 - 2; i++)
        {
            Console.WriteLine("*{0}*", new string('.', 3 * n - 2));
        }
        Console.WriteLine(new string('*', 3 * n));
        for (int i = 0; i < n / 2 - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{2}*{1}*{0}", new string('.', n / 2), new string('.', n / 2 - 1), new string('.', n - 2));
        }
        Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', n / 2), new string('*', n / 2 + 1), new string('.', n - 2));
    }
}
