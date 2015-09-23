namespace FractionCalculator
{
    using System;

    class Program
    {
        static void Main()
        {
            Fraction fraction1 = new Fraction(9223372036854775807, 1);
            Fraction fraction2 = new Fraction(9223372036854775807, 1);
            Fraction result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);
        }
    }
}
