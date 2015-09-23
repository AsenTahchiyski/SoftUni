using System;
class PiggyBank
{
    static void Main()
    {
        int price = int.Parse(Console.ReadLine());
        int partyDays = int.Parse(Console.ReadLine()); // per month
        int savedPerMonth = (30 - partyDays) * 2 - partyDays * 5;
        int monthsLeft = 0;
        if (price % savedPerMonth != 0)
        {
            monthsLeft = (price / savedPerMonth) + 1;
        }
        else
        {
            monthsLeft = price / savedPerMonth;
        }
        int years = monthsLeft / 12;
        int monthsRemainder = monthsLeft - 12 * years;
        if (monthsLeft > 0)
        {
            Console.WriteLine("{0} years, {1} months", years, monthsRemainder);
        }
        else
        {
            Console.WriteLine("never");
        }
    }
}
