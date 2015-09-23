using System;
class ComparingFloats
{
    static void Main()
    {
        Console.Write("Enter a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b = ");
        double b = double.Parse(Console.ReadLine());
        double eps = 0.000001;
        if (Math.Abs(a - b) >= eps)
        {
            Console.WriteLine("Equal (with precision {0:F6}): false", eps);
        }
        else
        {
            Console.WriteLine("Equal (with precision {0:F6}): true", eps);
        }
    }
}
