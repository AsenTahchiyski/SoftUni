using System;
using System.Text.RegularExpressions;
class ValidUsernames
{
    static void Main()
    {
        string pattern = @"\b([a-zA-Z]\w{2,24})\b"; // EBojilova
        string usernames = Console.ReadLine();
        MatchCollection matches = Regex.Matches(usernames, pattern);
        int maxSum = 0, maxIndex = -1;
        for (int i = 0; i < matches.Count; i++)
        {
            if (i == matches.Count - 1) break;
            if (matches[i].Length + matches[i + 1].Length > maxSum)
            {
                maxSum = matches[i].Length + matches[i + 1].Length;
                maxIndex = i;
            }
        }
        Console.WriteLine("{0}\n{1}", matches[maxIndex], matches[maxIndex + 1]);
    }
}
