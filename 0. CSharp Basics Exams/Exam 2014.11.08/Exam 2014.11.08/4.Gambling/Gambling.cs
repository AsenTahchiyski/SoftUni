using System;
class Gambling
{
    static void Main()
    {
        decimal c = decimal.Parse(Console.ReadLine());
        string houseHand = Console.ReadLine();
        string[] houseCards = houseHand.Split(' ');
        int houseHandValue = 0;
        for (int i = 0; i < 4; i++)
        {
            houseHandValue += getCardValue(houseCards[i]);
        }
        // check possibility
        int higherHand = 0;
        int lowerHand = 0;
        for (int card1 = 2; card1 <= 14; card1++)
        {
            for (int card2 = 2; card2 <= 14; card2++)
            {
                for (int card3 = 2; card3 <= 14; card3++)
                {
                    for (int card4 = 2; card4 <= 14; card4++)
                    {
                        if (card1 + card2 + card3 + card4 <= houseHandValue)
                        {
                            lowerHand++;
                        }
                        else
                        {
                            higherHand++;
                        }
                    }
                }
            }
        }
        if (higherHand > lowerHand)
        {
            Console.WriteLine("DRAW");
        }
        else
        {
            Console.WriteLine("FOLD");
        }
        decimal probability = ((decimal)higherHand / ((decimal)higherHand + (decimal)lowerHand));
        decimal winnings = 2 * c * probability;
        Console.WriteLine(Math.Round(winnings, 2));
    }
    static int getCardValue(string card)
    {
        int value = 0;
        switch (card)
        {
            case "2": value = 2; break;
            case "3": value = 3; break;
            case "4": value = 4; break;
            case "5": value = 5; break;
            case "6": value = 6; break;
            case "7": value = 7; break;
            case "8": value = 8; break;
            case "9": value = 9; break;
            case "10": value = 10; break;
            case "J": value = 11; break;
            case "Q": value = 12; break;
            case "K": value = 13; break;
            case "A": value = 14; break;
            default:              break;
        }
        return (value);
    }
}
