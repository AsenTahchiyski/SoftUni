using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class BiggestTableRow
{
    static void Main()
    {
        string pattern = @">(-?\d*\.?\d+)<";
        string line;
        double maxSum = double.MinValue;
        int lineCounter = 0;
        List<string> maxNumbers = new List<string>();
        while ((line = Console.ReadLine()) != "</table>")
        {
            lineCounter++;
            if (lineCounter < 3) continue;
            MatchCollection numbers = Regex.Matches(line, pattern);
            double checkSum = 0;
            foreach (Match number in numbers)
            {
                checkSum += double.Parse(number.Groups[1].Value);
            }
            if (checkSum > maxSum)
            {
                maxSum = checkSum;
                maxNumbers.Clear();
                foreach (Match number in numbers)
                {
                    maxNumbers.Add(number.Groups[1].Value);
                }
            }
        }
        if (maxNumbers.Count == 0)
        {
            Console.WriteLine("no data");
            return;
        }
        Console.WriteLine("{0} = {1}", maxSum, string.Join(" + ", maxNumbers));
    }
}
