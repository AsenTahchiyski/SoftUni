using System;
using System.Collections.Generic;
class RemoveNames
{
    static void Main()
    {
        string[] names = Console.ReadLine().Split(' ');
        List<string> firstList = new List<string>();
        foreach (string name in names)
        {
            firstList.Add(name);
        }
        string[] removeNames = Console.ReadLine().Split(' ');
        List<string> secondList = new List<string>();
        foreach (string name in removeNames)
        {
            secondList.Add(name);
        }
        foreach (string name in secondList)
        {
            firstList.RemoveAll(item => item == name);
        }
        foreach (var name in firstList)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }
}
