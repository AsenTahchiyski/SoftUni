using System;
using System.Collections.Generic;
class WinningNumbers
{
    static void Main()
    {
        string input = Console.ReadLine();
        int letSum = 0;
        char[] letters = input.ToCharArray();
        foreach (char letter in input)
        {
            letSum += (int)(char.ToUpper(letter) - 64);
        }
        List<int> ListWin = new List<int>();
        for (int first = 1; first <= 9; first++)
        {
            for (int second = 1; second <= 9; second++)
            {
                for (int third = 1; third <= 9; third++)
                {
                    if (first * second * third == letSum)
                    {
                        ListWin.Add(100 * first + 10 * second + third);
                    }
                }
            }
        }
        if (ListWin.Count == 0)
        {
            Console.WriteLine("No");
            return;
        }
        for (int FirstNum = 0; FirstNum < ListWin.Count; FirstNum++)
        {
            for (int SecondNum = 0; SecondNum < ListWin.Count; SecondNum++)
            {
                Console.WriteLine("{0}-{1}", ListWin[FirstNum], ListWin[SecondNum]);
            }
        }
    }
}
