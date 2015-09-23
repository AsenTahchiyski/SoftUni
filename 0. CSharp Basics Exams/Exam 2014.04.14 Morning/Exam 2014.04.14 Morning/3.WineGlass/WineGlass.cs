using System;
class WineGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n / 2; i++)
        {
            Console.WriteLine("{0}\\{1}/{0}", new string('.', i), new string('*', n - 2 * (i + 1)));
        }
        if (n < 12)
        {
            for (int i = 0; i < n / 2 - 1; i++)
            {
                Console.WriteLine("{0}||{0}", new string('.', (n - 2) / 2));
            }
            Console.WriteLine(new string('-', n));
        }
        else
        {
            for (int i = 0; i < n / 2 - 2; i++)
            {
                Console.WriteLine("{0}||{0}", new string('.', (n - 2) / 2));
            }
            Console.WriteLine("{0}\n{0}", new string('-', n));
        }
    }
}
