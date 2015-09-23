using System;
class Numerology
{
    static void Main()
    {
        string input = Console.ReadLine(); // "14.03.1990 Panayot";
        string[] splitInput = input.Split(' ');
        string[] date = splitInput[0].Split('.');
        long dateMultiply = Convert.ToInt16(date[0]) * Convert.ToInt16(date[1]) * Convert.ToInt16(date[2]);
        if (Convert.ToInt32(date[1]) % 2 != 0)
        {
            dateMultiply = dateMultiply * dateMultiply;
        }
        int nameSum = 0;
        for (int letter = 0; letter < splitInput[1].Length; letter++)
        {
            char character = Convert.ToChar(splitInput[1].Substring(letter, 1));
            if (char.IsLetter(character) == true)
            {
                if (char.IsUpper(character) == true)
                {
                    nameSum += (char.ToUpper(character) - 64) * 2;
                }
                else
                {
                    nameSum += char.ToUpper(character) - 64;
                }
            }
            else if (char.IsDigit(character) == true)
            {
               nameSum += Convert.ToInt32(char.GetNumericValue(character));
            }
        }
        long digitsToSum = dateMultiply + nameSum;
        while (digitsToSum > 13)
        {
            string digits = digitsToSum.ToString();
            digitsToSum = 0;
            for (int digit = 0; digit < digits.Length; digit++)
            {
                digitsToSum += Convert.ToInt32(digits.Substring(digit, 1));
            }
        }
        Console.WriteLine(digitsToSum);
    }
}
