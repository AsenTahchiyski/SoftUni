using System;
using System.Collections.Generic;
class BitsKiller
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index = 1, counter = 0;
        string outputAll = "";
        List<string> outputsKilled = new List<string>();
        for (int num = 0; num < n; num++)
        {
            int number = int.Parse(Console.ReadLine());
            string bitsStr = Convert.ToString(number, 2).PadLeft(8, '0');
            char[] bits = bitsStr.ToCharArray();
            while (index < 8)
            {
                bits[index] = '-';
                index += step;
                counter++;
            }
            if (index > 7)
            {
                index -= 8;
                bitsStr = new string(bits);
                outputsKilled.Add(bitsStr);
            }
        }
        for (int i = 0; i < outputsKilled.Count; i++)
        {
            outputAll = String.Concat(outputAll, outputsKilled[i].Replace("-", ""));
        }
        if (outputAll.Length + 1 % 8 != 0)
        {
            outputAll = outputAll.PadRight(outputAll.Length + counter % 8, '0');
        }
        string printOut = null;
        for (int i = 1; i <= outputAll.Length; i++)
        {
            printOut = printOut + outputAll[i - 1];
            if (i % 8 == 0)
            {
                Console.WriteLine(Convert.ToInt32(printOut, 2));
                printOut = null;
            }
        }
    }
}
