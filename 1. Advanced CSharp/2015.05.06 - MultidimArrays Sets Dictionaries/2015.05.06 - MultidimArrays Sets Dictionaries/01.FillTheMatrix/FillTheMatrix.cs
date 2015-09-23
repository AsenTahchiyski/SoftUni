using System;
class FillTheMatrix
{
    static void Main()
    {
        Console.Write("Enter size of matrix: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        // Pattern A
        Console.WriteLine(new string('-', 30));
        matrix = PatternA(n);
        Console.WriteLine("Pattern A");
        Console.WriteLine(new string('-', 30));
        PrintMatrix(matrix);
        // Pattern B
        Console.WriteLine(new string('-', 30));
        matrix = PatternB(n);
        Console.WriteLine("Pattern B");
        Console.WriteLine(new string('-', 30));
        PrintMatrix(matrix);
    }
    static int[,] PatternA(int n)
    {
        int[,] matrix = new int[n, n];
        int currentValue = 1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[j, i] = currentValue;
                currentValue++;
            }
        }
        return matrix;
    }
    static int[,] PatternB(int n)
    {
        int[,] matrix = new int[n, n];
        int currentValue = 1;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[j, i] = currentValue;
                    currentValue++;
                }
            }
            else
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    matrix[j, i] = currentValue;
                    currentValue++;
                }
            }
        }
        return matrix;
    }
    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,4} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
