using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class LittleJohn
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 4; i++)
        {
            sb.AppendFormat(" {0}", Console.ReadLine());
        }
        string arrowPattern = @"(>>>----->>)|(>>----->)|(>----->)";
        Regex arrowMatcher = new Regex(arrowPattern);
        var arrows = arrowMatcher.Matches(sb.ToString());
        int largeArrowCount = 0;
        int medArrowCount = 0;
        int smallArrowCount = 0;
        foreach (Match arrow in arrows)
        {
            if (!string.IsNullOrEmpty(arrow.Groups[1].Value)) largeArrowCount++;
            else if (!string.IsNullOrEmpty(arrow.Groups[2].Value)) medArrowCount++;
            else if (!string.IsNullOrEmpty(arrow.Groups[3].Value)) smallArrowCount++;
        }
        string numberAsString = string.Format("{0}{1}{2}", smallArrowCount, medArrowCount, largeArrowCount);
        long number = long.Parse(numberAsString);
        string binaryNum = Convert.ToString(number, 2);
        string reversedBinNum = new string(binaryNum.Reverse().ToArray());
        string resultAsString = binaryNum + reversedBinNum;
        long result = Convert.ToInt64(resultAsString, 2);
        Console.WriteLine(result);
    }
}
