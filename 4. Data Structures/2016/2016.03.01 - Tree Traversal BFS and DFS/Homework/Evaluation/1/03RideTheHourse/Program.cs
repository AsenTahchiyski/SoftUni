namespace _03RideTheHourse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int rows = 0;

        private static int cols = 0;

        private static int[,] matrix;

        static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());

            matrix = new int[rows, cols];
            matrix[startRow, startCol] = 1;
            var pointValue = new Dictionary<Tuple<int, int>, int>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    var point = new Tuple<int, int>(row, col);
                    int value = matrix[row, col];
                    pointValue.Add(point, value);
                }
            }

            Console.WriteLine("Output:");
            var numbersOfMiddleColumn = VisitAllCells(pointValue, startRow, startCol);
            foreach (var number in numbersOfMiddleColumn)
            {
                Console.WriteLine(number);
            }
            
            //PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(" " + matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static int[] VisitAllCells(Dictionary<Tuple<int, int>, int> pointValue, int startRow, int startCol)
        {
            var startCell = new Tuple<int, int>(startRow, startCol);
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(startCell);

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();                                         
                MarkDirection(currentCell, pointValue, 2, 1, queue);
                MarkDirection(currentCell, pointValue, 2, -1, queue);
                MarkDirection(currentCell, pointValue, -2, 1, queue);
                MarkDirection(currentCell, pointValue, -2, -1, queue);
                MarkDirection(currentCell, pointValue, -1, 2, queue);
                MarkDirection(currentCell, pointValue, 1, 2, queue);
                MarkDirection(currentCell, pointValue, -1, -2, queue);
                MarkDirection(currentCell, pointValue, 1, -2, queue);
            }

            return GiveTheNumbersFromMiddleColumn();
        }

        private static void MarkDirection(
            Tuple<int, int> currentCell, 
            Dictionary<Tuple<int, int>, int> pointValue, 
            int deltaRow, int deltaCol, 
            Queue<Tuple<int, int>> queue)
        {
            int newRow = currentCell.Item1 + deltaRow;
            int newCol = currentCell.Item2 + deltaCol;
            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && matrix[newRow, newCol] == 0)
            {
                var cell = pointValue.FirstOrDefault(e => e.Key.Item1 == newRow && e.Key.Item2 == newCol).Key;
                pointValue[cell] = matrix[currentCell.Item1, currentCell.Item2] + 1;
                matrix[cell.Item1, cell.Item2] = pointValue[cell];
                queue.Enqueue(new Tuple<int, int>(newRow, newCol));
            }            
        }

        private static int[] GiveTheNumbersFromMiddleColumn()
        {
            int[] middleColumn = new int[rows];
            int middleCol = cols / 2;
            for (int col = middleCol; col <= middleCol; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    middleColumn[row] = matrix[row, col];
                }
            }

            return middleColumn;
        }
    }
}
