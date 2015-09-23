using System;
class NumsFrom1toN
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", i + 1);
        }
        Console.WriteLine();
    }
}
