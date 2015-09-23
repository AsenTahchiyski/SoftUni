using System;
class NumsInIntervalDivByGivenNum
{
    static void Main()
    {
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int p = 0;
        for (int i = first; i <= second; i++)
        {
            if (i % 5 == 0)
            {
                p++;
            }
        }
        Console.WriteLine("p = " + p);
    }
}
