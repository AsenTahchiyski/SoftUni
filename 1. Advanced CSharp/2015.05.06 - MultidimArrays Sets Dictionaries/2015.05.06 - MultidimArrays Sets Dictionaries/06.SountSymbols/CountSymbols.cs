using System;
using System.Linq;
using System.Collections.Generic;
class CountSymbols
{
    static void Main()
    {
        char[] chars = Console.ReadLine().ToCharArray();
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (char item in chars)
        {
            if (dict.ContainsKey(item)) dict[item]++;
            else dict.Add(item, 1);
        }
        List<char> charList = dict.Keys.ToList();
        charList.Sort();
        foreach (char item in charList)
        {
            Console.WriteLine(item + ": " + dict[item] + " time/s");
        }
    }
}
