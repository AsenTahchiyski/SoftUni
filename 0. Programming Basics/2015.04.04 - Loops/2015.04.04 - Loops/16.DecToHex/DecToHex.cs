// http://www.sanfoundry.com/csharp-program-decimal-hexadecimal-conversion/
using System;
class DecToHex
{
    static void Main()
    {
        long deciNum, remainder, temp = 0;
        int i = 1;
        Console.Write("Enter a Decimal Number: ");
        deciNum = long.Parse(Console.ReadLine());
        char[] hexNumber = new char[deciNum.ToString().Length + 1];
        remainder = deciNum;
        while (remainder != 0)
        {
            temp = remainder % 16;
            if (temp < 10)
                temp = temp + 48;
            else
                temp = temp + 55;
            hexNumber[i++] = Convert.ToChar(temp);
            remainder = remainder / 16;
        }
        Console.Write("HexaDecimal Number: ");
        for (int j = i - 1; j > 0; j--)
            Console.Write(hexNumber[j]);
        Console.WriteLine();
    }
}
