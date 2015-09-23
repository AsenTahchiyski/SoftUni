using System;
class WeirdCombinations
{
    static void Main()
    {
        string input = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        for (int one = 0; one < 5; one++)
        {
            for (int two = 0; two < 5; two++)
            {
                for (int three = 0; three < 5; three++)
                {
                    for (int four = 0; four < 5; four++)
                    {
                        for (int five = 0; five < 5; five++)
                        {
                            if (n == 0)
                            {
                                Console.WriteLine("{0}{1}{2}{3}{4}", input[one], input[two], input[three], input[four], input[five]);
                                return;
                            }
                            else
                            {
                                n--;
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine("No");
    }
}
