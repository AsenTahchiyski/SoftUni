using System;
class LongestWordInText
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ', ',', '.');
        int word = 0, lengthCheck = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].Length > lengthCheck)
            {
                word = i;
                lengthCheck = input[i].Length;
            }
        }
        Console.WriteLine(input[word]);
    }
}
