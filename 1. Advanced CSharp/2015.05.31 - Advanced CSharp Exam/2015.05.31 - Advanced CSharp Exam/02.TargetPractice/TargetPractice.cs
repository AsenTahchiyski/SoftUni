using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class TargetPractice
{
    static void Main()
    {
        // get input
        string[] size = Regex.Split(Console.ReadLine(), @"\s+");
        int rows = int.Parse(size[0]);
        int cols = int.Parse(size[1]);
        string snake = Console.ReadLine();
        string[] shotInput = Regex.Split(Console.ReadLine(), @"\s+");
        int shotRow = int.Parse(shotInput[0]);
        int shotCol = int.Parse(shotInput[1]);
        int shotRad = int.Parse(shotInput[2]);
        // build matrix
        char[,] matrix = new char[rows, cols];
        matrix = FillMatrix(matrix, snake);
        matrix = ProcessShot(matrix, shotRow, shotCol, shotRad);
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            RunGravity(matrix, col);
        }
        PrintMatrix(matrix);
    }
    static char[,] FillMatrix(char[,] matrix, string snake)
    {
        int counter = 0;
        int rowCounter = 0; //<-- last row should always be even
        for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
        {
            if (rowCounter % 2 == 0) //<-- last row should always be even
            {
                for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                {
                    matrix[row, col] = snake[counter];
                    counter++;
                    if (counter == snake.Length) counter = 0;
                }
            }
            else
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = snake[counter];
                    counter++;
                    if (counter == snake.Length) counter = 0;
                }
            }
            rowCounter++; // <--
        }
        return matrix;
    }
    static char[,] ProcessShot(char[,] matrix, int shotRow, int shotCol, int shotRad)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (isCellShot(row, col, shotRow, shotCol, shotRad)) matrix[row, col] = ' ';
            }
        }
        return matrix;
    }
    static bool isCellShot(int row, int col, int shotRow, int shotCol, int shotRad)
    {
        bool valid = (col - shotCol) * (col - shotCol) + (row - shotRow) * (row - shotRow) <= shotRad * shotRad;
        return valid;
    }
    static void RunGravity(char[,] matrix, int col)
    {
        while (true)
        {
            bool hasFallen = false;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                char topChar = matrix[row - 1, col];
                char currentChar = matrix[row, col];
                if (currentChar == ' ' && topChar != ' ')
                {
                    matrix[row, col] = topChar;
                    matrix[row - 1, col] = ' ';
                    hasFallen = true;
                }
            }
            if (!hasFallen)
            {
                break;
            }
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
