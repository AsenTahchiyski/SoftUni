using System;
class SpiralMatrix
{
    static void Main()
    {
        Console.SetBufferSize(400, 400); 
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int currentNum = 1, layer = 0;
        // fill matrix with 0-s
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = 0;
            }
        }
        // fill layers
        for (int i = 0; i < (n + 1) / 2; i++)
        {
            currentNum = matrixLayer(n, layer++, currentNum, matrix);
        }
        // print matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,4}", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
    static int matrixLayer(int n, int layer, int currentNum, int[,] matrix)
    {
        // populate top row
        for (int i = 0 + layer; i < n - layer; i++)
        {
            matrix[0 + layer, i] = currentNum++;
        }
        // populate right side
        for (int i = 1 + layer; i < n - layer; i++)
        {
            matrix[i, n - 1 - layer] = currentNum++;
        }
        // populate bottom row
        for (int i = n - 2 - layer; i >= 0 + layer; i--)
        {
            matrix[n - 1 - layer, i] = currentNum++;
        }
        // populate left side
        for (int i = n - 2 - layer; i > 0 + layer; i--)
        {
            matrix[i, 0 + layer] = currentNum++;
        }
        return currentNum;
    }
}
