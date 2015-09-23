using System;
class UnicodeChars
{
    static void Main()
    {
        string text = Console.ReadLine();
        foreach (char symbol in text)
        {
            Console.Write("\\{0:X4}", (int)symbol);
        }
        Console.WriteLine();
    }
}
