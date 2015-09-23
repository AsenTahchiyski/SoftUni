using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class SumOfAllValues
{
    static void Main()
    {
        string keys = Console.ReadLine();
        string text = Console.ReadLine();
        string pattern = @"^([A-Za-z_]+)\d.*\d([A-Za-z_]+)$";
        Match keysMatch = Regex.Match(keys, pattern);
        if (!keysMatch.Success)
        {
            Console.WriteLine("<p>A key is missing</p>");
            return;
        }
        string startKey = keysMatch.Groups[1].Value;
        string endKey = keysMatch.Groups[2].Value;
        string matchNumbersPattern = startKey + @"(\d*\.?\d+)" + endKey;
        MatchCollection matchedNumbers = Regex.Matches(text, matchNumbersPattern);
        if (matchedNumbers.Count == 0)
        {
            Console.WriteLine("<p>The total value is: <em>nothing</em></p>");
            return;
        }
        double sum = 0;
        foreach (Match number in matchedNumbers)
        {
            sum += double.Parse(number.Groups[1].Value);
        }
        Console.WriteLine("<p>The total value is: <em>{0:0.##}</em></p>", sum);
    }
}
