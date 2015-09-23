using System;
class TerroristsWin
{
    static void Main()
    {
        char[] text = Console.ReadLine().ToCharArray();
        int indexStart = 0, indexEnd = 0, counter = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '|')
            {
                counter++;
                if (counter == 1)
                {
                    indexStart = i;    
                }
                else if(counter == 2)
                {
                    indexEnd = i;
                    counter = 0;
                    int bombPower = GetBombPower(text, indexStart, indexEnd);
                    int start = indexStart - bombPower >= 0 ? indexStart - bombPower : 0;
                    int end = (indexEnd + bombPower) > (text.Length - 1) ? (text.Length - 1) : (indexEnd + bombPower);
                    for (int dot = start; dot <= end; dot++)
                    {
                        text[dot] = '.';
                    }
                }
            }
        }
        Console.WriteLine(string.Join("", text));
    }
    static int GetBombPower(char[] text, int indexStart, int indexEnd)
    {
        int charSum = 0;
        for (int i = indexStart + 1; i <= indexEnd - 1; i++)
        {
            charSum += text[i];
        }
        return charSum % 10;
    }
}
