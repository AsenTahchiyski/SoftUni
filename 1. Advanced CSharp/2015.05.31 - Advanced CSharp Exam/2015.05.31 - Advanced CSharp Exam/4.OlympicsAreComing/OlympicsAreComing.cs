using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class OlympicsAreComing
{
    static void Main()
    {
        Dictionary<string, Dictionary<string, int>> stats = new Dictionary<string, Dictionary<string, int>>();
        string input;
        string pattern1 = @"^([A-Za-z]+\s*[A-Za-z]*)\s*\|\s*([A-Za-z]+[\s.'A-Za-z0-9-]*)";
        while ((input = Console.ReadLine()) != "report")
        {
            Match playerData = Regex.Match(input, pattern1);
            string name = playerData.Groups[1].Value.Trim();
            string country = playerData.Groups[2].Value.Trim();
            name = Regex.Replace(name, @"\s+", " ");
            country = Regex.Replace(country, @"\s+", " ");
            if(!stats.ContainsKey(country)) 
                stats.Add(country, new Dictionary<string, int>());
            if (!stats[country].ContainsKey(name))
                stats[country].Add(name, 1);
            else stats[country][name]++;
        }
        var sortedOutput = stats.OrderByDescending(x => x.Value.Skip(0).Sum(y => y.Value));
        foreach (var country in sortedOutput)
        {
            Console.WriteLine("{0} ({1} participants): {2} wins",
                                country.Key, country.Value.Count, country.Value.Skip(0).Sum(x => x.Value));
        }
    }
}

