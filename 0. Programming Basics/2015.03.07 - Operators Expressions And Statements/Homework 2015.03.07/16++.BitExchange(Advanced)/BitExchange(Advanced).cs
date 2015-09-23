using System;
class BitExchange_Advanced
{
    static void Main()
    {
        Console.Write("Enter n = ");
        long n = long.Parse(Console.ReadLine());
        Console.Write("Enter p = ");
        int p = int.Parse(Console.ReadLine());
        Console.Write("Enter q = ");
        int q = int.Parse(Console.ReadLine());
        Console.Write("Enter k = ");
        int k = int.Parse(Console.ReadLine());
        if (n >= uint.MaxValue)
        {
            Console.WriteLine("out of range");
            return;
        }
        if (p < 0 || q < 0 || p + k > 32 || q + k > 32)
        {
            Console.WriteLine("out of range");
            return;
        }
        if ((q > p && p + k > q) || (p > q && q + k > p))
        {
            Console.WriteLine("overlapping");
            return;
        }
        int[] bits345 = new int[k];
        int[] bits242526 = new int[k];
        for (int i = 0; i < k; i++)
        {
            bits345[i] = (int)((n >> p + i) & 1);
            bits242526[i] = (int)((n >> q + i) & 1);
        }
        for (int i = 0; i < k; i++)
        {
            string temp = Convert.ToString(n, 2);
            if (bits345[i] == 1)
            {
                n = n | (uint)(1 << (q + i));
            }
            else
            {
                n = n & (uint)~(1 << (q + i));
            }
            temp = Convert.ToString(n, 2);
            if (bits242526[i] == 1)
            {
                n = n | (uint)(1 << (p + i));
            }
            else
            {
                n = n & (uint)~(1 << (p + i));
            }
        }
        Console.WriteLine("Result: " + n);
    }
}
