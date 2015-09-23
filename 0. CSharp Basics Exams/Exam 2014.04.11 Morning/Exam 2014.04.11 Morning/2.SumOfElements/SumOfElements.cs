using System;
class SumOfElements
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        long smallestDiff = long.MaxValue;
        for (int i = 0; i < input.Length; i++)
        {
            long sum = 0;
            for (int j = 0; j < input.Length; j++)
            {
                if (j != i)
                {
                    sum += int.Parse(input[j]);        
                }    
            }
            if (sum == int.Parse(input[i]))
            {
                Console.WriteLine("Yes, sum=" + sum);
                return;
            }
            else
            {
                if (Math.Abs(sum - int.Parse(input[i])) < smallestDiff)
                {
                    smallestDiff = Math.Abs(sum - int.Parse(input[i]));
                }
            }
        }
        Console.WriteLine("No, diff=" + smallestDiff);
    }
}
