using System;
class SumOf3Numbers
{
    static void Main()
    {
        Console.WriteLine("Enter 3 numbers:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Their sum is = " + (a + b + c));
    }
}
