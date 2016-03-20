using System;
using System.Collections.Generic;
using System.Linq;

namespace SumAndAverage
{
    class Program
    {
        static void Main()
        {
            try
            {
                List<int> numbers = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse));
                Console.WriteLine("Average: " + numbers.Average());
                Console.WriteLine("Sum: " + numbers.Sum());
            }
            catch (FormatException)
            {
                Console.WriteLine("Average: 0\nSum: 0");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Average: 0\nSum: 0");
            }
        }
    }
}
