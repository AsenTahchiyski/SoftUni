using System;
class Boat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int stars = 1;
        bool lowSail = false;
        // print sail
        for (int sailRows = 0; sailRows < n; sailRows++) 
        {
            for (int dot = 0; dot < n - stars; dot++)
            {
                Console.Write(".");
            }
            for (int star = 0; star < stars; star ++)
            {
                Console.Write("*");
            }
            for (int rightDots = 0; rightDots < n; rightDots++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
            if (stars == n)
            {
                stars -= 2;
                lowSail = true;
            }
            else if (stars < n && lowSail == true)
            {
                stars -= 2;
            }
            else
            {
                stars += 2;
            }
        }
        // print boat
        int boatStars = 2 * n;
        for (int line = 0; line < (n - 1) / 2; line++)
        {
            for (int dot = 0; dot < line; dot++)
            {
                Console.Write(".");
            }
            for (int j = 0; j < boatStars - 2 * line; j++)
            {
                Console.Write("*");
            }
            for (int dot = 0; dot < line; dot++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}
