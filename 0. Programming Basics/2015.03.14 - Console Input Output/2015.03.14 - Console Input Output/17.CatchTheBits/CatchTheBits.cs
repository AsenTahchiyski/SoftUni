// 81/100 in Judge
using System;
class CatchTheBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int counter = 0;
        int index = 1;
        int result = 0;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (index < 8)
            {
                do
                {
                    int bitToAdd = (number >> (7 - index)) & 1;
                    result = result | (bitToAdd << 7 - counter);
                    counter++;
                    if (counter == 8)
                    {
                        if (i < n - 1)
                        {
                            Console.WriteLine(result);
                            result = 0;
                            counter = 0;
                        }
                    }
                    index += step;
                } while (index < 8);
            }
            index -= 8;
        }
        Console.WriteLine(result);
    }
}
