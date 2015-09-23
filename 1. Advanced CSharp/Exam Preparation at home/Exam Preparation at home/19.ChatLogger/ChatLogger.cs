using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;
using System.Threading;
class ChatLogger
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        DateTime currentTime = DateTime.Parse(Console.ReadLine());
        string line;
        SortedDictionary<DateTime, string> log = new SortedDictionary<DateTime, string>();
        string pattern = @"(.*) \/ (\d{2}-\d{2}-\d{4} \d{2}:\d{2}:\d{2})";
        while ((line = Console.ReadLine()) != "END")
        {
            Match lineData = Regex.Match(line, pattern);
            string currentMsg = lineData.Groups[1].Value;
            DateTime currentDate = DateTime.Parse(lineData.Groups[2].Value);
            log.Add(currentDate, currentMsg);
        }
        foreach (var record in log)
        {
            Console.WriteLine("<div>{0}</div>", SecurityElement.Escape(record.Value));
        }
        Console.WriteLine("<p>Last active: <time>{0}</time></p>", SecurityElement.Escape(GetLastActive(log, currentTime)));
    }
    static string GetLastActive(SortedDictionary<DateTime, string> log, DateTime currentTime)
    {
        DateTime lastMessageTime = log.Keys.Last();
        TimeSpan difference = currentTime - lastMessageTime;
        if (difference.Minutes < 1 && difference.Hours == 0)
        {
            if (currentTime.DayOfYear - lastMessageTime.DayOfYear == 1) return "yesterday";
            return "a few moments ago";
        }
        if (difference.TotalHours < 1)
        {
            if (currentTime.DayOfYear - lastMessageTime.DayOfYear == 1) return "yesterday";
            if (difference.TotalMinutes >= 1) return string.Format("{0} minute(s) ago", (int)Math.Floor(difference.TotalMinutes));
            //if (difference.TotalMinutes == 1) return "1 minute ago";
        }
        if (difference.TotalHours < 24)
        {
            if (currentTime.DayOfYear - lastMessageTime.DayOfYear == 1) return "yesterday";
            if (difference.TotalHours >= 1) return string.Format("{0} hour(s) ago", (int)Math.Floor(difference.TotalHours));
            //if (difference.TotalHours == 1) return "1 hour ago";
        }
        if (currentTime.DayOfYear - lastMessageTime.DayOfYear == 1) return "yesterday";
        if (currentTime.DayOfYear - lastMessageTime.DayOfYear > 1) return string.Format("{0}", lastMessageTime.ToString("dd-MM-yyyy"));
        return string.Empty;
	}
}
