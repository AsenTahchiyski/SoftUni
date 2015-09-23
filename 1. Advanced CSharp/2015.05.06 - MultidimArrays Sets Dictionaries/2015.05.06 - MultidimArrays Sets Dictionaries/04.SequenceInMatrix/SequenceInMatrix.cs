using System;
class SequenceInMatrix
{
    static string longestSeqElement = null;
    static int longestSequence = 0;
    static void Main()
    {
        // build matrix
        Console.Write("Enter matrix rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter matrix columns: ");
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("Enter element at row {0} and column {1}: ", i + 1, j + 1);
                matrix[i, j] = Console.ReadLine();
            }
        }
        // perform checks
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (GetEqualElementsDiagonal(matrix, i, j) > longestSequence)
                {
                    longestSequence = GetEqualElementsDiagonal(matrix, i, j);
                }
                if (GetEqualElementsHorizontal(matrix, i, j) > longestSequence)
                {
                    longestSequence = GetEqualElementsHorizontal(matrix, i, j);
                }
                if (GetEqualElementsVertical(matrix, i, j) > longestSequence)
                {
                    longestSequence = GetEqualElementsVertical(matrix, i, j);
                }
            }
        }
        // print output
        Console.WriteLine(new string('-', 30));
        Console.Write("Longest sequence of elements is: ");
        for (int i = 0; i < longestSequence - 1; i++)
        {
            Console.Write(longestSeqElement + " ");
        }
        Console.WriteLine();
    }
    static int GetEqualElementsDiagonal(string[,] matrix, int row, int col)
    {
        int equalElements = 1;
        string element = matrix[row, col];
        int currentRow = row, currentCol = col;
        while (currentRow < matrix.GetLength(0) && currentCol < matrix.GetLength(1))
        {
            if (matrix[currentRow, currentCol] == element)
            {
                equalElements++;
                currentRow++;
                currentCol++;
            }
            else break;
        }
        if (equalElements > longestSequence)
        {
            longestSeqElement = element;
        }
        return equalElements;
    }
    static int GetEqualElementsHorizontal(string[,] matrix, int row, int col)
    {
        int equalElements = 1;
        string element = matrix[row, col];
        int currentRow = row, currentCol = col;
        while (currentRow < matrix.GetLength(0) && currentCol < matrix.GetLength(1))
        {
            if (matrix[currentRow, currentCol] == element)
            {
                equalElements++;
                currentCol++;
            }
            else break;
        }
        if (equalElements > longestSequence)
        {
            longestSeqElement = element;
        }
        return equalElements;
    }
    static int GetEqualElementsVertical(string[,] matrix, int row, int col)
    {
        int equalElements = 1;
        string element = matrix[row, col];
        int currentRow = row, currentCol = col;
        while (currentRow < matrix.GetLength(0) && currentCol < matrix.GetLength(1))
        {
            if (matrix[currentRow, currentCol] == element)
            {
                equalElements++;
                currentRow++;
            }
            else break;
        }
        if (equalElements > longestSequence)
        {
            longestSeqElement = element;
        }
        return equalElements;
    }
}
