using System;
class LettersSymbolsNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int lettersSum = 0;
        int numbersSum = 0;
        int symbolsSum = 0;
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            foreach (char item in input)
            {
                if (item == ' ' || item == '\t' || item == '\r' || item == '\n') {}
                else if (char.IsLetter(item))
                {
                    lettersSum += (Convert.ToInt16(char.ToUpper(item)) - 64) * 10;
                }
                else if (char.IsDigit(item))
                {
                    numbersSum += (int)char.GetNumericValue(item) * 20;
                }
                else
                {
                    symbolsSum += 200;
                }
            }
        }
        Console.WriteLine("{0}\n{1}\n{2}", lettersSum, numbersSum, symbolsSum);
    }
}
