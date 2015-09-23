using System;
class InsideTheBuilding
{
    static void Main()
    {
        int h = int.Parse(Console.ReadLine());
        for (int i = 0; i < 5; i++)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            if (y > 4 * h || y < 0)
            {
                Console.WriteLine("outside");
                continue;
            }
            else if(y >= 0 && y <= h)
            {
                if (x < 0 || x > 3 * h)
                {
                    Console.WriteLine("outside");
                    continue;
                }
                else
                {
                    Console.WriteLine("inside");
                    continue;
                }
            }
            else if (y > h && y <= 4 * h)
            {
                if (x < h || x > 2 * h)
                {
                    Console.WriteLine("outside");
                    continue;
                }
                else
                {
                    Console.WriteLine("inside");
                    continue;
                }
            }
        }
    }
}
