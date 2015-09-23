using System;
class PokerStraight
{
    static void Main()
    {
        int weight = int.Parse(Console.ReadLine());
        int output = 0;
        for (int one = 1; one < 15; one++)
        {
            for (int two = 1; two < 15; two++)
            {
                for (int three = 1; three < 15; three++)
                {
                    for (int four = 1; four < 15; four++)
                    {
                        for (int five = 1; five < 15; five++)
                        {
                            int checkWeight = one * 10 + two * 20 + three * 30 + four * 40 + five * 50;
                            bool straight = two == one + 1 && three == two + 1 && four == three + 1 && five == four + 1;
                            if (checkWeight <= weight - 5 && checkWeight >= weight - 20 && straight)
                            {
                                for (int suit1 = 1; suit1 < 5; suit1++)
                                {
                                    for (int suit2 = 1; suit2 < 5; suit2++)
                                    {
                                        for (int suit3 = 1; suit3 < 5; suit3++)
                                        {
                                            for (int suit4 = 1; suit4 < 5; suit4++)
                                            {
                                                for (int suit5 = 1; suit5 < 5; suit5++)
                                                {
                                                    int checkSuit = suit1 + suit2 + suit3 + suit4 + suit5;
                                                    if (checkWeight + checkSuit == weight)
                                                    {
                                                        output++;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine(output);
    }
}
