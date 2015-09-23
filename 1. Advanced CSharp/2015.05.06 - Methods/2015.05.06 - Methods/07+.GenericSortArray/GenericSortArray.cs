using System;
using System.Collections.Generic;
class GenericSortArray
{
    static void Main()
    {
        int[] numbers = { 1, 3, 4, 5, 1, 0, 5 };
        string[] strings = { "zaz", "cba", "baa", "azis" };
        DateTime[] dates = { new DateTime(2002, 3, 1), new DateTime(2015, 5, 6), new DateTime(2014, 1, 1) };

        numbers = SortArray(numbers);
        Console.WriteLine(string.Join(", ", numbers));
        strings = SortArray(strings);
        Console.WriteLine(string.Join(", ", strings));
        dates = SortArray(dates);
        Console.WriteLine(string.Join(", ", dates));
    }
    static T[] SortArray<T>(T[] original) where T : IComparable
    {
        for (int i = 0; i < original.Length; i++)
        {
            for (int j = i; j < original.Length; j++)
            {
                if (original[j].CompareTo(original[i]) < 0)
                {
                    var temp = original[i];
                    original[i] = original[j];
                    original[j] = temp;
                }
            }
        }
        return original;
    }
}
