using System;
class CurrencyCheck
{
    static void Main()
    {
        uint rubles = uint.Parse(Console.ReadLine());
        uint dollars = uint.Parse(Console.ReadLine());
        uint euro = uint.Parse(Console.ReadLine());
        uint leva1 = uint.Parse(Console.ReadLine());
        uint leva2 = uint.Parse(Console.ReadLine());
        double lowestPrice = double.MaxValue;
        if (rubles * 3.5 / 100.0 < lowestPrice)
        {
            lowestPrice = rubles * 3.5 / 100.0;
        }
        if (dollars * 1.5 < lowestPrice)
        {
            lowestPrice = dollars * 1.5;
        }
        if (euro * 1.95 < lowestPrice)
        {
            lowestPrice = euro * 1.95;
        }
        if (leva1 / 2.0 < lowestPrice)
        {
            lowestPrice = leva1 / 2.0;
        }
        if (leva2 < lowestPrice)
        {
            lowestPrice = leva2;
        }
        Console.WriteLine("{0:F2}", lowestPrice);
    }
}
