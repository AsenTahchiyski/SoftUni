using System;
using System.Collections.Generic;

namespace LongestSubsequence
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int> { 12, 2, 7, 4, 3, 3, 8 };
            //List<int> numbers = new List<int> { 2, 2, 2, 3, 3, 3 };
            //List<int> numbers = new List<int> { 4, 4, 5, 5, 5 };
            //List<int> numbers = new List<int> { 1, 2, 3 };
            //List<int> numbers = new List<int> { 0 };

            Console.WriteLine(string.Join(" ", LongestSubsequenceEqualNumbers(numbers)));
        }

        static List<int> LongestSubsequenceEqualNumbers(List<int> numbers)
        {
            int maxSubsequence = 1;
            int maxIndex = 0;
            int counter = 1;
            int index;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                    index = i + 1;
                    if (counter > maxSubsequence)
                    {
                        maxSubsequence = counter;
                        maxIndex = index;
                    }
                }
                else
                {
                    counter = 1;
                }
            }
            List<int> output = new List<int>();
            for (int i = maxIndex; i > maxIndex - maxSubsequence; i--)
            {
                output.Add(numbers[i]);
            }
            return output;
        }
    }
}
