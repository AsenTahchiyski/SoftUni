using System;
using System.Numerics;
class CalculateExpression3
{
    static void Main()
    {
    Start:
    int n, k;
    do
    {
        Console.Write("n = ");
        n = int.Parse(Console.ReadLine());
    } while (n > 100 || n < 3);
    do
    {
        Console.Write("k = ");
        k = int.Parse(Console.ReadLine());
    } while (k > n || k < 2);
    BigInteger NdivKFactorial = 1;
    BigInteger NminusKFactorial = 1;
    for (int i = k + 1; i <= n; i++)
    {
        NdivKFactorial *= i;
    }
    for (int i = 1; i <= n - k; i++)
    {
        NminusKFactorial *= i;
    }
    NdivKFactorial /= NminusKFactorial;
    Console.WriteLine(NdivKFactorial);
    goto Start;
    }
}
