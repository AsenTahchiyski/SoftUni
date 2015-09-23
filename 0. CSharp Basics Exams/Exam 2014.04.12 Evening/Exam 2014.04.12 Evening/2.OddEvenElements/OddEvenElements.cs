using System;
class OddEvenElements
{
    static void Main()
    {
        string inputLine = Console.ReadLine();
        if (string.IsNullOrEmpty(inputLine))
        {
            Console.WriteLine("OddSum=No, OddMin=No, OddMax=No, EvenSum=No, EvenMin=No, EvenMax=No");
            return;
        }
        inputLine = inputLine.Replace(',', '.');
        string[] input = inputLine.Split(' ');
        double[] numbers = new double[input.Length];
        // note that 0, 2, 4 are considered odd and 1, 3, 5 - even
        double oddSum = 0, oddMin = double.MaxValue, oddMax = double.MinValue, evenSum = 0, evenMin = double.MaxValue, evenMax = double.MinValue;
        bool noEven = true, noOdd = true;
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = double.Parse(input[i]);
            if (i % 2 == 0) // considered as odd
            {
                oddSum += numbers[i];
                oddMin = numbers[i] < oddMin ? numbers[i] : oddMin;
                oddMax = numbers[i] > oddMax ? numbers[i] : oddMax;
                noOdd = false;
            }
            else // considered as even
            {
                evenSum += numbers[i];
                evenMin = numbers[i] < evenMin ? numbers[i] : evenMin;
                evenMax = numbers[i] > evenMax ? numbers[i] : evenMax;
                noEven = false;
            }
        }
        if (!noOdd)
        {
            Console.Write("OddSum={0:0.##}, OddMin={1:0.##}, OddMax={2:0.##}, ", oddSum, oddMin, oddMax);
        }
        if (noEven)
        {
            Console.WriteLine("EvenSum=No, EvenMin=No, EvenMax=No");
        }
        else
        {
            Console.WriteLine("EvenSum={0:0.##}, EvenMin={1:0.##}, EvenMax={2:0.##}", evenSum, evenMin, evenMax);
        }
    }
}
