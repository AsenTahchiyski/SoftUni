using System;
using System.Linq;

namespace p5.CountOfOccurences
{
    class Program
    {
        static void Main(string[] args)
        {
            // would be done easiest using a dictionary, but since this is linear data structures lecture for lists, dictionary use should be avoided
            PrintOccurenseCount("3 4 4 2 3 3 4 3 2");
            PrintOccurenseCount("1000");
            PrintOccurenseCount("0 0 0");
            PrintOccurenseCount("7 6 5 5 6");
        }

        static void PrintOccurenseCount(string input)
        {
            var numbers = input.Split(' ').Select(int.Parse).ToArray();
            var unique = numbers.Distinct().ToArray();
            var occurences = new int[unique.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNum = numbers[i];
                var indexUniqueOccurences = ArrayFirstIndexOf(currentNum, unique);
                occurences[indexUniqueOccurences]++;
            }

            // output is not sorted as per example output, since sorting is not explicitly required and modifying the data source is not a good practice, otherwise another way to solve this is to sort the array and then print the occurences
            for (int i = 0; i < unique.Length; i++)
            {
                Console.WriteLine("{0} -> {1} times", unique[i], occurences[i]);
            }

            Console.WriteLine();
        }

        static int ArrayFirstIndexOf(int number, int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i] == number)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
