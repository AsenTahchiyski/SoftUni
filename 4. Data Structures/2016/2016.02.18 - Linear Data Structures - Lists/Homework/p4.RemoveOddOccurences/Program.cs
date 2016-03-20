using System;
using System.Collections.Generic;
using System.Linq;

namespace p4.RemoveOddOccurences
{
    class Program
    {
        static void Main()
        {
            PrintOddOccurences("1 2 3 4 1");
            PrintOddOccurences("1 2 3 4 5 3 6 7 6 7 6");
            PrintOddOccurences("1 2 1 2 1 2");
            PrintOddOccurences("3 7 3 3 4 3 4 3 7");
            PrintOddOccurences("1 1");
        }

        static void PrintOddOccurences(string input)
        {
            var numbers = new List<int>(input.Split(' ').Select(int.Parse));
            for (int i = 0; i < numbers.Count; i++)
            {
                var equalNums = numbers.FindAll(e => e == numbers[i]);
                if(equalNums.Count % 2 == 0)
                {
                    Console.Write(numbers[i].ToString() + ' ');
                }
            }

            Console.WriteLine();
        }
    }
}
