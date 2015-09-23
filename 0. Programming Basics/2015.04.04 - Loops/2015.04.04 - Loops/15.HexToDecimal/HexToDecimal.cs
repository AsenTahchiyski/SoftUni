using System;
class HexToDecimal
{
    static void Main()
    {
        Start:
        Console.Write("Enter HEX number: ");
        string num = Console.ReadLine();
        long output = 0;
        int counter = 0;
        for (int i = num.Length - 1; i >= 0 ; i--)
        {
            long temp = char.IsDigit(num[i]) ? (long)char.GetNumericValue(num[i]) : getValue(num[i]);
            output += (long)Math.Pow(16, counter) * temp;
            counter++;
        }
        Console.WriteLine("Decimal: " + output);
        goto Start;
    }
    static int getValue(char symbol)
    {
        switch (symbol)
        {
            case 'A': return 10;
            case 'B': return 11;
            case 'C': return 12;
            case 'D': return 13;
            case 'E': return 14;
            case 'F': return 15;
            default: return 0;
        }
    }
}
