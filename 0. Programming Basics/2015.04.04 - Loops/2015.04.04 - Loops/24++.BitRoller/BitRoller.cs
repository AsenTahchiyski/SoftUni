using System;
class BitRoller
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        int freeze = int.Parse(Console.ReadLine());
        uint roll = uint.Parse(Console.ReadLine());
        for (int i = 0; i < roll; i++)
        {
            // get bits'values
            uint firstBit = n & 1;
            uint freezeBit = n >> freeze & 1;
            uint freezeBitLeft;
            if (freeze == 18)
            {
                freezeBitLeft = firstBit;
            }
            else
            {
                freezeBitLeft = (n >> freeze + 1) & 1;
            }
            n >>= 1;
            // set last bit
            if (freeze != 0)
            {
                if (firstBit == 0)
                {
                    n = (uint)(n & ~(1 << 18));
                }
                else
                {
                    n = n | 1 << 18;
                }
            }
            else
            {
                if (freezeBitLeft == 0)
                {
                    n = (uint)(n & ~(1 << 18));
                }
                else
                {
                    n = n | 1 << 18;
                }
            }
            // set freeze bit
            if (freezeBit == 0)
            {
                n = n & (uint)~(1 << freeze);
            }
            else
            {
                n = n | (uint)(1 << freeze);
            }
            // set bit on the left of the frozen bit (previously on the right)
            if (freezeBitLeft == 0)
            {
                n = n & (uint)~(1 << (freeze - 1));
            }
            else
            {
                n = n | (uint)(1 << (freeze - 1));
            }
        }
        Console.WriteLine(n);
    }
}
