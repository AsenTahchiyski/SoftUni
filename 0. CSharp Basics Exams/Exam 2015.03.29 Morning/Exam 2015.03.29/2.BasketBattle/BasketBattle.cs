using System;
class BasketBattle
{
    static void Main()
    {
        string first = Console.ReadLine();
        int rounds = int.Parse(Console.ReadLine());
        int firstPoints = 0;
        int secondPoints = 0;
        string firstPlayer = first;
        string secondPlayer = first == "Simeon" ? "Nakov" : "Simeon";
        string currentPlayer = first;
        int score = int.Parse(Console.ReadLine());
        string success = Console.ReadLine();
        if (score <= 500 && success == "success")
        {
            firstPoints += score;
            if (firstPoints == 500)
            {
                Console.WriteLine("{0}\n{1}\n{2}", firstPlayer, "1", secondPoints);
                return;
            }
        }
        currentPlayer = secondPlayer;
        int firstShots = 0; // all shots - 1
        int secShots = 0;
        for (int i = 1; i < rounds * 2; i++)
        {
            score = int.Parse(Console.ReadLine());
            success = Console.ReadLine();
            if (currentPlayer == secondPlayer) // second player's turn
            {
                secShots++;
                if (success == "success" && secondPoints + score <= 500)
                {
                    secondPoints += score;
                    if (secondPoints == 500)
                    {
                        Console.WriteLine("{0}\n{1}\n{2}", secondPlayer, i / 2 + 1, firstPoints);
                        return;
                    }
                }
                if (secShots % 2 == 0)
                {
                    currentPlayer = firstPlayer;
                }
            }
            else if (currentPlayer == firstPlayer) // first player's turn
            {
                firstShots++;
                if (success == "success" && firstPoints + score <= 500)
                {
                    firstPoints += score;
                    if (firstPoints == 500)
                    {
                        Console.WriteLine("{0}\n{1}\n{2}", firstPlayer, i / 2 + 1, secondPoints);
                        return;
                    }
                }
                if (firstShots % 2 == 0)
                {
                    currentPlayer = secondPlayer;
                }
            }
           
        }
        if (firstPoints == secondPoints)
        {
            Console.WriteLine("DRAW\n{0}", firstPoints);
        }
        else if (firstPoints > secondPoints)
        {
            Console.WriteLine("{0}\n{1}", firstPlayer, firstPoints - secondPoints);
        }
        else if (secondPoints > firstPoints)
        {
            Console.WriteLine("{0}\n{1}", secondPlayer, secondPoints - firstPoints);
        }
    }
}
