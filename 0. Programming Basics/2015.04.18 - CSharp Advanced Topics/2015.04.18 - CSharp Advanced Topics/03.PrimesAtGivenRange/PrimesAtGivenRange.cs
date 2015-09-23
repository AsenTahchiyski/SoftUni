using System;
using System.Collections.Generic;
class PrimesAtGivenRange
{
    static void Main()
    {
        int startNum = int.Parse(Console.ReadLine());
        int endNum = int.Parse(Console.ReadLine());
        PrintList(startNum, endNum);
    }
    static List<int> FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for (int i = startNum; i <= endNum; i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes;
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
    static void PrintList(int startNum, int endNum)
    {
        for (int i = 0; i < FindPrimesInRange(startNum, endNum).Count; i++)
        {
            Console.Write("{0}{1}", FindPrimesInRange(startNum, endNum)[i], i == FindPrimesInRange(startNum, endNum).Count - 1 ? "" : ", ");
        }
        Console.WriteLine();
    }
}
