using System;
class SortArrayOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter numbers to be sorted, separated by space:");
        string[] input = Console.ReadLine().Split(' ');
        int[] numbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }
        Array.Sort(numbers);
        Console.WriteLine("Sorted numbers: " + string.Join(" ", numbers));
    }
}
