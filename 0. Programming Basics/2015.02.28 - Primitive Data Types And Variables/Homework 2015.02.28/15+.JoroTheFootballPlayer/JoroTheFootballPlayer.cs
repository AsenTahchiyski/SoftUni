using System;
class JoroTheFootballPlayer
{
    static void Main()
    {
        string leap = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometown = int.Parse(Console.ReadLine());
        int normalWeekends = 52 - hometown;
        double normalPlays = 2 * normalWeekends / 3;
        double plays = (double)(holidays / 2) + normalPlays + hometown;
        if (leap == "t")
        {
            plays += 3;
        }
        Console.WriteLine(Math.Floor(plays));
    }
}
