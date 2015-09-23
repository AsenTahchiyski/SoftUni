using System;
class BitFlipper
{
    static void Main()
    {
        ulong number = ulong.Parse(Console.ReadLine());
        ulong output = number;
        int equalBits = 1;
        for (int i = 62; i >= 0; i--)
        {
            if (((number >> i) & 1) == ((number >> i + 1) & 1))
            {
                equalBits++;
            }
            else
            {
                equalBits = 1;
            }
            if (equalBits == 3)
            {
                if (((number >> i) & 1) == 0)
                {
                    ulong mask = (ulong)1 << i;
                    output = output | mask;
                    output = output | (mask << 1);
                    output = output | (mask << 2);
                }
                else
                {
                    output = output & ~((ulong)1 << i);
                    output = output & ~((ulong)1 << i + 1);
                    output = output & ~((ulong)1 << i + 2);
                }
                if (((number >> i) & 1) == ((number >> i - 1) & 1))
                {
                    equalBits = 0;
                }
                else
                {
                    equalBits = 1;
                }
            }
        }
        Console.WriteLine(output);
    }
}
