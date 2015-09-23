using System;
class BitwiseExtractBit3
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Bit 3 = {0}", n >> 3 & 1);
    }
}
