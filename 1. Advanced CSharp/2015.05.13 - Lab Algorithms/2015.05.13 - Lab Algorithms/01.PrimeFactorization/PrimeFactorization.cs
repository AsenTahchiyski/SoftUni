using System;
using System.Collections.Generic;
class PrimeFactorization
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int saveN = n;
        List<int> list = new List<int>();
        int div = 2;
        while (n != 1)
        {
            if (n % div == 0)
            {
                list.Add(div);
                n /= div;
            }
            else div++;
        }
        Console.WriteLine("{0} = {1}", saveN, string.Join(" * ", list));
    }
}
