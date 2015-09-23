using System;
using System.Linq;
class ReverseNumber
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        double number = double.Parse(Console.ReadLine());
        Console.WriteLine("Reversed: {0}", GetReversedNumber(number).ToString());
    }
    static double GetReversedNumber(double number)
    {
        string reversedStr = new string(number.ToString().Reverse().ToArray());
        double reversedDouble;
        if (double.TryParse(reversedStr, out reversedDouble))
        {
            return reversedDouble;
        }
        else
        {
            return -1;
        }
    }
}
