using System;
class CheckBitAtPosition
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter p = ");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("Bit @ p == 1: {0}", (n >> p & 1) == 1);
    }
}
