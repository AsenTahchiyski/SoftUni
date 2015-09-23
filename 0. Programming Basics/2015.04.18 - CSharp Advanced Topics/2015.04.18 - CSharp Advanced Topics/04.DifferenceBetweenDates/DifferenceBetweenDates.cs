using System;
class DifferenceBetweenDates
{
    static void Main()
    {
        DateTime firstDate = DateTime.Parse(Console.ReadLine());
        DateTime secondDate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine(secondDate.Subtract(firstDate).Days);
    }
}
