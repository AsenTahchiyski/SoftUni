using System;
class BitSifting
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        int sieves = int.Parse(Console.ReadLine());
        for (int i = 0; i < sieves; i++)
        {
            long sieve = long.Parse(Console.ReadLine());
            number = number & ~sieve;
        }
        string outString = Convert.ToString(number, 2);
        int counter = 0;
        foreach (char item in outString)
        {
            if (item == '1')
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}
