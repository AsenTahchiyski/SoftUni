using System;
class PrintASCIITable
{
    static void Main()
    {
        char c = '\u0000';
        for (int i = 0; i < 256; i++)
        {
            Console.WriteLine("Dec: {0}; Symbol: {1}", Convert.ToString((int)c).PadLeft(3, '0'), c);
            c++;
        }
    }
}
