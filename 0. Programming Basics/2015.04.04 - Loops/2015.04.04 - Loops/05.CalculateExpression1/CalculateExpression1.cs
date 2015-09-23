using System;
class CalculateExpression1
{
    static void Main()
    {
        Start:
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("x = ");
        int x = int.Parse(Console.ReadLine());
        double sum = 1;
        int factorial = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            sum += factorial / Math.Pow(x, i);
        }
        Console.WriteLine("{0:F5}", sum);
        goto Start;
    }
}
