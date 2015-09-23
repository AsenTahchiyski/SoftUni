using System;
class NullValuesArithmetic
{
    static void Main()
    {
        int? a = null;
        double? b = null;
        Console.WriteLine("Original \'null\' values:\na = {0}\nb = {1}", a, b);
        a += 10;
        b += 11;
        Console.WriteLine("Values + integer:\na = {0}\nb = {1}", a, b);
        a += null;
        b += null;
        Console.WriteLine("Values + \'null\':\na = {0}\nb = {1}", a, b);
    }
}
