using System;
using System.Collections.Generic;
class Palindromes
{
    static void Main()
    {
        string text = Console.ReadLine();
        List<string> palindromes = new List<string>();
        char[] delimiters = { ' ', ',', '.', '?', '!' };
        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            if (word.Length % 2 == 0)
            {
                string leftHalf = word.Substring(0, word.Length / 2);
                string rightHalf = word.Substring(word.Length / 2, word.Length / 2);
                rightHalf = ReverseString(rightHalf);
                if (leftHalf == rightHalf)
                {
                    palindromes.Add(word);
                }
            }
            else if (word.Length == 1) palindromes.Add(word);
            else
            {
                int middleIndex = (word.Length - 1) / 2;
                string leftHalf = word.Substring(0, middleIndex);
                string rightHalf = word.Substring(middleIndex + 1, middleIndex);
                rightHalf = ReverseString(rightHalf);
                if (leftHalf == rightHalf)
                {
                    palindromes.Add(word);
                }
            }
        }
        palindromes.Sort();
        Console.WriteLine(string.Join(", ", palindromes));
    }
    public static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
