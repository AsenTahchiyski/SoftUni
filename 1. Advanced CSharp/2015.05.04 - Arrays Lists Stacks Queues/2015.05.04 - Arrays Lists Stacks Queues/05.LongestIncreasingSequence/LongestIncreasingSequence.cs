using System;
class LongestIncreasingSequence
{
    static void Main()
    {
        Console.WriteLine("Enter a sequence of integers separated by a space:");
        string[] input = Console.ReadLine().Split(' ');
        int[] numbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }
        int indexLast = 0, longest = 1, currentLength = 1;
        Console.WriteLine("Increasing sequences:");
        Console.Write(numbers[0] + " ");
        for (int i = 1; i < input.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                Console.Write(numbers[i] + " ");
                currentLength++;
                if (currentLength > longest)
                {
                    longest = currentLength;
                    indexLast = i;
                }
            }
            else
            {
                currentLength = 1;
                Console.WriteLine();
                Console.Write(numbers[i] + " ");
            }
        }
        Console.WriteLine();
        Console.Write("Longest: ");
        for (int i = longest - 1; i >= 0; i--)
        {
            Console.Write(numbers[indexLast - i] + " ");
        }
        Console.WriteLine();
    }
}
