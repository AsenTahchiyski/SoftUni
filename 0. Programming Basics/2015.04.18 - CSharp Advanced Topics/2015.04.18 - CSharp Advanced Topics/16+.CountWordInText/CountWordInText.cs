using System;
using System.IO;
class CountWordInText
{
    static void Main()
    {
        string word = Console.ReadLine().ToLower();
        int counter = 0;
        Console.SetIn(new StreamReader(Console.OpenStandardInput(8192)));
        string[] input = Console.ReadLine().Split(' ', '\"', ',', '.', '!', ')', '(', '@', '/');
        for (int i = 0; i < input.Length; i++)
        {
            string currentWord = input[i].ToLower();
            if (currentWord == word)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}
