using System;
using System.Collections.Generic;
class InsertionSort
{
    static void Main()
    {
        List<int> numbers = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse));
        int temp;
        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] < numbers[i - 1])
            {
                temp = numbers[i];
                numbers.RemoveAt(i);
                int newIndex = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (temp < numbers[j])
                    {
                        newIndex = j;
                    }
                }
                numbers.Insert(newIndex, temp);
            }
        }
        Console.WriteLine(string.Join(" ", numbers));
    }
}
