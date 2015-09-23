using System;
class SumOfElements
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] split = input.Split(' ');
        int[] numbers = new int[split.Length];
        int sum = 0;
        int minDiff = 0;
        for (int i = 0; i < split.Length; i++)
        {
            numbers[i] = Convert.ToInt32(split[i]);
            sum += numbers[i];
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            if (sum - numbers[i] == numbers[i])
            {
                Console.WriteLine("Yes, sum=" + numbers[i]);
                return;
            }
            else
            {
                if (minDiff == 0)
                {
                    minDiff = Math.Abs(sum - 2 * numbers[i]);
                }
                else if (minDiff > Math.Abs(sum - 2 * numbers[i]))
                {
                    minDiff = Math.Abs(sum - 2 * numbers[i]);
                }
            }
        }
        Console.WriteLine("No, diff=" + minDiff);
    }
}
