using System;
class PrimeChecker
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        Console.WriteLine(IsPrime(n));
    }
    static bool IsPrime(long n)
    {
        if ((n & 1) == 0)
	    {
            if (n == 2) return true;
            else return false;
	    }
        for (long i = 3; (i * i) <= n; i += 2)
        {
            if (n % i == 0) return false;
        }
        return n != 1;
    }
}
