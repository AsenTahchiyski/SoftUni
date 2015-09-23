namespace ConsoleApplication1
{
    using System;

    public class MatrixMultiplication
    {
        internal static void Main()
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var multiplicationResult = Multiply2X2Matrices(firstMatrix, secondMatrix);

            for (int row = 0; row < multiplicationResult.GetLength(0); row++)
            {
                for (int col = 0; col < multiplicationResult.GetLength(1); col++)
                {
                    Console.Write(multiplicationResult[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] Multiply2X2Matrices(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new InvalidOperationException("Invalid input matrix dimensions.");
            }

            var resultColumns = firstMatrix.GetLength(1);
            var resultMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

            for (int row = 0; row < resultMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < resultMatrix.GetLength(1); col++)
                {
                    for (int secondMatrixColElement = 0; secondMatrixColElement < resultColumns; secondMatrixColElement++)
                    {
                        resultMatrix[row, col] += firstMatrix[row, secondMatrixColElement] * secondMatrix[secondMatrixColElement, col];
                    }
                }
            }
                
            return resultMatrix;
        }
    }
}