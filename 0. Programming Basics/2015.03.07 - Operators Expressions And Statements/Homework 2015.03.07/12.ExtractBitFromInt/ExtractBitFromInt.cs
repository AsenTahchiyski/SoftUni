using System;
class ExtractBitFromInt
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter p = ");
        int p = int.Parse(Console.ReadLine());
        Console.WriteLine("Bit @ p = {0}", n >> p & 1);
    }
}
