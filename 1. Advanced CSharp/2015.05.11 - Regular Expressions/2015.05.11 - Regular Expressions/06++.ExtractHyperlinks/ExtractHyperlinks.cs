using System;
using System.Text;
using System.Text.RegularExpressions;
class ExtractHyperlinks
{
    static void Main()
    {
        string pattern = @"<a[\s\w=""'\,)\(-]*href\s*=\s*[""']*([\w:.\/\(\)#!\-'\s""]+['""]*[\w:.\/\(\)#\s]+)[""']['""\>\s]";
        string input;
        StringBuilder input1Line = new StringBuilder();
        while ((input = Console.ReadLine()) != "END")
        {
            input1Line.Append(input);
        }
        MatchCollection urlMatches = Regex.Matches(input1Line.ToString(), pattern);
        for (int i = 0; i < urlMatches.Count; i++)
        {
            for (int j = 1; j < urlMatches[0].Groups.Count; j++)
            {
                string url = urlMatches[i].Groups[j].Value;
                if (url[url.Length - 1] == ' ')
                {
                    url = url.Substring(0, url.Length - 2);
                }
                Console.WriteLine(url);
            }
        }
    }
}
