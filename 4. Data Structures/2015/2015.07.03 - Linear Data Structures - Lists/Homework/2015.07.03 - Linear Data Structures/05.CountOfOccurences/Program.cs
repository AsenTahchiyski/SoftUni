using System;
using System.Collections.Generic;

namespace CountOfOccurences
{
    class Program
    {
        static void Main()
        {
            string[] numbers = Console.ReadLine().Split(' ');
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
            foreach (var number in numbers)
            {
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 1);
                }
                else
                {
                    dict[number]++;
                }
            }
            foreach (var pair in dict)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}
