using System;
using System.Linq;
class LargerThanNeighbours
{
    static void Main()
    {
        Console.WriteLine("Enter numbers separated by a space: ");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i] + " is bigger than its neighbours: " + IsLargerThanNeighbours(i, numbers));
        }
    }
    static bool IsLargerThanNeighbours(int index, int[] numbers)
    {
        if (index == 0) return numbers[index] > numbers[index + 1];
        if (index == numbers.Length - 1) return numbers[index] > numbers[index - 1];
        else return ((numbers[index] > numbers[index + 1]) && (numbers[index] > numbers[index - 1]));
    }
}
