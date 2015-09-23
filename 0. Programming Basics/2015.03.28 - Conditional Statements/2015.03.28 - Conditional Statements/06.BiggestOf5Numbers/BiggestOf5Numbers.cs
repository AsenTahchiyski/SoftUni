using System;
class BiggestOf5Numbers
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
        Console.Write("d = ");
        double d = double.Parse(Console.ReadLine());
        Console.Write("e = ");
        double e = double.Parse(Console.ReadLine());
	    if (a >= b && a >= c && a >= d && a >= e)
	    {
            Console.WriteLine("Biggest: " + a);
            goto Start;
	    }
        if (b >= a && b >= c && b >= d && b >= e)
        {
            Console.WriteLine("Biggest: " + b);
            goto Start;
        }
        if (c >= a && c >= b && c >= d && c >= e)
        {
            Console.WriteLine("Biggest: " + c);
            goto Start;
        }
        if (d >= a && d >= b && d >= c && d >= e)
        {
            Console.WriteLine("Biggest: " + d);
            goto Start;
        }
        if (e >= a && e >= b && e >= c && e >= d)
        {
            Console.WriteLine("Biggest: " + e);
            goto Start;
        }
    }
}
