using System;
class CheckForPlayCard
{
    static void Main()
    {
        Start:
        Console.Write("Enter a character: ");
        string testStr = Console.ReadLine();
        bool isCard = false;
        switch (testStr)
        {
            case "2": isCard = true; break;
            case "3": isCard = true; break;
            case "4": isCard = true; break;
            case "5": isCard = true; break;
            case "6": isCard = true; break;
            case "7": isCard = true; break;
            case "8": isCard = true; break;
            case "9": isCard = true; break;
            case "10": isCard = true; break;
            case "J": isCard = true; break;
            case "Q": isCard = true; break;
            case "K": isCard = true; break;
            case "A": isCard = true; break;
            default: break;
        }
        Console.WriteLine("Valid card sign: {0}", isCard ? "yes" : "no");
        goto Start;
    }
}
