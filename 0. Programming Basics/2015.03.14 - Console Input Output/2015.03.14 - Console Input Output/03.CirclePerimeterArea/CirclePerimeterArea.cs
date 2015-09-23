using System;
class CirclePerimeterArea
{
    static void Main()
    {
        Console.Write("Enter circle radius r = ");
        double r = double.Parse(Console.ReadLine());
        Console.WriteLine("Perimeter = {0:F2}", 2 * Math.PI * r);
        Console.WriteLine("Area = {0:F2}", Math.PI * r * r);
    }
}
