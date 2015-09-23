using System;
using System.Collections.Generic;
using System.Linq;
class StuckNumbers
{
    static bool noResult = true;
    static int[] indexes = new int[4];
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        long combos = (long)Math.Pow(2, n);
        for (long i = 15; i < combos; i++)
        {
            if (Check1sGetPositions(i))
            {
                string a = numbers[indexes[0]].ToString();
                string b = numbers[indexes[1]].ToString();
                string c = numbers[indexes[2]].ToString();
                string d = numbers[indexes[3]].ToString();
                PrintIfSolved(a, b, c, d);
                PrintIfSolved(b, a, c, d);
                PrintIfSolved(a, b, d, c);
                PrintIfSolved(b, a, d, c);
            }
        }
        if (noResult)
        {
            Console.WriteLine("No");
        }
    }
    // check if bit mask contains exactly 4 set bits
    static bool Check1sGetPositions(long combo)
    {
        indexes.Initialize();
        int count = 0, index = 0, bit = 0;
        while (combo != 0)
        {
            if ((combo & 1) == 1)
            {
                count++;
                if (count > 4) return false;
                indexes[index] = bit;
                index++;
            }
            combo >>= 1;
            bit++;
        }
        if (count == 4) return true;
        else return false;
    }
    // append strings, check for equity and print result if true
    static void PrintIfSolved(string a, string b, string c, string d)
    {
        if (a + b == c + d)
        {
            Console.WriteLine("{0}|{1}=={2}|{3}", a, b, c, d);
            Console.WriteLine("{0}|{1}=={2}|{3}", c, d, a, b);
            noResult = false;
        }
    }
}
