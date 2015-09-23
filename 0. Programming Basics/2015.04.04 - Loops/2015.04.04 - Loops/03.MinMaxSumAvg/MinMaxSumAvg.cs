using System;
class MinMaxSumAvg
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter n numbers: ");
        int min = int.MaxValue, max = int.MinValue, sum = 0;
        double avg;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            sum += number;
            if (number > max)
            {
                max = number;
            }
            if (number < min)
            {
                min = number;
            }
        }
        avg = (double)sum / n;
        Console.WriteLine("min = {0} \nmax = {1} \nsum = {2}\navg = {3:F2}", min, max, sum, avg);
    }
}
