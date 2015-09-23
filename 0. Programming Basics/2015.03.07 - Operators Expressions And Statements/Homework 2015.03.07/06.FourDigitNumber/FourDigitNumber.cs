using System;
class FourDigitNumber
{
    static void Main()
    {
        Console.Write("Enter 4-digit number: ");
        string input = Console.ReadLine();
        int sum = 0;
        int number = int.Parse(input);
        for (int i = 0; i < 4; i++)
        {
            sum += number % 10;
            number /= 10;
        }
        Console.WriteLine("Sum of digits = {0}", sum);
        Console.WriteLine("Reversed: {3}{2}{1}{0}\nLast digit first: {3}{0}{1}{2}\n 2 and 3 digits swapped: {0}{2}{1}{3}", input[0], input[1], input[2], input[3]);
    }
}
