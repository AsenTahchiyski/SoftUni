using System;
using System.Collections.Generic;
class AvgLoadTimeCalc
{
    static void Main()
    {
        Dictionary<string, double> dict = new Dictionary<string, double>();
        Dictionary<string, int> instances = new Dictionary<string, int>();
        do
        {
            string[] input = Console.ReadLine().Split(' ');
            if (input[0].ToLower() == "end" || string.IsNullOrEmpty(input[0]))
	        {
                foreach (var pair in dict)
                {
                    Console.WriteLine("{0} -> {1}", pair.Key, pair.Value/instances[pair.Key]);
                }
                return;   
	        }
            string site = input[2];
            double loadTime = double.Parse(input[3]);
            if (dict.ContainsKey(site))
            {
                dict[site] += loadTime;
                instances[site]++;
            }
            else
            {
                dict.Add(site, loadTime);
                instances.Add(site, 1);
            }
        } while (true);
    }
}
