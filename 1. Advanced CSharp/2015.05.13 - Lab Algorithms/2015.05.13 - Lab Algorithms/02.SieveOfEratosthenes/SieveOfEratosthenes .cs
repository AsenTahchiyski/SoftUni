using System;
using System.Linq;
using System.Collections.Generic;
class SieveOfEratosthenes 
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> list = new List<int>(Enumerable.Range(0, n + 1));
        list[1] = 0;
        int p = 2;
        for (int i = 2; i < list.Count; i++)
        {
            for (int j = i + i; j < list.Count; j += i)
            {
                list[j] = 0;
            }
        }
        Console.Write(2);
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != 0 && list[i] != 2)
            {
                Console.Write(", {0}", list[i]);
            }
        }
        Console.WriteLine();
    }
}
