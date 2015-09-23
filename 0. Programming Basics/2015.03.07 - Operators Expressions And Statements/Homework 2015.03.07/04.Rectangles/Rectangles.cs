using System;
class Rectangles
{
    static void Main()
    {
        Console.Write("Enter rectangle width = ");
        double width = double.Parse(Console.ReadLine());
        Console.Write("Enter rectangle height = ");
        double height = double.Parse(Console.ReadLine());
        Console.WriteLine("Perimeter = {0}", 2 * width + 2 * height);
        Console.WriteLine("Area = {0}", width * height);
    }
}
