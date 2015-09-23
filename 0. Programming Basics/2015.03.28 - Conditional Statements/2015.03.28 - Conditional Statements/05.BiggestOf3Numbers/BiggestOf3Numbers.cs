using System;
class BiggestOf3Numbers
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
	    if (a >= b && a >= c)
	    {
            Console.WriteLine("Biggest: " + a);	 
	    }
        else if (b >= a && b >= c)
        {
            Console.WriteLine("Biggest: " + b);
        }
        else
        {
            Console.WriteLine("Biggest: " + c);
        }
        goto Start;
    }
}
