using System;
class WorkHours
{
    static void Main()
    {
        int ProjectHours = int.Parse(Console.ReadLine());
        int DaysToGo = int.Parse(Console.ReadLine());
        int Productivity = int.Parse(Console.ReadLine());

        double HoursOfWork = DaysToGo * 0.9 * 12 * Productivity / 100;
        Console.WriteLine("{0}", ProjectHours <= Math.Floor(HoursOfWork) ? "Yes" : "No");
        Console.WriteLine(Math.Floor(HoursOfWork) - ProjectHours);
    }
}
