using System;
using System.Collections.Generic;
using System.Linq;
class ActivityTracker
{
    static Dictionary<int, Dictionary<string, double>> allData = new Dictionary<int, Dictionary<string, double>>();
    static void Main()
    {
        // capture input
        int entries = int.Parse(Console.ReadLine());
        char[] delimiters = { ' ', '/' };
        for (int i = 0; i < entries; i++)
        {
            string[] input = Console.ReadLine().Split(delimiters);
            int month = int.Parse(input[1]);
            string name = input[3];
            double distance = double.Parse(input[4]);
            if (!allData.Keys.Contains(month))
            {
                allData.Add(month, new Dictionary<string, double>());
                allData[month].Add(name, distance);
            }
            else
            {
                if (!allData[month].Keys.Contains(name))
                {
                    allData[month].Add(name, distance);
                }
                else
                {
                    allData[month][name] += distance;
                }
            }
        }
        // sort months and names
        List<int> orderedMonths = allData.Keys.ToList();
        orderedMonths.Sort();
        List<string> orderedNames = new List<string>();
        foreach (var name in allData.Values)
        {
            foreach (var key in name)
            {
                if (!orderedNames.Contains(key.Key)) orderedNames.AddRange(name.Keys);    
            }
        }
        orderedNames.Sort();
        // print results
        foreach (var month in orderedMonths)
        {
            int userCount = 0;
            Console.Write(month + ": ");
            foreach (var name in orderedNames)
            {
                if (allData[month].Keys.Contains(name))
                {
                    userCount++;
                    Console.Write(name + "(" + allData[month][name] + ")" + (userCount >= allData[month].Values.Count ? string.Empty : ", "));    
                }
                if (userCount == allData[month].Values.Count)
                {
                    break;
                }
            }
            Console.WriteLine();
        }
    }
}
