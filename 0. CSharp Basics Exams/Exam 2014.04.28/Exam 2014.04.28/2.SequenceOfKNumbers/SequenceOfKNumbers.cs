using System;
class SequenceOfKNumbers
{
    static void Main()
    {
        string input = "3 3 3 8 8 2 5 1 7 7 7 4 4 4 4 3 4 4";
        string[] numbers = input.Split(' '); //Console.ReadLine().Split(' ');
        int k = 2; // int.Parse(Console.ReadLine());
        int counter = 0;
        if (numbers[0] != numbers[1])
        {
            Console.Write(numbers[0] + ' ');
        }
        else
        {
            counter++;
        }
        for (int i = 1; i < numbers.Length - 1; i++)
        {
            if (numbers[i] != numbers[i - 1])
            {
                Console.Write(numbers[i] + ' ');
                counter = 0;
            }
            else if (numbers[i] == numbers[i - 1])
            {
                if (counter < k)
                {
                    if (numbers[i] != numbers[i + 1])
                    {
                        Console.Write(numbers[i] + ' ');
                    }
                    else if (numbers[i] == numbers[i + 1])
                    {
                        counter++;
                    }
                }
            }
        }
        Console.WriteLine();
    }
}
