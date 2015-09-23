using System;
using System.Text.RegularExpressions;
class SentenceExtractor
{
    static void Main()
    {
        string word = Console.ReadLine();
        string pattern = @"[A-Z][\w\s-']*\b" + word + @"\b[\w\s-']*[!.?]";
        string text = Console.ReadLine();
        MatchCollection matches = Regex.Matches(text, pattern);
        Console.WriteLine(new string('-', 40));
        foreach (var match in matches)
        {
            Console.WriteLine(match);
        }
    }
}
