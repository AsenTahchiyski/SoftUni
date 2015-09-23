using System;
using System.Linq;
class PythagoreanNumbers
{
    static void Main()
    {
        // input
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        bool noResult = true;
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        // check if solved
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                int a = numbers[i];
                int b = numbers[j];
                if (a <= b)
                {
                    if (Math.Sqrt(a * a + b * b) % 1 == 0)
                    {
                        int c = (int)(Math.Sqrt(a * a + b * b));
                        if (numbers.Contains(c))
                        {
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", a, b, c);
                            noResult = false;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
        if (noResult)
        {
            Console.WriteLine("No");
        }
    }
}
