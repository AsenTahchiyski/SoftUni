using System;
class XBits
{
    static void Main()
    {
        int[] numbers = new int[8];
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        string[] BinNums = new string[8];
        for (int i = 0; i < 8; i++)
        {
            BinNums[i] = Convert.ToString(numbers[i], 2).PadLeft(31, '0');
        }
        char[,] matrix = new char[8, 31];
        for (int i = 0; i < 8; i++)
        {
            char[] temp = BinNums[i].ToCharArray();
            for (int j = 0; j < 31; j++)
            {
                matrix[i, j] = temp[j];
            }
        }
        int xbits = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 29; j++)
            {
                if (matrix[i, j] == '1' && matrix[i, j + 1] == '0' && matrix[i, j + 2] == '1' &&
                    matrix[i + 1, j] == '0' && matrix[i + 1, j + 1] == '1' && matrix[i + 1, j + 2] == '0' &&
                    matrix[i + 2, j] == '1' && matrix[i + 2, j + 1] == '0' && matrix[i + 2, j + 2] == '1')
                {
                    xbits++;
                }
            }
        }
        Console.WriteLine(xbits);
    }
}
