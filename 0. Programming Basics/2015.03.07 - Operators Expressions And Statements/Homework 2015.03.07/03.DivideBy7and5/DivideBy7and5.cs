using System;
class DivideBy7and5
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Divisible by 7 and 5: {0}", n % 5 == 0 && n % 7 == 0 && n != 0 ? true : false);
    }
}
