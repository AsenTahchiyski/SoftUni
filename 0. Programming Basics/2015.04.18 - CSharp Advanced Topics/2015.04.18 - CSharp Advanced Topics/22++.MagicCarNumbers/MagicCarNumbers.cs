using System;
class MagicCarNumbers
{
    static void Main()
    {
        int weight = int.Parse(Console.ReadLine());
        string letters = "ABCEHKMPTX";
        int magicCarNumbers = 0;
        for (int i = 0; i < 10000; i++)
        {
            string digits = i.ToString().PadLeft(4, '0'); // "CAaaaaXY", "CAabbbXY", "CAaaabXY", "CAaabbXY", "CAababXY" and "CAabbaXY"
            if ((digits[0] == digits[1] && digits[0] == digits[2] && digits[0] == digits[3]) || 
                (digits[1] == digits[2] && digits[1] == digits[3]) ||
                (digits[0] == digits[1] && digits[0] == digits[2]) ||
                (digits[0] == digits[1] && digits[2] == digits[3]) ||
                (digits[0] == digits[2] && digits[1] == digits[3]) ||
                (digits[0] == digits[3] && digits[1] == digits[2]))
            {
                int numbersWeight = (int)(char.GetNumericValue(digits[0]) + char.GetNumericValue(digits[1])
                + char.GetNumericValue(digits[2]) + char.GetNumericValue(digits[3]));
                int lettersWeight = 0;
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        lettersWeight = getLetterWeight(letters[j]) + getLetterWeight(letters[k]);
                        if (lettersWeight + numbersWeight + 40 == weight) // CA weight = 30 + 10
                        {
                            magicCarNumbers++; //Console.Write("CA{0}{1}{2}, ", digits, letters[j], letters[k]);
                        }
                    }
                }
            }
        }
        Console.WriteLine(magicCarNumbers);
    }
    static int getLetterWeight(char letter)
    {
        switch (letter)
        {
            case 'A': return 10;
            case 'B': return 20;
            case 'C': return 30;
            case 'E': return 50;
            case 'H': return 80;
            case 'K': return 110;
            case 'M': return 130;
            case 'P': return 160;
            case 'T': return 200;
            case 'X': return 240;
            default: return 0;
        }
    }
}
