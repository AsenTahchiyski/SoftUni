using System;
class CalcNfactDivKfact
{
    static void Main()
    {
        Start:
        int n, k;
        do
        {
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());    
        } while (n > 100 || n < 3);
        do
        {
            Console.Write("k = ");
            k = int.Parse(Console.ReadLine());
        } while (k > n || k < 2);
        int result = 1;
        for (int i = k + 1; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine(result);
        goto Start;
    }
}
