using System;
using System.Linq;
using System.Collections.Generic;
class LargestRectangle
{
    static int biggestLength = 0;
    static void Main()
    {
        string input = Console.ReadLine();
        List<string> list = new List<string>{ input };
        while (input != "END")
	    {
            list.Add(input);
            input = Console.ReadLine(); 
	    }
        int elementsCount = list[0].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Count();
        string[,] matrix = new string[list.Count, elementsCount];
        int rowCounter = 0;
        foreach (string line in list)
        {
            string[] temp = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < temp.Length; i++)
            {
                matrix[rowCounter, i] = temp[i];
            }
            rowCounter++;
        }
        int biggestArea = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (GetArea(matrix, row, col) > biggestArea) biggestArea = GetArea(matrix, row, col);
            }
        }
        Console.WriteLine(biggestArea);
    }
    static int GetArea(string[,] matrix, int row, int col)
    {
        int topLength = 0, bottomLength = 0, leftHeight = 0, rightHeight = 0;
        for (int i = col; i < matrix.GetLength(1); i++)
        {
            if (row + 1 < matrix.GetLength(0) &&
                matrix[row, i] == matrix[row, col] && matrix[row + 1, i] == matrix[row, col]) topLength++;
            else break;
        }
        for (int i = row; i < matrix.GetLength(0); i++)
        {
            if (col + 1 < matrix.GetLength(1) &&
                matrix[i, col] == matrix[row, col] && matrix[i, col + 1] == matrix[row, col]) leftHeight++;
            else break;
        }
        for (int i = col; i < matrix.GetLength(1); i++)
        {
            if ((row + leftHeight) < matrix.GetLength(0) && col + 1 < matrix.GetLength(1) &&
                matrix[row + leftHeight, i] == matrix[row, col] &&
                matrix[i, col + 1] == matrix[row, col]) bottomLength++;
            else break;
        }
        if (topLength != bottomLength) return 0;
        for (int i = row; i < matrix.GetLength(0); i++)
        {
            if (col + topLength < matrix.GetLength(1) && row + leftHeight < matrix.GetLength(0) &&
                matrix[i, col + topLength] == matrix[row, col] && 
                matrix[row + leftHeight, col + bottomLength] == matrix[row, col]) rightHeight++;
            else break;
        }
        if (leftHeight == rightHeight)
        {
            biggestLength = topLength;
            return leftHeight * topLength;
        }
        else return 0;
    }
}
