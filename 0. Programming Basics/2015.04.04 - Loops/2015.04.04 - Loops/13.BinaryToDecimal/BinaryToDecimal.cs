using System;
class BinaryToDecimal
{
    static void Main()
    {
        Start:
        Console.Write("Enter binary number: ");
        string binary = Console.ReadLine();
        long result = 0;
        for (int i = 0; i < binary.Length; i++)
        {
            if (binary[i] == '1')
            {
                result += (long)Math.Pow(2, binary.Length - i - 1);
            }
        }
        Console.WriteLine("Decimal = " + result);
        goto Start;
    }
}
