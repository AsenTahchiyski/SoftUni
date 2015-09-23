using System;
class TravellerBob
{
    static void Main()
    {
        string leap = Console.ReadLine();
        int contractMonths = int.Parse(Console.ReadLine());
        int familyMonths = int.Parse(Console.ReadLine());
        int contractTravels = contractMonths * 12;
        int familyTravels = familyMonths * 4;
        int normalWeeks = (12 - contractMonths - familyMonths);
        double normalTravels = normalWeeks * 12 * 0.6;
        double allTravels = contractTravels + familyTravels + normalTravels;
        if (leap == "leap")
        {
            Console.WriteLine(Math.Floor(allTravels * 1.05));
        }
        else
        {
            Console.WriteLine(Math.Floor(allTravels));
        }
    }
}

