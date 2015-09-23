using System;
using System.Collections.Generic;
class ArrayMatcher
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split('\\');
        string first = input[0];
        string second = input[1];
        string command = input[2];
        List<char> output = new List<char>();
        if (command == "join")
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (second.Contains(first[i].ToString()))
                {
                    output.Add(first[i]);
                }
            }
        }
        else if (command == "right exclude")
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (!second.Contains(first[i].ToString()))
                {
                    output.Add(first[i]);
                }
            }
        }
        else if (command == "left exclude")
        {
            for (int i = 0; i < second.Length; i++)
            {
                if (!first.Contains(second[i].ToString()))
                {
                    output.Add(second[i]);
                }
            }
        }
        output.Sort();
        foreach (char item in output)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}
