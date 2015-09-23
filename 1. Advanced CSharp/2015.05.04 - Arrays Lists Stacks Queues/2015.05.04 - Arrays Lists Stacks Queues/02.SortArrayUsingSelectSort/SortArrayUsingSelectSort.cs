using System;
class SortArrayUsingSelectSort
{
    static void Main()
    {
        Console.WriteLine("Enter numbers to be sorted, separated by a space:");
        string[] input = Console.ReadLine().Split(' ');
        int[] numbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = i; j < input.Length; j++)
            {
                if (numbers[j] < numbers[i])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
        Console.WriteLine("Sorted numbers: " + string.Join(" ", numbers));
    }
}
