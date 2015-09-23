using System;
class Headphones
{
    static void Main()
    {
        int diameter = int.Parse(Console.ReadLine());
        // headband
        for (int i = 0; i < diameter; i++)
        {
            for (int a = 0; a < diameter / 2; a++)
            {
                Console.Write("-");
            }
            if (i == 0)
            {
                for (int b = 0; b < diameter + 2; b++)
                {
                    Console.Write("*");
                }  
            }
            else
            {
                Console.Write("*");
                for (int d = 0; d < diameter; d++)
                {
                    Console.Write("-");
                }
                Console.Write("*");
            }
            for (int c = 0; c < diameter / 2; c++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
        // first half
        int counter = 0;
        do
        {
            for (int j = 0; j <= ((diameter - 1) / 2); j++)
            {
                for (int x = 0; x < (diameter / 2) - counter; x++)
                {
                    Console.Write("-");
                }
                for (int y = 0; y < 1 + 2 * counter; y++)
                {
                    Console.Write("*");
                }
                for (int z = 0; z < diameter - 2 * counter; z++)
                {
                    Console.Write("-");
                }
                for (int y = 0; y < 1 + 2 * counter; y++)
                {
                    Console.Write("*");
                }
                for (int x = 0; x < (diameter / 2) - counter; x++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                counter++;
            }
        }
        while (counter <= (diameter - 1) / 2);
        // second half
        counter -= 2;
        do
        {
            for (int j = 0; j < (diameter / 2); j++)
            {
                for (int x = 0; x < (diameter / 2) - Math.Abs(counter); x++)
                {
                    Console.Write("-");
                }
                for (int y = 0; y < 1 + 2 * counter; y++)
                {
                    Console.Write("*");
                }
                for (int z = 0; z < diameter - 2 * counter; z++)
                {
                    Console.Write("-");
                }
                for (int y = 0; y < 1 + 2 * counter; y++)
                {
                    Console.Write("*");
                }
                for (int x = 0; x < (diameter / 2) - counter; x++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
                counter--;
            }
        }
        while (counter > 0);
     }
 }
