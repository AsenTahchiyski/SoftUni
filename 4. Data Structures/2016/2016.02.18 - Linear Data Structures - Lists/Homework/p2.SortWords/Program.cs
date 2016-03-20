using System;
using System.Collections.Generic;

namespace p2.SortWords
{
    public class Program
    {
        static void Main()
        {
            PrintWordsSorted("wow softuni alpha");
            PrintWordsSorted("hi");
            PrintWordsSorted("rakiya beer wine vodka whiskey");
        }

        static void PrintWordsSorted(string input)
        {
            var words = new List<string>(input.Split(' '));
            words.Sort();
            Console.WriteLine(string.Join(" ", words));
        }
    }
}
