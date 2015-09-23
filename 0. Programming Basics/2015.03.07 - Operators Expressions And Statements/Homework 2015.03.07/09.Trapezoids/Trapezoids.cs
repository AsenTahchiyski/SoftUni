using System;
class Trapezoids
{
    static void Main()
    {
        Console.Write("Enter a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter h = ");
        double h = double.Parse(Console.ReadLine());
        Console.WriteLine("Area of trapezoid = {0}", ((a + b) * h) / 2);
    }
}
