using System;
using System.Text.RegularExpressions;
class ExtractEmails
{
    static void Main()
    {
        string pattern = @"(?<=\s|^)([a-z0-9]+[_.-]?[a-z0-9]*@[a-z]+\-?[a-z]+(?:\.[a-z]+)+)\b"; // EBojilova / Katia Marincheva
        string text = Console.ReadLine();
        MatchCollection matches = Regex.Matches(text, pattern);
        foreach (var match in matches)
        {
            Console.WriteLine("Email: " + match);
        }
    }
}
