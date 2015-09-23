using System;
class Illuminati
{
    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        int secretCode = 0, vowelsNum = 0;
        foreach (char letter in input)
        {
            int letterValue = 0;
            char checkLetter = char.ToUpper(letter);
            switch (checkLetter)
            {
                case 'A': letterValue = 65; vowelsNum++; break;
                case 'E': letterValue = 69; vowelsNum++; break;
                case 'I': letterValue = 73; vowelsNum++; break;
                case 'O': letterValue = 79; vowelsNum++; break;
                case 'U': letterValue = 85; vowelsNum++; break;
                default: letterValue = 0; break;
            }
            secretCode += letterValue;
        }
        Console.WriteLine("{0}\n{1}", vowelsNum, secretCode);
    }
}
