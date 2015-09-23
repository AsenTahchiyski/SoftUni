using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
class OfficeStuff
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var supplies = new SortedDictionary<string, Dictionary<string, int>>();
        string pattern = @"\|(\w+) - ([0-9]+) - (\w+)\|";
        for (int i = 0; i < n; i++)
		{
            Match match = Regex.Match(Console.ReadLine(), pattern);
            string company = match.Groups[1].Value;
            int quantity = int.Parse(match.Groups[2].Value);
            string supply = match.Groups[3].Value;
            if (!supplies.Keys.Contains(company))
            {
                var supplyQty = new Dictionary<string, int>();
                supplyQty.Add(supply, quantity);
                supplies.Add(company, supplyQty);
            }
            else
            {
                if (!supplies[company].Keys.Contains(supply))
                {
                    supplies[company].Add(supply, quantity);
                }
                else
                {
                    supplies[company][supply] += quantity;
                }
            }
		}
        foreach (var company in supplies)
        {
            Console.Write(company.Key + ": ");
            int counter = supplies[company.Key].Keys.Count;
            foreach (var supply in company.Value)
            {
                Console.Write("{0}-{1}", supply.Key, supply.Value);
                counter--;
                if (counter > 0) Console.Write(", ");
            }
            Console.WriteLine();
        }
    }
}
