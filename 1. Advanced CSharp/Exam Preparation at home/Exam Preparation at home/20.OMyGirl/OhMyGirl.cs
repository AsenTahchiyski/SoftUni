using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class OhMyGirl
{
    static void Main()
    {
        // get key
        string key = Console.ReadLine();
        string keyPattern = GetKeyRegexPattern(key);
        // get input
        string line;
        StringBuilder fullText = new StringBuilder();
        StringBuilder address = new StringBuilder();
        Regex matchText = new Regex(keyPattern);
        while ((line = Console.ReadLine()) != "END")
        {
            if (!matchText.IsMatch(line)) continue;
            fullText.Append(line);
        }
        // assemble output
        MatchCollection matchedParts = matchText.Matches(fullText.ToString());
        foreach (Match part in matchedParts)
        {
            string temp = part.Groups[1].Value;
            address.Append(temp);
        }
        Console.WriteLine(address);
    }
    static string GetKeyRegexPattern(string keyFormat)
    {
        StringBuilder key = new StringBuilder(keyFormat);
        int newIndex = 1;
        char[] specialSymbols = {'*', '+', '?', '[', ']', '{', '}', ',', '.', '^', '$', '<', '>', '\\', '/', '(', ')'};
        for (int i = 1; i < keyFormat.Length - 1; i++)
        {
            char ch = keyFormat[i];
            if (char.IsDigit(ch))
            {
                key.Remove(newIndex, 1);
                key.Insert(newIndex, @"\d*");
                newIndex += 3;
            }
            else if (char.IsLower(ch))
            {
                key.Remove(newIndex, 1);
                key.Insert(newIndex, @"[a-z]*");
                newIndex += 6;
            }
            else if (char.IsUpper(ch))
            {
                key.Remove(newIndex, 1);
                key.Insert(newIndex, @"[A-Z]*");
                newIndex += 6;
            }
            else if (specialSymbols.Contains(ch))
            {
                key.Remove(newIndex, 1);
                key.Insert(newIndex, string.Format(@"\" + ch));
                newIndex += 2;
            }
            else newIndex++;
        }
        if (specialSymbols.Contains(key[0]))
        {
            char ch = key[0];
            key.Remove(0, 1);
            key.Insert(0, string.Format(@"\" + ch));
        }
        if (specialSymbols.Contains(key[key.Length - 1]))
        {
            char ch = key[key.Length - 1];
            key.Remove(key.Length - 1, 1);
            key.Insert(key.Length, string.Format(@"\" + ch));
        }
        return key + @"([\w ,.!]{2,6})" + key;
    }
}
