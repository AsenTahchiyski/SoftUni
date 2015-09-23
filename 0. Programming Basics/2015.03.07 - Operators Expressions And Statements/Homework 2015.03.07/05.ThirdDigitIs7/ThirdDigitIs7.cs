using System;
class ThirdDigitIs7
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Thisr digit is 7: {0}", ((n / 100) - 7) % 10 == 0 ? true: false);
    }
}
