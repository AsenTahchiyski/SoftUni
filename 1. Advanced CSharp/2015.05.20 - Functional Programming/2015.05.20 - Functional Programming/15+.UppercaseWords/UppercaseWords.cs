// not fully ok
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class UppercaseWords
{
    static int ReplacementIndex = 0;
    static void Main()
    {
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] words = Regex.Split(input, "\\W+");
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    string newWord = TransformUppercaseWord(word);
                    input = ReplaceWord(input, word, newWord);
                    ReplacementIndex += newWord.Length + 1;
                }
            }
            input = input.Replace("<", "&lt;");
            input = input.Replace(">", "&gt;");
            Console.WriteLine(input);
            ReplacementIndex = 0;
            input = Console.ReadLine();
        }
    }
    static string TransformUppercaseWord(string word)
    {
        if (!string.IsNullOrEmpty(word))
        {
            if (word.All(c => char.IsUpper(c) || char.IsDigit(c)))
            {
                if (word == Reverse(word))
                {
                    StringBuilder newWord = new StringBuilder();
                    foreach (var chr in word)
                    {
                        if (char.IsLetter(chr)) newWord.Append(chr, 2);
                        else if (char.IsDigit(chr)) newWord.Append(chr);
                    }
                    word = newWord.ToString();
                }
                else
                {
                    word = Reverse(word);
                }
            }
            else if (word.All(c => char.IsUpper(c) || char.IsDigit(c)))
            {
                if (char.IsDigit(word[0]))
                {
                    int digit = (int)char.GetNumericValue(word[0]);
                    string tempWord = word.Substring(1);
                    StringBuilder newWord = new StringBuilder();
                    foreach (var chr in tempWord)
                    {
                        if (char.IsLetter(chr)) newWord.Append(chr, 2);
                        else if (char.IsDigit(chr)) newWord.Append(chr);
                    }
                    word = digit + newWord.ToString();
                }
                else if (char.IsDigit(word[word.Length - 1]))
                {
                    int digit = (int)char.GetNumericValue(word[word.Length - 1]);
                    string tempWord = word.Substring(0, word.Length - 1);
                    StringBuilder newWord = new StringBuilder();
                    foreach (var chr in tempWord)
                    {
                        if (char.IsLetter(chr)) newWord.Append(chr, 2);
                        else if (char.IsDigit(chr)) newWord.Append(chr);
                    }
                    word = newWord.ToString() + digit;
                }
            }
        }
        return word;
    }
    static string Reverse(string word)
    {
        char[] temp = word.ToCharArray();
        word = new string(temp.Reverse().ToArray());
        return word;
    }
    
    static string ReplaceWord(string text, string word, string newWord)
    {
        Regex rgx = new Regex(string.Format(@"(\b|[0-9])({0})(\b|[0-9])", word));
        string result = rgx.Replace(text, newWord, 1, ReplacementIndex);
        return result;
    }
}
