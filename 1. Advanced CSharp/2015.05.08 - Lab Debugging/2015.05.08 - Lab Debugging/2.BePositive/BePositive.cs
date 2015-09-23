// removed namespace and empty lines
using System;
using System.Collections.Generic;
public class BePositiveMain
{
    public static void Main()
    {
        int countSequences = int.Parse(Console.ReadLine());
        for (int i = 0; i < countSequences; i++)
        {
            string[] input = Console.ReadLine().Trim().Split(' ');
            var numbers = new List<int>();
            for (int j = 0; j < input.Length; j++)
            {
                if (!string.IsNullOrWhiteSpace(input[j])) // condition edited to include whitespaces
                {
                    int num = int.Parse(input[j]); // changed index from i to j
                    numbers.Add(num);
                }
            }
            bool found = false;
            for (int j = 0; j < numbers.Count; j++)
            {
                int currentNum = numbers[j];
                if (currentNum >= 0) // add = 0 possibility
                {
                    if (found)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(currentNum);
                    found = true;
                }
                else
                {
                    currentNum += numbers[j + 1];
                    if (currentNum >= 0) // add = 0 possibility
                    {
                        if (found)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(currentNum);
                        found = true;
                    }
                    j++; // index increased so we skip the number when we add next number to the negative one
                }
            }
            if (!found)
            {
                Console.WriteLine("(empty)");
            }
            Console.WriteLine(); // added cw
        }
    }
}
