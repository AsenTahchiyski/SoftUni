using System;
using System.Collections.Generic;
using System.Linq;
class JoinLists
{
    static void Main()
    {
        string[] first = Console.ReadLine().Split(' ');
        string[] second = Console.ReadLine().Split(' ');
        List<int> allNumbers = new List<int>();
        foreach (var number in first)
        {
            allNumbers.Add(Convert.ToInt32(number));
        }
        foreach (var number in second)
        {
            allNumbers.Add(Convert.ToInt32(number));
        }
        List<int> output = allNumbers.Distinct().ToList();
        output.Sort();
        foreach (int number in output)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
