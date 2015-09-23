using System;
using System.Collections.Generic;
class StrMatrixRotation
{
    static void Main()
    {
        char[] delimiters = { '(', ')' };
        string[] command = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        List<string> strings = new List<string>();
        int longestLine = 0;
        string line = Console.ReadLine(); 
        // get lines
        while (line.ToLower() != "end")
        {
            strings.Add(line);
            if (longestLine < line.Length) longestLine = line.Length;
            line = Console.ReadLine();
        }
        for (int i = 0; i < strings.Count; i++)
        {
            strings[i] += new string(' ', longestLine - strings[i].Length);
        }
        // create matrix
        char[,] matrix = new char[strings.Count, longestLine];
        for (int row = 0; row < strings.Count; row++)
        {
            for (int col = 0; col < longestLine; col++)
            {
                matrix[row, col] = strings[row][col];
            }
        }
        // process command
        int rotation = int.Parse(command[1]);
        if (rotation > 360) rotation %= 360;
        char[,] rotatedMa3x;
        switch (rotation)
        {
            case 0: PrintMatrix(matrix); break;
            case 90:
                rotatedMa3x = new char[longestLine, strings.Count];
                for (int i = 0; i < strings.Count; i++)
                {
                    for (int j = 0; j < longestLine; j++)
                    {
                        rotatedMa3x[j, strings.Count - i - 1] = matrix[i, j];
                    }
                }
                PrintMatrix(rotatedMa3x);
                break;
            case 180:
                rotatedMa3x = new char[strings.Count, longestLine];
                for (int i = 0; i < strings.Count; i++)
                {
                    for (int j = 0; j < longestLine; j++)
                    {
                        rotatedMa3x[strings.Count - i - 1, longestLine - j - 1] = matrix[i, j];
                    }
                }
                PrintMatrix(rotatedMa3x);
                break;
            case 270:
                rotatedMa3x = new char[longestLine, strings.Count];
                for (int i = 0; i < strings.Count; i++)
                {
                    for (int j = 0; j < longestLine; j++)
                    {
                        rotatedMa3x[longestLine - 1 - j, i] = matrix[i, j];
                    }
                }
                PrintMatrix(rotatedMa3x);
                break;
            case 360: PrintMatrix(matrix); break;
            default: break;
        }
    }
    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
