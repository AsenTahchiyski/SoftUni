using System;
class NewHouse
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n / 2 + 1; i++)
        {
            Console.WriteLine("{0}{1}{0}", new string('-', (n - 1) / 2 - i), new string('*', 2 * i + 1));    
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("|{0}|", new string('*', n - 2));
        }
    }
}
