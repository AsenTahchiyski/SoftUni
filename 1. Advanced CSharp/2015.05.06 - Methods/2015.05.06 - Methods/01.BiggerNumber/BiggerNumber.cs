using System;
class BiggerNumber
{
    static void Main()
    {
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Bigger number = " + GetMax(a, b));
    }
    static int GetMax(int a, int b)
    {
        if (a >= b) return a;
        else return b;
    }
}
