using System;
class ModifyBitAtPosition
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter p = ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter v = ");
        int v = int.Parse(Console.ReadLine());
        // one way to solve
        if (v == 0)
        {
            n = n & ~(1 << p);
        }
        else
        {
            n = n | 1 << p;
        }
        Console.WriteLine("Result = " + n);
        // another way to solve
        Console.WriteLine("Result = {0}", v == 0 ? n & ~(1 << p) : n | 1 << p);
    }
}
