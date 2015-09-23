using System;
class Budget
{
    static void Main()
    {
        int budget = int.Parse(Console.ReadLine());
        int goOut = int.Parse(Console.ReadLine());
        int home = int.Parse(Console.ReadLine());
        int spendWeek = 10 * (22 - goOut);
        int spendWknd = 20 * 2 * (4 - home);
        int spendGoOut = goOut * (int)(10 + 0.03 * budget);
        int totalSpend = spendWeek + spendWknd + spendGoOut + 150;
        if (totalSpend == budget)
        {
            Console.WriteLine("Exact Budget.");
        }
        else if (totalSpend < budget)
        {
            Console.WriteLine("Yes, leftover {0}.", (budget - totalSpend));
        }
        else
        {
            Console.WriteLine("No, not enough {0}.", (totalSpend - budget));
        }
    }
}
