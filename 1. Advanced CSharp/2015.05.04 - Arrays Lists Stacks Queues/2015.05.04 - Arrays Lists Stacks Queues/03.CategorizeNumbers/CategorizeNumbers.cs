// PLEASE note that the example output is wrong:
// "max: 93.03, sum: 96.403" should be 
// "max: 93, sum: 96.4" because we're supposed to print the results rounded to 2 decimal spaces
// and 93.003 != 93.03
using System;
class CategorizeNumbers
{
    static void Main()
    {
        Console.WriteLine("Please enter N floating-point numbers:");
        string[] input = Console.ReadLine().Split(' ');
        double?[] realNumbers = new double?[input.Length];
        double? realMin = double.MaxValue, realMax = double.MinValue, realSum = 0;
        double? naturMin = double.MaxValue, naturMax = double.MinValue, naturSum = 0;
        int realCount = 0, naturalCount = 0;
        double?[] naturalNumbers = new double?[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            realNumbers[i] = null;
            naturalNumbers[i] = null;
            if (double.Parse(input[i]) % 1 == 0)
            {
                naturalNumbers[i] = double.Parse(input[i]);
            }
            else
            {
                realNumbers[i] = double.Parse(input[i]);
            }
        }
        // print real numbers details
        Console.Write("[");
        for (int i = 0; i < input.Length; i++)
        {
            if (realNumbers[i] != null)
            {
                Console.Write(realNumbers[i] + ", ");
                if (realNumbers[i] < realMin)
	            {
		            realMin = realNumbers[i];
	            }
                if (realNumbers[i] > realMax)
	            {
		            realMax = realNumbers[i];
	            }
                realCount++;
                realSum += double.Parse(input[i]);
            }
        }
        Console.WriteLine("\b\b] -> min: {0:.##}, max: {1:.##}, sum: {2:.##}, avg: {3:.##}", realMin, realMax, realSum, realSum / realCount);
        // print natural numbers details
        Console.Write("[");
        for (int i = 0; i < input.Length; i++)
        {
            if (naturalNumbers[i] != null)
            {
                Console.Write(naturalNumbers[i] + ", ");
                if (naturalNumbers[i] < naturMin)
                {
                    naturMin = naturalNumbers[i];
                }
                if (naturalNumbers[i] > naturMax)
                {
                    naturMax = naturalNumbers[i];
                }
                naturalCount++;
                naturSum += double.Parse(input[i]);
            }
        }
        Console.WriteLine("\b\b] -> min: {0:.##}, max: {1:.##}, sum: {2:.##}, avg: {3:.##}", naturMin, naturMax, naturSum, naturSum / naturalCount);
    }
}
