using System;
class BonusScore
{
    static void Main()
    {
        Start:
        Console.Write("Score = ");
        int score = int.Parse(Console.ReadLine());
        if (score > 0 && score < 4)
        {
            score *= 10;
        }
        else if (score > 3 && score < 7)
        {
            score *= 100;
        }
        else if (score > 6 && score < 10)
        {
            score *= 1000;
        }
        else
        {
            Console.WriteLine("invalid score");
            goto Start;
        }
        Console.WriteLine(score);
        goto Start;
    }
}
