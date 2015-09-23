using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class WordCount
{
    static void Main()
    {
        Dictionary<string, int> words = new Dictionary<string, int>();
        using (StreamReader readWords = new StreamReader("words.txt"))
        {
            string word = readWords.ReadLine().ToLower();
            string textLine;
            while (word != null)
            {
                if (!words.ContainsKey(word)) words.Add(word, 0);
                using (StreamReader readText = new StreamReader("text.txt"))
                {
                    textLine = readText.ReadLine().ToLower();
                    while (textLine != null)
                    {
                        if (Regex.IsMatch(textLine, word))
                        {
                            string pattern = @"\b" + word + @"\b";
                            int matches = Regex.Matches(textLine, pattern).Count;
                            words[word] += matches;
                        }
                        textLine = readText.ReadLine();
                        if (textLine != null) textLine = textLine.ToLower();
                    }
                }
                word = readWords.ReadLine();
                if (word != null) word = word.ToLower();
            }
        }
        foreach (var item in words)
        {
            Console.WriteLine("{0} - {1}", item.Key, item.Value);
        }
    }
}
