using System;
class Electricity
{
    static void Main()
    {
        int floors = int.Parse(Console.ReadLine());
        int flats = int.Parse(Console.ReadLine());
        string time = Console.ReadLine();
        string[] TimeSplit = time.Split(':');
        int hour = Convert.ToInt32(TimeSplit[0]);
        double ConsumedPerFlat = 0;
        if (hour >= 14 && hour < 19)
        {
            ConsumedPerFlat = 2 * 100.53f + 2 * 125.90f;
        }
        else if (hour >= 19 && hour <= 23)
        {
            ConsumedPerFlat = 7 * 100.53f + 6 * 125.90f;
        }
        else if (hour >= 0 && hour < 9)
        {
            ConsumedPerFlat = 1 * 100.53f + 8 * 125.90f;
        }
        Console.WriteLine("{0} Watts", (int)(floors * flats * ConsumedPerFlat));
    }
}
