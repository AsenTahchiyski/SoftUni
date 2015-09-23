using System;
class NumberComparer
{
    static void Main()
    {
        Console.Write("Enter a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b = ");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Greater number = {0}", a > b ? a : b);
    }
}
