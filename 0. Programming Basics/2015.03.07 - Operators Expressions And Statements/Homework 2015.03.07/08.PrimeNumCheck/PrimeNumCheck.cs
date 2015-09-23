using System;
class PrimeNumCheck
{
    static void Main()
    {
        Console.Write("Enter n = ");
        int n = int.Parse(Console.ReadLine());
        if (n < 2)
        {
            Console.WriteLine("n is Prime: False");
            return;
        }
        else
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0 && n != i)
                {
                    Console.WriteLine("n is Prime: False");
                    return;
                }
            }
        }
        Console.WriteLine("n is Prime: True");
    }
}
