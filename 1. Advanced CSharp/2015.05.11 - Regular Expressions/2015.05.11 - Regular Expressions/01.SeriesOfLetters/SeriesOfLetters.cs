using System;
using System.Text.RegularExpressions;
class SeriesOfLetters
{
    static void Main()
    {
        string pattern = @"(.)\1*";
        string text = Console.ReadLine();
        Regex removeDuplicates = new Regex(pattern);
        MatchCollection singleLetters = removeDuplicates.Matches(text);
        foreach (Match letter in singleLetters)
        {
            Console.Write(letter.Groups[1]);
        }
        Console.WriteLine();
    }
}
