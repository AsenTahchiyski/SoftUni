using System;
class HalfSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] sum = new int[2];
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int temp = int.Parse(Console.ReadLine());
                sum[i] += temp;
            }
        }
        if (sum[0] == sum[1])
        {
            Console.WriteLine("Yes, sum={0}", sum[0]);
        }
        else
        {
            Console.WriteLine("No, diff={0}", Math.Abs(sum[0] - sum[1]));
        }
    }
}
