using System;
using System.Collections.Generic;
using System.Linq;

namespace p1.SumAndAvg
{
    public class Program
    {
        static void Main()
        {
            PrintDetails("4 5 6");
            PrintDetails("1 1");
            PrintDetails("");
            PrintDetails("10");
            PrintDetails("2 2 1");
        }

        static void PrintDetails(string nums)
        {
            if(nums.Length == 0)
            {
                Console.WriteLine("Sum = 0; Average = 0");
                return;
            }

            var numbers = new List<int>(nums.Split(' ').Select(int.Parse));
            Console.Write("Sum = " + numbers.Sum() + "; ");
            Console.WriteLine("Average = " + numbers.Average());
        }
    }
}
