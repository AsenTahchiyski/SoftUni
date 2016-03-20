using System;
using System.Collections.Generic;

namespace p1.ReverseNumbersWithStack
{
    class Program
    {
        static void Main()
        {
            int[] numbers1 = new int[] { 1, 2, 3, 4, 5 };
            int[] numbers2 = new int[] { 1 };
            int[] numbers3 = new int[] { };
            int[] numbers4 = new int[] { 1, -2 };

            PrintAndReverseArray(numbers1);
            PrintAndReverseArray(numbers2);
            PrintAndReverseArray(numbers3);
            PrintAndReverseArray(numbers4);
        }

        static int[] ReverseNumbers(int[] arr)
        {
            var numberStack = new Stack<int>();
            foreach (var num in arr)
            {
                numberStack.Push(num);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = numberStack.Pop();
            }

            return arr;
        }

        static void PrintAndReverseArray(int[] arr)
        {
            Console.WriteLine("Before: " + string.Join(" ", arr));
            ReverseNumbers(arr);
            Console.WriteLine("After: " + string.Join(" ", arr));
            Console.WriteLine(new string('-', 20));
        }
    }
}
