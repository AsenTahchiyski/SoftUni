using System;
class BitsExchange
{
    static void Main()
    {
        Console.Write("Enter n = ");
        uint n = uint.Parse(Console.ReadLine());
        int[] bits345 = new int[3];
        int[] bits242526 = new int[3];
        for (int i = 0; i < 3; i++)
        {
            bits345[i] = (int)((n >> 3 + i) & 1);
            bits242526[i] = (int)((n >> 24 + i) & 1);
        }
        for (int i = 0; i < 3; i++)
        {
            string temp = Convert.ToString(n, 2);
            if (bits345[i] == 1)
            {
                n = n | (uint)(1 << (24 + i));
            }
            else
            {
                n = n & (uint)~(1 << (24 + i));
            }
            temp = Convert.ToString(n, 2);
            if (bits242526[i] == 1)
            {
                n = n | (uint)(1 << (3 + i));
            }
            else
            {
                n = n & (uint)~(1 << (3 + i));
            }
        }
        Console.WriteLine("Result: " + n);
    }
}
