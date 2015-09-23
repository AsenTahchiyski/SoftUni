using System;
class DumbBell
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', (n - 1) / 2), new string('&', (n + 1) / 2), new string('.', n));
        for (int i = 1; i < ((n - 1) / 2); i++)
        {
            Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', ((n - 1) / 2) - i),
                new string('*', n - 2 - (((n - 1) / 2) - i)), new string('.', n));
        }
        Console.WriteLine("&{0}&{1}&{0}&", new string('*', n - 2), new string('=', n));
        for (int i = 1; i < ((n - 1) / 2); i++)
        {
            Console.WriteLine("{0}&{1}&{2}&{1}&{0}", new string('.', i), 
                new string('*', n - i - 2), new string('.', n));
        }
        Console.WriteLine("{0}{1}{2}{1}{0}", new string('.', (n - 1) / 2), new string('&', (n + 1) / 2), new string('.', n));
    }
}
