using System;
class PrintDeck52Cards
{
    static void Main()
    {
        for (int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write("{0}{1} ", face(i), suit(j));
            }
            Console.WriteLine();
        }
    }
    static string face(int number)
    {
        switch (number)
        {
            case 0: return "2";
            case 1: return "3";
            case 2: return "4";
            case 3: return "5";
            case 4: return "6";
            case 5: return "7";
            case 6: return "8";
            case 7: return "9";
            case 8: return "10";
            case 9: return "J";
            case 10: return "Q";
            case 11: return "K";
            case 12: return "A";
            default: return "";
        }
    }
    static string suit(int suit)
    {
        switch (suit)
        {
            case 0: return "♣";
            case 1: return "♦";
            case 2: return "♥";
            case 3: return "♠";
            default: return "";
        }
    }
}
