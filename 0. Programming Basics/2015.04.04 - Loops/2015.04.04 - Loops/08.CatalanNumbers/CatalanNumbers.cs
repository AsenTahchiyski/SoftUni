using System;
using System.Numerics;
class CatalanNumbers
{
    static void Main()
    {
        Start:
        int n;
        do
        {
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
        } while (n < 0 || n > 100);
        BigInteger catalanNumTop = 1;
        BigInteger catalanNumBottom = 1;
        for (int i = 2; i <= n; i++)
        {
            catalanNumTop *= n + i;
            catalanNumBottom *= i;
        }
        Console.WriteLine("Catalan number {0} is {1}", n, catalanNumTop / catalanNumBottom);
        goto Start;
    }
}
