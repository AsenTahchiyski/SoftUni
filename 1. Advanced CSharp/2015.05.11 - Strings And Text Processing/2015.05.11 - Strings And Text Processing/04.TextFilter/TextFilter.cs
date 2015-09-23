using System;
using System.Text;
class TextFilter
{
    static void Main()
    {
        char[] delimiters = { ',', ' ' };
        string[] words = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder text = new StringBuilder();
        text.Append(Console.ReadLine());
        foreach (string word in words)
        {
            text.Replace(word, new string('*', word.Length));
        }
        Console.WriteLine(text.ToString());
    }
}
