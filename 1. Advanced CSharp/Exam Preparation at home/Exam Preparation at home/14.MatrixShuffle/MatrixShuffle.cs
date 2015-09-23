using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class MatrixShuffle
{
    static int stringIndex = 0;
    static int elementsCounter = 0;
    static void Main()
    {
        int matrixSize = int.Parse(Console.ReadLine());
        string textInput = Console.ReadLine();
        char[,] matrix = new char[matrixSize, matrixSize];
        FillMatrixSpiralLayer(textInput, matrix, 0);
        //PrintMatrix(matrix);
        string result = ExtractSquares(matrix);
        if (isStringPalindrome(result))
        {
            Console.WriteLine("<div style='background-color:#4FE000'>{0}</div>", result);
        }
        else
        {
            Console.WriteLine("<div style='background-color:#E0000F'>{0}</div>", result);
        }
    }
    static char[,] FillMatrixSpiralLayer(string text, char[,] matrix, int subMatrix)
    {
        int n = matrix.GetLength(0);
        int startRow = subMatrix;
        int startCol = subMatrix;
        // fill top
        for (int col = startCol; col < n - startCol; col++)
        {
            if (stringIndex < text.Length)
            {
                matrix[startRow, col] = text[stringIndex];
                stringIndex++;
            }
            else
            {
                matrix[startRow, col] = ' ';
            }
            elementsCounter++;
        }
        // fill right side
        for (int row = startRow + 1; row < n - startRow; row++)
        {
            if (stringIndex < text.Length)
            {
                matrix[row, n - (startCol + 1)] = text[stringIndex];
                stringIndex++;
            }
            else
            {
                matrix[row, startCol] = ' ';
            }
            elementsCounter++;
        }
        // fill bottom
        for (int col = n - (startCol + 2); col >= startCol; col--)
        {
            if (stringIndex < text.Length)
            {
                matrix[n - (startRow + 1), col] = text[stringIndex];
                stringIndex++;
            }
            else
            {
                matrix[n - (startRow + 1), col] = ' ';
            }
            elementsCounter++;
        }
        // fill left side
        for (int row = n - (startRow + 2); row > startRow; row--)
        {
            if (stringIndex < text.Length)
            {
                matrix[row, startCol] = text[stringIndex];
                stringIndex++;
            }
            else
            {
                matrix[row, startCol] = ' ';
            }
            elementsCounter++;
        }
        while (n * n - elementsCounter > 0)
        {
            FillMatrixSpiralLayer(text, matrix, subMatrix + 1);
        }
        return matrix;
    }
    static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
    static string ExtractSquares(char[,] matrix) // chessboard distribution
    {
        StringBuilder resultEven = new StringBuilder();
        StringBuilder resultOdd = new StringBuilder();
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if ((row + col) % 2 == 0)
                {
                    resultEven.Append(matrix[row, col]);
                }
                else
                {
                    resultOdd.Append(matrix[row, col]);
                }
            }
        }
        return resultEven.ToString() + resultOdd.ToString();
    }
    static bool isStringPalindrome(string check) // not counting spaces
    {
        StringBuilder checkNoSpaces = new StringBuilder();
        foreach (char ch in check)
        {
            if (char.IsLetterOrDigit(ch)) checkNoSpaces.Append(char.ToLower(ch));
        }
        StringBuilder reversed = new StringBuilder();
        for (int i = checkNoSpaces.Length - 1; i >= 0; i--)
        {
            reversed.Append(checkNoSpaces[i]);
        }
        if (checkNoSpaces.ToString() == reversed.ToString()) return true;
        else return false;
    }
}
