using System;
class OddEvenSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int oddSum = 0;
        int evenSum = 0;
        for (int i = 1; i <= 2 * n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                evenSum += number;
            }
            else
            {
                oddSum += number;
            }
        }
        Console.WriteLine("{0}, {1}={2}", evenSum == oddSum ? "Yes" : "No", evenSum != oddSum ? "diff" : "sum", evenSum != oddSum ? Math.Abs(oddSum - evenSum) : oddSum);
    }
}