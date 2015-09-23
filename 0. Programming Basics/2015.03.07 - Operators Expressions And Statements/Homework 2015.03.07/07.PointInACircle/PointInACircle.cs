using System;
class PointInACircle
{
    static void Main()
    {
        Console.Write("Enter x = ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter y = ");
        double y = double.Parse(Console.ReadLine());
        Console.WriteLine("Point is in the circle: {0}", x * x + y * y > 4 ? false : true);
    }
}
