using System;
using System.Collections.Generic;
class MagicDates
{
    static void Main()
    {
        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int magicWeight = int.Parse(Console.ReadLine());
        string format = "ddMMyyyy";
        string outFormat = "dd-MM-yyyy";
        bool noMagicDates = true;
        for (int year = startYear; year <= endYear; year++)
        {
            DateTime start = new DateTime(year, 01, 01);
            DateTime end = new DateTime(year, 12, 31);
            for (DateTime day = start; day <= end; day = day.AddDays(1))
            {
                string getDigits = day.ToString(format);
                int[] digits = new int[8];
                for (int i = 0; i < 8; i++)
                {
                    digits[i] = (int)char.GetNumericValue(getDigits[i]);
                }
                int weightCheck = 0;
                for (int num1 = 0; num1 < 8; num1++)
                {
                    for (int num2 = 0; num2 < 8; num2++)
                    {
                        if (num1 < num2)
                        {
                            weightCheck += digits[num1] * digits[num2];
                        }
                    }
                }
                if (weightCheck == magicWeight)
                {
                    Console.WriteLine(day.ToString(outFormat));
                    noMagicDates = false;
                }
            }
        }
        if (noMagicDates)
        {
            Console.WriteLine("No");
        }
    }
}
