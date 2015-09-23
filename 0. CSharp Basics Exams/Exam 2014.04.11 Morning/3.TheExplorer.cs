using System;
class TheExplorer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}*{0}", new string('-', n / 2));
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('-', (n - 3 - (i * 2) + 1) / 2), new string('-', i * 2 + 1));
        }
        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('-', i + 1), new string('-', n - 4 - 2 * i));
        }
        Console.WriteLine("{0}*{0}", new string('-', n / 2));
    }
}