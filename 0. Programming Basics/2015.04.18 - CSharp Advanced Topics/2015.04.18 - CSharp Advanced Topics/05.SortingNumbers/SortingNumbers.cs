using System;
using System.Collections.Generic;
class SortingNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        for (int i = 0; i < n; i++)
        {
            numbers.Add(int.Parse(Console.ReadLine()));
        }
        numbers.Sort();
        Console.Clear();
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
