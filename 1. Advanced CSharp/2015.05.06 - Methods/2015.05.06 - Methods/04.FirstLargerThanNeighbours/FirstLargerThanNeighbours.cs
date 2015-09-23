using System;
using System.Linq;
class FirstLargerThanNeighbours
{
    static void Main()
    {
        Console.WriteLine("Enter numbers separated by a space: ");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (IndexFirstLargerThanNeighbours(i, numbers) != -1)
            {
                Console.WriteLine(IndexFirstLargerThanNeighbours(i, numbers) + " is the index of the first number bigger than its neighbours.");
                return;
            }
        }
        Console.WriteLine("-1");
    }
    static int IndexFirstLargerThanNeighbours(int index, int[] numbers)
    {
        if (index == 0)
        {
            if (numbers[index] > numbers[index + 1])
            {
                return index;
            }
        }
        else if (index == numbers.Length - 1)
        {
            if (numbers[index] > numbers[index - 1])
            {
                return index;
            }
        }
        else
        {
            if ((numbers[index] > numbers[index + 1]) && (numbers[index] > numbers[index - 1]))
            {
                return index;
            }
        }
        return -1;
    }
}
