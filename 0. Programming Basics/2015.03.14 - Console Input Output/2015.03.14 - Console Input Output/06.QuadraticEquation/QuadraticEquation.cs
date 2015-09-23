using System;
class QuadraticEquation
{
    static void Main()
    {
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
        double x1 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
        double x2 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
        if (Double.IsNaN(x1) && Double.IsNaN(x2))
        {
            Console.WriteLine("No real roots");
        }
        else if (x1 == x2)
        {
            Console.WriteLine("x1 = x2 = " + x1);
        }
        else
        {
            Console.WriteLine("x1 = {0}; x2 = {1}", x1, x2);
        }
    }
}
