using System;
using System.Collections.Generic;
using System.Linq;
class FiveSpecialLetters
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());
        char[] letters = { 'a', 'b', 'c', 'd', 'e' };
        bool noSequence = true;
        List<char> combo = new List<char>();
        for (int a = 0; a < 5; a++)
        {
            for (int b = 0; b < 5; b++)
            {
                for (int c = 0; c < 5; c++)
                {
                    for (int d = 0; d < 5; d++)
                    {
                        for (int e = 0; e < 5; e++)
                        {
                            combo.Add(letters[a]);
                            combo.Add(letters[b]);
                            combo.Add(letters[c]);
                            combo.Add(letters[d]);
                            combo.Add(letters[e]);
                            List<char> distinct = combo.Distinct().ToList();
                            int weight = 0;
                            for (int i = 0; i < distinct.Count; i++)
                            {
                                weight += getWeight(distinct[i]) * (i + 1);
                            }
                            if (weight >= start && weight <= end)
                            {
                                Console.Write(letters[a].ToString() + letters[b] + letters[c] + letters[d] + letters[e] + " ");
                                noSequence = false;
                            }
                            combo.Clear();
                        }
                    }
                }
            }
        }
        if (noSequence)
        {
            Console.Write("No");
        }
        Console.WriteLine();
    }
    static int getWeight(char letter)
    {
        switch (letter)
        {
            case 'a': return 5;
            case 'b': return -12;
            case 'c': return 47;
            case 'd': return 7;
            case 'e': return -32;
            default: break;
        }
        return 0;
    }
}