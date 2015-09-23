using System;
using System.Text;
class DecimalToBinary
{
    static void Main()
    {
        Start:
        Console.Write("Enter decimal number: ");
        long num = long.Parse(Console.ReadLine());
        StringBuilder binary = new StringBuilder();
        do
        {
            if (num % 2 == 0)
            {
                binary.Append("0");
                num >>= 1;
            }
            else
            {
                binary.Append("1");
                num >>= 1;
            }
        } while (num > 0);
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            Console.Write(binary[i]);
        }
        Console.WriteLine();
        goto Start;
    }
}
