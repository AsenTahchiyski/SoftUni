// unfinished

using System;
using System.Collections.Generic;
class LongestNonDecrSequence
{
    static int[] numbers;
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }
        Console.WriteLine(nonDecreasing(numbers, 0));
    }
    static List<int> nonDecreasing(int[] numbers, int index)
     {
        List<int> queue = new List<int>();
        if (numbers.Length == 0)
        {
            return queue;
        }
        queue.Add(numbers[index]);
        if (numbers[index] > numbers[index + 1])
        {
            queue.Add(numbers[index + 1]);
        }
        return nonDecreasing(numbers, index - 1);
    }
}
