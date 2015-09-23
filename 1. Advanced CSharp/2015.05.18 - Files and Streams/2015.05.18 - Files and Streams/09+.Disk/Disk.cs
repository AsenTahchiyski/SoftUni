using System;
class Disk
{
    static int r, center;
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // always odd
        r = int.Parse(Console.ReadLine());
        center = ((n - 1) / 2) + 1;
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (circleCheck(x, y))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
    static bool circleCheck(int x, int y)
    {
        bool inCircle = false;
        if (Math.Pow(center - x - 1, 2) + Math.Pow(center - y - 1, 2) <= r * r)
        {
            inCircle = true;
        }
        else
        {
            inCircle = false;
        }
        return inCircle;
    }
}
