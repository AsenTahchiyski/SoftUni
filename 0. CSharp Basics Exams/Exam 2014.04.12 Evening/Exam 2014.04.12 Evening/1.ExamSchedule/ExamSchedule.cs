using System;
class ExamSchedule
{
    static void Main()
    {
        int hourStart = int.Parse(Console.ReadLine());
        int minStart = int.Parse(Console.ReadLine());
        string partOfDay = Console.ReadLine();
        int hoursExam = int.Parse(Console.ReadLine());
        int minsExam = int.Parse(Console.ReadLine());
        int hourEnd, minEnd;
        hourEnd = hourStart + hoursExam;
        minEnd = minStart + minsExam;
        if (minEnd > 59)
        {
            do
            {
                hourEnd++;
                minEnd -= 60;    
            } while (minEnd > 59);
        }
        if (hourEnd > 12)
        {
            do
            {
                if (partOfDay == "AM")
                {
                    partOfDay = "PM";
                    hourEnd -= 12;
                }
                else
                {
                    partOfDay = "AM";
                    hourEnd -= 12;
                }    
            } while (hourEnd > 12);
        }
        else if (hourEnd == 12)
        {
            if (partOfDay == "AM")
            {
                partOfDay = "PM";
            }
            else
            {
                partOfDay = "AM";
            }
        }
        Console.WriteLine("{0}:{1}:{2}", Convert.ToString(hourEnd).PadLeft(2, '0'), Convert.ToString(minEnd).PadLeft(2, '0'), partOfDay);
    }
}
