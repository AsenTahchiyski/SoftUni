using System;
using System.Collections.Generic;
using System.Linq;
class PlusRemove
{
    static List<int> rowsPlus = new List<int>();
    static List<int> colsPlus = new List<int>();
    static void Main()
    {
        List<List<char>> matrix = new List<List<char>>();
        string input = Console.ReadLine();
        int rows = 0;
        while (input.ToUpper() != "END")
        {
            matrix.Add(input.ToCharArray().ToList());
            rows++;
            input = Console.ReadLine();
        }
        for (int row = 1; row < rows - 1; row++)
        {
            for (int col = 1; col < matrix[row].Count - 1; col++)
            {
                CheckForPlus(matrix, row, col, rows);
            }
        }
        // set + to '\0'
        for (int row = 0, col = 0; row < rowsPlus.Count; row++, col++)
        {
            matrix[rowsPlus[row]][colsPlus[col]] = '\0';
        }
        // print result
        foreach (var row in matrix)
        {
            foreach (var symbol in row)
            {
                if (symbol != '\0') Console.Write(symbol);
            }
            Console.WriteLine();
        }
    }
    static void CheckForPlus(List<List<char>> matrix, int row, int col, int rows)
    {
        char charCheck = matrix[row][col];
        if (charCheck == '\0')
        {
            return;
        }
        if (char.IsLetter(charCheck))
        {
            charCheck = char.ToUpper(matrix[row][col]);
            if (col - 1 >= 0 && col + 1 < matrix[row].Count && matrix[row - 1].Count > col && matrix[row + 1].Count > col)
            {
                if (char.ToUpper(matrix[row][col - 1]) == charCheck && char.ToUpper(matrix[row][col + 1]) == charCheck &&
                    char.ToUpper(matrix[row - 1][col]) == charCheck && char.ToUpper(matrix[row + 1][col]) == charCheck)
                {
                    CollectPlusIndexes(matrix, row, col, rows);
                }
            }
        }
        else
        {
            if (col - 1 >= 0 && col + 1 < matrix[row].Count && row - 1 >= 0 && row + 1 < rows)
            {
                if (matrix[row][col - 1] == charCheck && matrix[row][col + 1] == charCheck &&
                    matrix[row - 1][col] == charCheck && matrix[row + 1][col] == charCheck)
                {
                    CollectPlusIndexes(matrix, row, col, rows);
                }
            }
        }
        return;
    }
    static void CollectPlusIndexes(List<List<char>> matrix, int row, int col, int rows)
    {
        rowsPlus.Add(row);
        colsPlus.Add(col);
        rowsPlus.Add(row);
        colsPlus.Add(col - 1);
        rowsPlus.Add(row);
        colsPlus.Add(col + 1);
        rowsPlus.Add(row - 1);
        colsPlus.Add(col);
        rowsPlus.Add(row + 1);
        colsPlus.Add(col);
    }
}
