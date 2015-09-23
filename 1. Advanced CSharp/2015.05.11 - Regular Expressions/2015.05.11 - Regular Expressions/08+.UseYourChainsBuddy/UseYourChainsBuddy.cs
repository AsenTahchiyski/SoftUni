using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
class UseYourChainsBuddy
{
    static void Main()
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string patternBtwTags = @"<p>(.*?)<\/p>";
        string patternMatchSwapSpace = "[^a-z0-9]+";
        StringBuilder text = new StringBuilder(Console.ReadLine());
        // get text between <p> tags
        MatchCollection noTagsText = Regex.Matches(text.ToString(), patternBtwTags);
        text.Clear();
        for (int i = 0; i < noTagsText.Count; i++)
        {
            for (int j = 1; j < noTagsText[i].Groups.Count; j++)
            {
                text.Append(noTagsText[i].Groups[j].Value);
            }
        }
        // swap with spaces unneeded characters
        string finalStep = Regex.Replace(text.ToString(), patternMatchSwapSpace, " ");
        // reverse letters and print them
        foreach (char item in finalStep)
        {
            if (item >= 'a' && item <= 'm') Console.Write((char)(item + 13));
            else if (item >= 'n' && item <= 'z') Console.Write((char)(item - 13));
            else Console.Write(item);
        }
        Console.WriteLine();
    }
}
