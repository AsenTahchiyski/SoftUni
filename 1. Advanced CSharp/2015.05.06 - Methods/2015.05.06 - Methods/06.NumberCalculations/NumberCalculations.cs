using System;
class NumberCalculations
{
    static void Main()
    {
        // double
        Console.WriteLine("Enter (double) numbers separated by a single space:");
        string[] inputDouble = Console.ReadLine().Split(' ');
        double[] numbersDouble = new double[inputDouble.Length];
        for (int i = 0; i < inputDouble.Length; i++)
        {
            numbersDouble[i] = double.Parse(inputDouble[i]);
        }
        Console.WriteLine("Smallest element = " + Min(numbersDouble));
        Console.WriteLine("Biggest element = " + Max(numbersDouble));
        Console.WriteLine("Sum of elements = " + Sum(numbersDouble));
        Console.WriteLine("Average element = " + Avg(numbersDouble));
        Console.WriteLine("Product of elements = " + Product(numbersDouble));
        // int
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Enter (int) numbers separated by a single space:");
        string[] inputInt = Console.ReadLine().Split(' ');
        int[] numbersInt = new int[inputInt.Length];
        for (int i = 0; i < inputInt.Length; i++)
        {
            numbersInt[i] = int.Parse(inputInt[i]);
        }
        Console.WriteLine("Smallest element = " + Min(numbersInt));
        Console.WriteLine("Biggest element = " + Max(numbersInt));
        Console.WriteLine("Sum of elements = " + Sum(numbersInt));
        Console.WriteLine("Average element = " + Avg(numbersInt));
        Console.WriteLine("Product of elements = " + Product(numbersInt));
        // decimal
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Enter (decimal) numbers separated by a single space:");
        string[] inputDecimal = Console.ReadLine().Split(' ');
        decimal[] numbersDecimal = new decimal[inputDecimal.Length];
        for (int i = 0; i < inputDecimal.Length; i++)
        {
            numbersDecimal[i] = decimal.Parse(inputDecimal[i]);
        }
        Console.WriteLine("Smallest element = " + Min(numbersDecimal));
        Console.WriteLine("Biggest element = " + Max(numbersDecimal));
        Console.WriteLine("Sum of elements = " + Sum(numbersDecimal));
        Console.WriteLine("Average element = " + Avg(numbersDecimal));
        Console.WriteLine("Product of elements = " + Product(numbersDecimal));
    }
    // methods double
    static double Min(double[] numbers)
    {
        double minNum = double.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < minNum) minNum = numbers[i];
        }
        return minNum;
    }
    static double Max(double[] numbers)
    {
        double maxNum = double.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > maxNum) maxNum = numbers[i];
        }
        return maxNum;
    }
    static double Sum(double[] numbers)
    {
        double sumNum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sumNum += numbers[i];
        }
        return sumNum;
    }
    static double Avg(double[] numbers)
    {
        return Sum(numbers) / numbers.Length;
    }
    static double Product(double[] numbers)
    {
        double prodNum = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            prodNum *= numbers[i];
        }
        return prodNum;
    }
    // methods int
    static int Min(int[] numbers)
    {
        int minNum = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < minNum) minNum = numbers[i];
        }
        return minNum;
    }
    static int Max(int[] numbers)
    {
        int maxNum = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > maxNum) maxNum = numbers[i];
        }
        return maxNum;
    }
    static int Sum(int[] numbers)
    {
        int sumNum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sumNum += numbers[i];
        }
        return sumNum;
    }
    static int Avg(int[] numbers)
    {
        return Sum(numbers) / numbers.Length;
    }
    static int Product(int[] numbers)
    {
        int prodNum = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            prodNum *= numbers[i];
        }
        return prodNum;
    }
    // methods decimal
    static decimal Min(decimal[] numbers)
    {
        decimal minNum = decimal.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < minNum) minNum = numbers[i];
        }
        return minNum;
    }
    static decimal Max(decimal[] numbers)
    {
        decimal maxNum = decimal.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > maxNum) maxNum = numbers[i];
        }
        return maxNum;
    }
    static decimal Sum(decimal[] numbers)
    {
        decimal sumNum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sumNum += numbers[i];
        }
        return sumNum;
    }
    static decimal Avg(decimal[] numbers)
    {
        return Sum(numbers) / numbers.Length;
    }
    static decimal Product(decimal[] numbers)
    {
        decimal prodNum = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            prodNum *= numbers[i];
        }
        return prodNum;
    }
}
