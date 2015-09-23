using System;
class BeerTime
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Start:
        Console.Write("Enter time in format HH:MM AM/PM: ");
        string[] input = Console.ReadLine().Split(' ', ':');
        int hour = int.Parse(input[0]);
        int minutes = int.Parse(input[1]);
        string halfday = input[2];
        if (halfday == "AM")
        {
            if (hour < 3)
            {
                if (minutes <= 59)
                {
                    Console.WriteLine("beer time c|_|");
                }
                else
                {
                    Console.WriteLine("invalid time");
                }
            }
            else if (hour <= 12)
            {
                Console.WriteLine("non-beer time :(");
            }
            else
	        {
                Console.WriteLine("invalid time");
	        }
        }
        else if (halfday == "PM")
        {
            if (hour >= 1 && hour <= 12)
            {
                if (minutes >= 0 && minutes <= 59)
                {
                    Console.WriteLine("beer time c|_|");
                }
                else
                {
                    Console.WriteLine("invalid time");
                }
            }
            else if (hour == 0 && minutes >= 0 && minutes <= 59)
            {
                Console.WriteLine("non-beer time :(");
            }
            else
            {
                Console.WriteLine("invalid time");
            }
        }
        goto Start;
    }
}
