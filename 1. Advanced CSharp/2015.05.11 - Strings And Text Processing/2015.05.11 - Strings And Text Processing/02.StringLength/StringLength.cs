using System;
class StringLength
{
    static void Main()
    {
        string input = Console.ReadLine().PadRight(20, '*');
        Console.WriteLine(input.Substring(0, 20));
    }
}
