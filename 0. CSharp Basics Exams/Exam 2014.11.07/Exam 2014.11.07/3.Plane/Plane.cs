// работи 1:1 като авторското решение, макар че това е доста по-дълго и сложно от него. 0% в Judge
using System;
class Plane
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int DotStart = ((3 * n) - 1) / 2;
        int DotMid = 1;
        // first line
        for (int dots = DotStart; dots > 0; dots--)
        {
            Console.Write(".");
        }
        Console.Write("*");
        for (int dots = DotStart; dots > 0; dots--)
        {
            Console.Write(".");
        }
        Console.WriteLine();
        DotStart--;
        int DotStartCounter = 1;
        // top 1 section
        for (int TopLines = 0; TopLines < n - (n / 3); TopLines++)
        {
            for (int i = DotStart - TopLines; i > 0 ; i--)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int Mid = 0; Mid < DotMid; Mid++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int i = DotStart - TopLines; i > 0; i--)
            {
                Console.Write(".");
            }
            DotMid += 2;
            Console.WriteLine();
            DotStartCounter++;
        }
        // top 2 section
        DotStart = DotStart - DotStartCounter;
        DotMid = DotMid + 2;
        for (int TopLines2 = 0; TopLines2 < n / 3; TopLines2++) // ((5 * n) + 4) / 15
        {
            for (int Dot = DotStart; Dot > 0 ; Dot--)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int Mid = DotMid; Mid > 0; Mid--)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int Dot = DotStart; Dot > 0; Dot--)
            {
                Console.Write(".");
            }
            Console.WriteLine();
            DotStart -= 2;
            DotMid += 4;
        }  
        // mid section 1st line
        Console.Write("*");
        for (int WingDots = 0; WingDots < n - 2; WingDots++)
        {
            Console.Write(".");
        }
        Console.Write("*");
        for (int Mid = 0; Mid < n; Mid++)
        {
            Console.Write(".");
        }
        Console.Write("*");
        for (int WingDots = 0; WingDots < n - 2; WingDots++)
        {
            Console.Write(".");
        }
        Console.Write("*");
        Console.WriteLine();
        // mid section rest of lines
        DotStart = n - 2;
        for (int MidLines = 0; MidLines < (n / 2) - 1; MidLines++)
        {
            Console.Write("*");
            for (int WingDots = 0; WingDots < DotStart - 2; WingDots++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int OutWingDots = 0; OutWingDots <= n - DotStart - 2; OutWingDots++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int MidDots = 0; MidDots < n; MidDots++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int OutWingDots = 0; OutWingDots <= n - DotStart - 2; OutWingDots++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int WingDots = 0; WingDots < DotStart - 2; WingDots++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            Console.WriteLine();
            DotStart -= 2;
            }
            // bottom section
        DotStart = n - 1;
        DotMid = n;
        for (int BottomLines = 0; BottomLines < n - 1; BottomLines++)
        {
            for (int Start = 0; Start < DotStart; Start++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int Mid = 0; Mid < DotMid; Mid++)
            {
                Console.Write(".");
            }
            Console.Write("*");
            for (int Start = 0; Start < DotStart; Start++)
            {
                Console.Write(".");
            }
            Console.WriteLine();
            DotStart--;
            DotMid += 2;
        }
        // last line
        for (int i = 0; i < 3 * n; i++)
        {
            Console.Write("*");
        }
        Console.WriteLine();
    }
}
