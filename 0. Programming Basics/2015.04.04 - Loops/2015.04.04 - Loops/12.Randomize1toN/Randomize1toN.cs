using System;
using System.Collections.Generic;
class Randomize1toN
{
    static Random number = new Random();
    static int remaining = 0;
    static void Main()
    {
        Start:
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        // create list with all numbers
        List<int> numbers = new List<int>();
        for (int i = 0; i < n; i++)
        {
            numbers.Add(i + 1);
        }
        // print random list elements
        remaining = n;
        for (int i = 0; i < n; i++)
        {
            int index = Random(number);
            Console.Write("{0} ", numbers[index]);
            // remove element from list
            numbers.RemoveAt(index);
            remaining--;
        }
        Console.WriteLine();
        goto Start;
    }
    // get random number
    static int Random(Random number)
    {
        return number.Next(0, remaining);
    }
}
