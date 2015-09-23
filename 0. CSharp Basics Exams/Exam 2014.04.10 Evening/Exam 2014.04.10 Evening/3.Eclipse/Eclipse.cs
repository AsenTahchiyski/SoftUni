using System;
class Eclipse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(" {0}{1}{0} ", new string('*', 2 * n - 2), new string(' ', n + 1));
        for (int i = 0; i < n - 2; i++)
        {
            Console.WriteLine("*{0}*{1}*{0}*", new string('/', 2 * n - 2), i == ((n - 1) / 2) - 1 ? new string('-', n - 1) : new string(' ', n - 1));
        }
        Console.WriteLine(" {0}{1}{0} ", new string('*', 2 * n - 2), new string(' ', n + 1));
    }
}
