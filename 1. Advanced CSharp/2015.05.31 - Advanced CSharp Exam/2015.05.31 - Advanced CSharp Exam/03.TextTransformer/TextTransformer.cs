using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class TextTransformer
{
    static void Main()
    {
        string input;
        StringBuilder fullText = new StringBuilder();
        while ((input = Console.ReadLine()) != "burp")
        {
            fullText.Append(input);
        }
        string temp = Regex.Replace(fullText.ToString(), @"\s+", " ");
        fullText.Clear();
        fullText.Append(temp);
        string pattern = @"([$%&'])([^$%&'\n]+)\1";
        MatchCollection matches = Regex.Matches(fullText.ToString(), pattern);
        List<string> output = new List<string>();
        foreach (Match item in matches)
	    {
            char symbol = char.Parse(item.Groups[1].Value);
            StringBuilder word = new StringBuilder(item.Groups[2].Value);
            for (int i = 0; i < word.Length; i++)
            {
                if (i % 2 == 0) word[i] = (char)(word[i] + GetSymbolWeight(symbol));
                else word[i] = (char)(word[i] - GetSymbolWeight(symbol));
            }
            output.Add(word.ToString());
	    }
        Console.WriteLine(string.Join(" ", output));
    }
    static int GetSymbolWeight(char symbol)
    {
        switch (symbol)
        {
            case '$': return 1;
            case '%': return 2;
            case '&': return 3;
            case '\'': return 4;
            default: return 0;
        }
    }
}
