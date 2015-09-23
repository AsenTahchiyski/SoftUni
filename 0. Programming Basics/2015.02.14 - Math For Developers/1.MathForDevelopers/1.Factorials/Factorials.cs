using System;
using System.Numerics;

class Factorials
{
    static void Main()
    {
        int factorial = 100;
        BigInteger result = 1;
        for (int i = 1; i <= factorial; i++)
        {
            result = result * i;
        }
        Console.WriteLine(result);
    }
}
