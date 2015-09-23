using System;
class EnterNumbers
{
    static void Main()
    {
        for (int i = 0; i < 10; i++)
        {
            try
            {
                ReadNumber(1, 100);
            }
            catch (ArgumentException)
            {
                Console.Write("Invalid number.");
                if (i < 9) Console.WriteLine(" Try again.");
                else Console.WriteLine();
            }
            catch (FormatException)
            {
                Console.Write("Invalid number.");
                if (i < 9) Console.WriteLine(" Try again.");
                else Console.WriteLine();
            }
            catch (OverflowException)
            {
                Console.Write("Invalid number.");
                if (i < 9) Console.WriteLine(" Try again.");
                else Console.WriteLine();
            }
        }
    }
    static void ReadNumber(int start, int end)
    {
        Console.Write("Please enter an integer number between {0} and {1}: ", start, end);
        int number = int.Parse(Console.ReadLine());
        if (number < start || number > end)
        {
            throw new ArgumentOutOfRangeException(string.Format("Number is out of range {0} - {1}", start, end));
        }
    }
}
