using System;
class KingOfThieves
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        char symbol = char.Parse(Console.ReadLine());
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('-', ((n - 1) / 2) - i), new string(symbol, 2 * i + 1));
        }
        Console.WriteLine(new string(symbol, n));
        for (int i = 0; i < (n - 1) / 2; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('-', i + 1), new string(symbol, n - 2 * (i + 1)));
        }
    }
}
