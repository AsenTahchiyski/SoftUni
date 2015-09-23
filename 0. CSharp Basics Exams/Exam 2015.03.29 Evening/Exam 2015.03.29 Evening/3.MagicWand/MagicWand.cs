using System;
class MagicWand
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        // 3*n+2 width
        int upperPart = n / 2 + 1;
        int width = 3 * n + 2;
        Console.WriteLine("{0}*{0}", new string('.', (width - 1) / 2));
        for (int i = 0; i < upperPart; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', ((width - 1) / 2) - (i + 1)), new string('.', 2 * i + 1));
        }
        Console.WriteLine("{0}{1}{0}", new string('*', n), new string('.', n + 2));
        int counter = 0;
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', i + 1), new string('.', width - 2 * (i + 1) - 2));
            counter++;
        }
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}*{3}*{1}*{2}*{1}*{3}*{0}", new string('.', counter - 1 - i), new string('.', i), new string('.', n), new string('.', n / 2));
        }
        Console.WriteLine("{0}{1}*{2}*{1}{0}", new string('*', (n + 1) / 2), new string('.', n / 2), new string('.', n));
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', n), new string('.', n));
        }
        Console.WriteLine("{0}*{1}*{0}", new string('.', n), new string('*', n));
    }
}
