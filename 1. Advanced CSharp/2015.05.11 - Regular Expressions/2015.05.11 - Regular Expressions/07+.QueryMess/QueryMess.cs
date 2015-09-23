using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class QueryMess
{
    static void Main()
    {
        Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        string input = Console.ReadLine();
        while (input != "END")
        {
            input = Regex.Replace(input, "%20", " ");
            input = Regex.Replace(input, @"\+", " ");
            input = Regex.Replace(input, @"\s+", " ");
            input = Regex.Replace(input, @"\?", "&");
            string pattern = @"([^=&]+)=([^&=]+)"; // <- EBojilova (100%); mine (55%) -> (\w+)\s?=\s?([\w:\/.]+\ ?\w*)
            MatchCollection matches = Regex.Matches(input, pattern);

            //string firstMatchWhole = matches[0].Groups[0].Value; // login=student
            //string firstMatchField = matches[0].Groups[1].Value; // login
            //string firstMatchValue = matches[0].Groups[2].Value; // student
            //string firstMatchEmpty = matches[0].Groups[3].Value; // <empty>

            //string secondMatchWhole = matches[1].Groups[0].Value; // password=student
            //string secondMatchField = matches[1].Groups[1].Value; // password
            //string secondMatchValue = matches[1].Groups[2].Value; // student
            //string secondMatchEmpty = matches[1].Groups[3].Value; // <empty>

            //string thirdMatchWhole = matches[2].Groups[0].Value; // IOoRE
            //string thirdMatchField = matches[2].Groups[1].Value; // IOoRE
            //string thirdMatchValue = matches[2].Groups[2].Value; // IOoRE
            //string thirdMatchEmpty = matches[2].Groups[3].Value; // IOoRE

            for (int i = 0; i < matches.Count; i++)
            {
                string field = matches[i].Groups[1].Value.Trim();
                string value = matches[i].Groups[2].Value.Trim();
                if (!dict.ContainsKey(field))
                {
                    dict.Add(field, new List<string>());
                }
                dict[field].Add(value);
            }
            foreach (var field in dict.Keys)
            {
                Console.Write("{0}=[{1}]", field, string.Join(", ", dict[field]));
            }
            dict.Clear();
            Console.WriteLine();
            input = Console.ReadLine();
        }
    }
}
