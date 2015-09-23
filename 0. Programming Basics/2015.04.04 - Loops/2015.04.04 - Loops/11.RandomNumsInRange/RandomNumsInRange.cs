using System;
class RandomNumsInRange
{
    static int min, max;
    static Random randomNumber = new Random();
    static void Main()
    {
        // input
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("min = ");
        min = int.Parse(Console.ReadLine());
        do
        {
            Console.Write("max = ");
            max = int.Parse(Console.ReadLine());    
        } while (max <= min);
        // random generator
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0} ", generateRandom(randomNumber));
        }
        Console.WriteLine();
    }
    static int generateRandom(Random randomNumber)
    {
        return randomNumber.Next(min, max + 1);
    }
}

