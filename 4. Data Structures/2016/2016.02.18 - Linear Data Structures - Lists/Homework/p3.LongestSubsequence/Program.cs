using System;
using System.Collections.Generic;
using System.Linq;

namespace p3.LongestSubsequence
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(string.Join(" ", FindLongestSubsequence("12 2 7 4 3 3 8")));
            Console.WriteLine(string.Join(" ", FindLongestSubsequence("2 2 2 3 3 3")));
            Console.WriteLine(string.Join(" ", FindLongestSubsequence("4 4 5 5 5")));
            Console.WriteLine(string.Join(" ", FindLongestSubsequence("1 2 3")));
            Console.WriteLine(string.Join(" ", FindLongestSubsequence("0")));
        }

        static List<int> FindLongestSubsequence(string input)
        {
            var numbers = new List<int>(input.Split(' ').Select(int.Parse));
            var temp = new List<int>();
            var result = new List<int>();
            temp.Add(numbers[0]);
            result.Add(numbers[0]);
            for (int i = 1; i < numbers.Count; i++)
            {
                if(numbers[i - 1] == numbers[i])
                {
                    temp.Add(numbers[i]);
                }
                else
                {
                    if(temp.Count > result.Count)
                    {
                        result = new List<int>(temp);
                    }

                    temp.Clear();
                    temp.Add(numbers[i]);
                }
            }

            // in case the last element is part of the subsequence
            if (temp.Count > result.Count)
            {
                result = new List<int>(temp);
            }

            return result;
        }
    }
}
