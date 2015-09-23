using System;
class BitShooter
{
    static void Main()
    {
        ulong num = ulong.Parse(Console.ReadLine());
        for (int shot = 0; shot < 3; shot++)
        {
            string[] param = Console.ReadLine().Split(' ');
            int center = int.Parse(param[0]);
            int size = int.Parse(param[1]);
            int startBit, endBit;
            if (center - (size - 1) / 2 < 0)
            {
                startBit = 0;
            }
            else
            {
                startBit = center - (size - 1) / 2; 
            }
            if (center + (size - 1) / 2 > 63)
            {
                endBit = 63;
            }
            else
            {
                endBit = center + (size - 1) / 2;
            }
            for (int i = startBit; i <= endBit; i++)
            {
                num = num & ~((ulong)1 << i);
            }
        }
        int left1s = 0, right1s = 0;
        for (int i = 0; i <= 31; i++)
        {
            if (((num >> i) & 1) == 1)
            {
                right1s++;
            }
        }
        for (int i = 32; i <= 63; i++)
        {
            if (((num >> i) & 1) == 1)
            {
                left1s++;
            }
        }
        Console.WriteLine("left: " + left1s);
        Console.WriteLine("right: " + right1s);
    }
}
