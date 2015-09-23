using System;
class ExtractURLsFromText
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ', ',');
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i].Length > 6)
            {
                if (input[i][4] == ':' || input[i][3] == '.')
                {
                    Console.WriteLine(input[i].TrimEnd('.', ','));
                }    
            }
        }
    }
}
