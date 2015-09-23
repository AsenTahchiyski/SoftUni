using System;
class CountSubstringOccur
{
    static void Main()
    {
        string text = Console.ReadLine().ToLower();
        string search = Console.ReadLine().ToLower();
        int occurences = 0;
        for (int i = 0; i <= text.Length - search.Length; i++)
        {
            if (text.Substring(i, search.Length).Contains(search))
            {
                occurences++;
            }
        }
        Console.WriteLine(occurences);
    }
}
