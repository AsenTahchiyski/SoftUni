using System;
using System.Numerics;
class Trailing0sinNFactorial
{
    static void Main()
    {
        // smart way to solve - http://www.purplemath.com/modules/factzero.htm
        Start:
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int trailing0s = 0, divisor = 5;
        do
        {
            trailing0s += n / divisor;
            divisor *= 5;
        } while (divisor <= n);
        Console.WriteLine(trailing0s + " trailing 0-s");
        goto Start;

        // dumb way to solve
        // calculating factorial of 100000 takes some time since the number is enormous and it takes significant amount of the computer RAM memory to store   

        //Console.Write("n = ");
        //int n = int.Parse(Console.ReadLine());
        //BigInteger factorial = 1;
        //for (int i = 1; i <= n; i++)
        //{
        //    factorial *= i;
        //}
        //int trailingZeroes = 0;
        //while (factorial % 10 == 0)
        //{
        //    trailingZeroes++;
        //    factorial /= 10;
        //}
        //Console.WriteLine("n-factorial trailing 0-s: " + trailingZeroes);
    }
}
