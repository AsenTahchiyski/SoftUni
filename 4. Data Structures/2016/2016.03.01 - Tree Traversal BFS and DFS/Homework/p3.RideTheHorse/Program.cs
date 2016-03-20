using System;
using System.Collections.Generic;

namespace p3.RideTheHorse
{
    class Program
    {
        static int[,] board;
        static int stepsCounter = 1;
        static int rows, cols;

        static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            board = new int[rows, cols];
            int startRow = int.Parse(Console.ReadLine());
            int startCol = int.Parse(Console.ReadLine());
            BFS(startRow, startCol);
            Console.WriteLine('-');
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(board[i, cols / 2]);
            }
        }

        static void BFS(int row, int col)
        {
            Queue<Cell> cellsQ = new Queue<Cell>();
            Cell startCell = new Cell(row, col, stepsCounter++);
            cellsQ.Enqueue(startCell);
            while(cellsQ.Count > 0)
            {
                var currentCell = cellsQ.Dequeue();
                SetBoardCellValue(currentCell);
                var availablePositions = GetPossibleNextMoves(currentCell);
                foreach (Cell cell in availablePositions)
                {
                    cell.Value = currentCell.Value + 1;
                    cellsQ.Enqueue(cell);
                }
            }
        }

        static List<Cell> cellsToVisit = new List<Cell>();
        static IList<Cell> GetPossibleNextMoves(Cell cell)
        {
            cellsToVisit.Clear();
            AddNewCellToQ(cell, -1, -2);
            AddNewCellToQ(cell, -2, -1);
            AddNewCellToQ(cell, -2, +1);
            AddNewCellToQ(cell, -1, +2);
            AddNewCellToQ(cell, +1, +2);
            AddNewCellToQ(cell, +2, +1);
            AddNewCellToQ(cell, +2, -1);
            AddNewCellToQ(cell, +1, -2);
            return cellsToVisit;
        }

        static bool CellIsInAvailable(Cell cell, int deltaRow, int deltaCol)
        {
            int newRow = cell.Row + deltaRow;
            int newCol = cell.Col + deltaCol;
            bool rowIsValid = newRow >= 0 && newRow < rows;
            bool colIsValid = newCol >= 0 && newCol < cols;
            bool visited = true;
            if (rowIsValid && colIsValid)
            {
                visited = board[newRow, newCol] != 0;
            }

            return !visited;
        }

        static void AddNewCellToQ(Cell cell, int deltaRow, int deltaCol)
        {
            if (CellIsInAvailable(cell, deltaRow, deltaCol))
            {
                cellsToVisit.Add(new Cell(cell.Row + deltaRow, cell.Col + deltaCol, stepsCounter));
            }
        }

        static void SetBoardCellValue(Cell cell)
        {
            board[cell.Row, cell.Col] = cell.Value;
        }
    }

    class Cell
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public int Value { get; set; }

        public Cell(int row, int col, int value = 0)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }
    }
}
