namespace RotatingWalkMatrix
{
    using System;

    public static class RotatingWalkInMatrix
    {
        public class Position
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Position(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }
        
        private const int MinMatrixSize = 0;
        private const int MaxMatrixSize = 100;

        public static void Main()
        {
            Console.Write("Enter a number between {0} and {1}: ", MinMatrixSize, MaxMatrixSize);
            string input = Console.ReadLine();
            int matrixSize;

            while (!int.TryParse(input, out matrixSize) || matrixSize <= MinMatrixSize || matrixSize >= MaxMatrixSize)
            {
                //Console.Write("You have entered an incorrect number, try again: ");
                //input = Console.ReadLine();

                // in order to run the unit test, above 2 lines are commented and the one below added
                throw new ArgumentOutOfRangeException("size", "Invalid size.");
            }

            int[,] matrix = new int[matrixSize, matrixSize];
            int currentCellValue = 1;
            int row = 0;
            int col = 0;
            int directionX = 1;
            int directionY = 1;

            currentCellValue = PerformMatrixWalk(matrix, row, col, currentCellValue, directionX, directionY);

            PrintMatrix(matrix);

            Console.WriteLine(new string('-', 20)); // added to separate the matrices

            if (matrixSize > 4) // no empty cells remain for matrix sizes 1 to 4, therefore an exception is thrown if we try accessing the next empty cell
            {
                Position nextEmptyCell = FindEmptyCell(matrix);
                row = nextEmptyCell.X;
                col = nextEmptyCell.Y;

                if (row != 0 && col != 0)
                {
                    directionX = 1;
                    directionY = 1;

                    PerformMatrixWalk(matrix, row, col, currentCellValue, directionX, directionY);
                }
            }

            PrintMatrix(matrix);
        }

        // fixed
        public static int PerformMatrixWalk(int[,] matrix, int row, int col, int currentCellValue, int directionX, int directionY)
        {
            while (true)
            {
                matrix[row, col] = currentCellValue;

                if (!IsMoveAllowed(matrix, row, col))
                {
                    return currentCellValue;
                } 

                if (IsNextPositionInvalid(row, col, directionX, directionY, matrix))

                    while (IsNextPositionInvalid(row, col, directionX, directionY, matrix))
                    {
                        Position newDirection = ChangeWalkDirection(directionX, directionY);
                        directionX = newDirection.X;
                        directionY = newDirection.Y;
                    }

                row += directionX;
                col += directionY;
                currentCellValue++;
            }
        }

        // fixed, tested
        public static bool IsNextPositionInvalid(int row, int col, int directionX, int directionY, int[,] matrix)
        {
            int matrixSize = matrix.GetLength(0);

            bool isNextPositionInvalid = 
                row + directionX >= matrixSize || 
                row + directionX < 0 ||
                col + directionY >= matrixSize ||
                col + directionY < 0 ||
                matrix[row + directionX, col + directionY] != 0;

            return isNextPositionInvalid;
        }

        // fixed, tested
        public static Position ChangeWalkDirection(int positionChangeX, int positionChangeY) // current cell position change
        {
            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int directionToMoveTo = 0;

            for (int i = 0; i < 8; i++)
            {
                if (directionsX[i] == positionChangeX && directionsY[i] == positionChangeY)
                {
                    directionToMoveTo = i;
                    break;
                }
            }

            if (directionToMoveTo == 7) // no direction change
            {
                positionChangeX = directionsX[0];
                positionChangeY = directionsY[0];
                return new Position(positionChangeX, positionChangeY); // the change in position fitted in one variable, not an actual position
            }

            positionChangeX = directionsX[directionToMoveTo + 1];
            positionChangeY = directionsY[directionToMoveTo + 1];
            return new Position(positionChangeX, positionChangeY);
        }

        // fixed, tested
        public static Position FindEmptyCell(int[,] matrix) 
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix", "Matrix should not be null.");
            }
            
            int matrixSize = matrix.GetLength(0);

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (matrix[row, col] == 0)
                    {
                        return new Position(row, col);
                    }
                }
            }

            return null;
        }

        // fixed, tested
        public static bool IsMoveAllowed(int[,] matrix, int currentRow, int currentCol)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix", "Matrix should not be null.");
            }

            int matrixSize = matrix.GetLength(0);

            int[] directionsX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] directionsY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (currentRow + directionsX[i] >= matrixSize || currentRow + directionsX[i] < 0)
                {
                    directionsX[i] = 0;
                }

                if (currentCol + directionsY[i] >= matrixSize || currentCol + directionsY[i] < 0)
                {
                    directionsY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (matrix[currentRow + directionsX[i], currentCol + directionsY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        // fixed, tested
        public static void PrintMatrix(int[,] matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix", "Matrix should not be null.");
            }
            
            int matrixSize = matrix.GetLength(0);

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
