using System;
class Volleyball
{
    static void Main()
    {
        string year = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int home = int.Parse(Console.ReadLine());
        double playsNormal = (48 - home) * 0.75;
        double playsHoliday = holidays * 2.0 / 3.0;
        double plays = home + playsNormal + playsHoliday;
        if (year == "leap")
        {
            plays *= 1.15;
        }
        Console.WriteLine(Math.Floor(plays));
    }
}