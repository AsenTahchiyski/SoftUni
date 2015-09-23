using System;
using System.Collections.Generic;
class ProgrammerDNA
{
    static char letter;
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        letter = char.Parse(Console.ReadLine());
        for (int i = 1; i <= rows; i++)
        {
            printRow(i);
            Console.WriteLine();
        }
    }
    static void printRow(int row)
    {
        if (row > 7)
        {
            row = row % 7 == 0 ? row = 1 : row % 7;
        }
        switch (row)
        {
            case 1:
                Console.Write("...");
                Console.Write(letter); letter++; if (letter > 71) letter = (char)65;
                Console.Write("...");
                break;
            case 2:
                Console.Write("..");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(letter); letter++; if (letter > 71) letter = (char)65;
                }
                Console.Write("..");
                break;
            case 3:
                Console.Write(".");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(letter); letter++; if (letter > 71) letter = (char)65;
                }
                Console.Write(".");
                break;
            case 4: 
                for (int i = 0; i < 7; i++)
                {
                    Console.Write(letter); letter++; if (letter > 71) letter = (char)65;
                }
                break;
            case 5:
                Console.Write(".");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(letter); letter++; if (letter > 71) letter = (char)65;
                }
                Console.Write(".");
                break;
            case 6:
                Console.Write("..");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write(letter); letter++; if (letter > 71) letter = (char)65;
                }
                Console.Write("..");
                break;
            case 7:
                Console.Write("...");
                Console.Write(letter); letter++; if (letter > 71) letter = (char)65;
                Console.Write("...");
                break;
            default:
                break;
        }
    }
}
