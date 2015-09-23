using System;
class Sort3NumbersNestedIfs
{
    static void Main()
    {
        Start:
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());

        // with nested ifs
        if (a >= b && a >= c)
        {
            if (b >= c)
            {
                Console.WriteLine("{0} {1} {2}", a, b, c);
                goto Start;
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", a, c, b);
                goto Start;
            }
        }
        else if (b >= c && b >= a)
        {
            if (c >= a)
            {
                Console.WriteLine("{0} {1} {2}", b, c, a);
                goto Start;
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", b, a, c);
                goto Start;
            }
        }
        else if (c >= a && c >= b)
        {
            if (a >= b)
            {
                Console.WriteLine("{0} {1} {2}", c, a, b);
                goto Start;
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", c, b, a);
                goto Start;
            }
        }
// without nested ifs 
/*
        if (a >= b && a >= c)
        {
            Console.WriteLine(a + " {0} {1}", b >= c ? b : c, b >= c ? c : b);
            goto Start;
        }
        if (b >= a && b >= c)
        {
            Console.WriteLine(b + " {0} {1}", a >= c ? a : c, a >= c ? c : a);
            goto Start;
        }
        if (c >= a && c >= b)
        {
            Console.WriteLine(c + " {0} {1}", a >= b ? a : b, a >= b ? b : a);
            goto Start;
        } 
*/
    }
}


