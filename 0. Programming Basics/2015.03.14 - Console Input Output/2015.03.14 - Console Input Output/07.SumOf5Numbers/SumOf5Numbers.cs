using System;
class SumOf5Numbers
{
    static void Main()
    {
        Console.Write("Enter 5 numbers separated by a single space: ");
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        double sum = 0;
        foreach (var item in numbers)
        {
            sum += Convert.ToDouble(item);
        }
        Console.WriteLine("Sum = " + sum);
    }
}
