using System;
class NumbersFrom1toN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(i + 1);
        }
    }
}
