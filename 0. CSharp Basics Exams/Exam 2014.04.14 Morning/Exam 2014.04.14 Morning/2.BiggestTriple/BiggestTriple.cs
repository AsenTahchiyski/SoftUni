using System;
class BiggestTriple
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int biggestSum = int.MinValue, index = 0, counter = 0, currentSum = 0;
        for (int i = 0; i < input.Length; i++)
        {
            currentSum += int.Parse(input[i]);
            counter++;
            if (counter == 3 || i == input.Length - 1)
            {
                if (biggestSum < currentSum)
                {
                    biggestSum = currentSum;
                    index = i + 1 - counter;
                }
                if (i != input.Length - 1)
                {
                    counter = 0;
                }
                currentSum = 0;
            }
        }
        int indexEnd = index + 3 < input.Length ? index + 3 : input.Length;
        for (int i = index; i < indexEnd; i++)
        {
            Console.Write(input[i] + " ");
        }
        Console.WriteLine();
    }
}
