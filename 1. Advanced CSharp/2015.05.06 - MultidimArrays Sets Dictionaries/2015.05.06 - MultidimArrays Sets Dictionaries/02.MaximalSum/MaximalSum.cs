using System;
using System.Linq;
class MaximalSum
{
    static void Main()
    {
        Console.Write("Enter rows and columns separated by a space: ");
        int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int rows = size[0];
        int cols = size[1] + 1;
        // define and fill matrix
        int[,] matrix = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            Console.Write("Enter row number {1} & {0} numbers: ", cols - 1, i + 1);
            int[] temp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = temp[j];
            }
        }
        // check for biggest sum
        int biggestSum = int.MinValue;
        int[] indexBiggest = new int[2];
        for (int i = 0; i <= rows - 3; i++)
        {
            for (int j = 1; j <= cols - 3; j++)
            {
                if (GetElementsSum(matrix, i, j) > biggestSum)
                {
                    biggestSum = GetElementsSum(matrix, i, j);
                    indexBiggest[0] = i;
                    indexBiggest[1] = j;
                }
            }
        }
        // print sum and submatrix
        Console.WriteLine("Sum = " + biggestSum);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write("{0,4} ", matrix[i + indexBiggest[0], j + indexBiggest[1]]);
            }
            Console.WriteLine();
        }
    }
    static int GetElementsSum(int[,] matrix, int i, int j)
    {
        //j++;
        int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] +
                  matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] +
                  matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
        return sum;
    }
}
