using System;
using System.Collections.Generic;
using System.Linq;
class CountOfNames
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        Dictionary<string, int> dict = new Dictionary<string, int>();
        List<string> names = new List<string>();
        foreach (string name in input)
        {
            if (dict.ContainsKey(name))
            {
                dict[name]++;
            }
            else
            {
                dict.Add(name, 1);
                names.Add(name);
            }
        }
        names.Sort();
        foreach (string name in names)
        {
            Console.WriteLine("{0} -> {1}", name, dict[name]);
        }
    }
}
