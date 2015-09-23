using System;
using System.Collections.Generic;
using System.Linq;
class CountOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        Dictionary<char, int> dict = new Dictionary<char, int>();
        List<char> chars = new List<char>();
        foreach (char letter in input)
        {
            if (letter != ' ')
            {
                if (dict.ContainsKey(letter))
                {
                    dict[letter]++;
                }
                else
                {
                    dict.Add(letter, 1);
                    chars.Add(letter);
                }
            }
        }
        chars.Sort();
        foreach (char letter in chars)
        {
            Console.WriteLine("{0} -> {1}", letter, dict[letter]);
        }
    }
}
