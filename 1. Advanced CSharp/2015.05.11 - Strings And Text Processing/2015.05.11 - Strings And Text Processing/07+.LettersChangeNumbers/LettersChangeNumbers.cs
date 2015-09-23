using System;
class LettersChangeNumbers
{
    static void Main()
    {
        char[] delimiters = { ' ', ',', '.', '!', '\t', '\n' };
        string[] sequences = Console.ReadLine().Trim().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        decimal result = 0;
        foreach (string seq in sequences)
        {
            char firstLetter = seq[0];
            char secondLetter = seq[seq.Length - 1];
            decimal tempResult = 0;
            long number = long.Parse(seq.Substring(1, seq.Length - 2));
            if (char.IsUpper(firstLetter)) tempResult = (decimal)number / (firstLetter - 64);
            else tempResult = (decimal)number * (firstLetter - 96);
            if (char.IsUpper(secondLetter)) tempResult -= (secondLetter - 64);
            else tempResult += (secondLetter - 96);
            result += tempResult;
        }
        Console.WriteLine("{0:F2}", result);
    }
}
