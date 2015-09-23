using System;
class BookProblem
{
    static void Main()
    {
        int pages = int.Parse(Console.ReadLine());
        int campingDays = int.Parse(Console.ReadLine());
        int pagesPerDay = int.Parse(Console.ReadLine());
        int years = 0, months = 0;
        int pagesPerMonth = pagesPerDay * (30 - campingDays);
        if (pagesPerMonth < 1)
        {
            Console.WriteLine("never");
            return;
        }
        months = (int)Math.Ceiling((double)((double)pages / pagesPerMonth));
        years = months / 12;
        months = months - 12 * years;
        Console.WriteLine("{0} years {1} months", years, months);
    }
}
