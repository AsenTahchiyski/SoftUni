using System;
class OddOrEvenIntegers
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("n is odd: {0}", n % 2 != 0);
    }
}
