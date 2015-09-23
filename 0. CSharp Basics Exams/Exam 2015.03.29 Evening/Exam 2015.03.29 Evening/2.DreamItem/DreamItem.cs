using System;
class DreamItem
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split('\\');
        string month = input[0];
        decimal moneyPerHour = decimal.Parse(input[1]);
        int hoursPerDay = int.Parse(input[2]);
        decimal itemPrice = decimal.Parse(input[3]);
        decimal budget = getWorkingDays(month) * hoursPerDay * moneyPerHour;
        if (budget > 700)
        {
            budget *= 1.1M;
        }
        if (budget >= itemPrice)
        {
            Console.WriteLine("Money left = {0:F2} leva.", budget - itemPrice);
        }
        else
        {
            Console.WriteLine("Not enough money. {0:F2} leva needed.", itemPrice - budget);
        }
    }
    static int getWorkingDays(string month)
    {
        switch (month)
        {
            case "Jan": return 31 - 10;
            case "Feb": return 28 - 10;
            case "Mar": return 31 - 10;
            case "March": return 31 - 10;
            case "Apr": return 30 - 10;
            case "May": return 31 - 10;
            case "June": return 30 - 10;
            case "July": return 31 - 10;
            case "Aug": return 31 - 10;
            case "Sept": return 30 - 10;
            case "Oct": return 31 - 10;
            case "Nov": return 30 - 10;
            case "Dec": return 31 - 10;
            default: return 0;
        }
    }
}
