using System;
class PointInCircleAndOutOfRectangle
{
    static void Main()
    {
        Console.Write("Enter x = ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter y = ");
        double y = double.Parse(Console.ReadLine());
        bool inCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= 1.5 * 1.5;
        bool outRect = y > 1 || y < -1 || x < -1 || x > 5;
        Console.WriteLine("In K and out of R: {0}", inCircle && outRect ? "yes" : "no");
    }
}
