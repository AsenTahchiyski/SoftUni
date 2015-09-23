using System;
class CalculateGCD
{
    static void Main()
    {
        Console.Write("a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("b = ");
        int b = int.Parse(Console.ReadLine());
        if (a == b)
        {
            Console.WriteLine("GCD = " + a);
            return;
        }
        int bigger, smaller;
        bigger = a > b ? Math.Abs(a) : Math.Abs(b);
        smaller = a > b ? Math.Abs(b) : Math.Abs(a);
        do
        {
            if (smaller != 0)
            {
                bigger = bigger % smaller;
            }
            //else
            //{
            //    Console.WriteLine("GCD = 0");
            //    return;
            //}
            if (bigger < smaller && bigger != 0)
            {
                int temp = bigger;
                bigger = smaller;
                smaller = temp;
            }
        } while (bigger > 0);
        Console.WriteLine("GCD = " + smaller);
    }
}
