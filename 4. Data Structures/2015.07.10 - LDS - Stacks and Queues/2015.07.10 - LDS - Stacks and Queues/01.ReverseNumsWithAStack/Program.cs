namespace _01.ReverseNumsWithAStack
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Console.Write("How many numbers? ");
            int countOfNumbers = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.Write("Number {0}: ", i + 1);
                int number = int.Parse(Console.ReadLine());
                numbers.Push(number);
            }

            Console.WriteLine(new string('-', 30));
            for (int i = 0; i < countOfNumbers; i++)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
