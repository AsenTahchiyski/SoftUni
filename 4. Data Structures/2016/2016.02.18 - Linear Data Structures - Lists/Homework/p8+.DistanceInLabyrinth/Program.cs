using System;
using System.Collections.Generic;

namespace p8_.DistanceInLabyrinth
{
    class Program
    {
        static void Main()
        {
            string startSymbol = "*";
            string freeCellSymbol = "0";
            string unreachableSymbol = "u";

            string[,] labyrinth = new string[6, 6] {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" } };

            Cell startPoint = FindStartingPoint(labyrinth, startSymbol);
            BFS(labyrinth, startPoint, freeCellSymbol);
            MarkUnreachableCells(labyrinth, freeCellSymbol, unreachableSymbol);
            PrintLabyrinth(labyrinth);
        }

        static Cell FindStartingPoint(string[,] maze, string startSymbol)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if (maze[row, col] == startSymbol)
                    {
                        return new Cell(row, col, 0);
                    }
                }
            }

            throw new InvalidOperationException("No starting point.");
        }

        static void BFS(string[,] maze, Cell start, string freeString)
        {
            var queue = new Queue<Cell>();
            var moves = new List<Cell>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {   
                var currentElement = queue.Dequeue();
                moves = GetPossibleMoves(maze, currentElement, freeString);
                foreach (var move in moves)
                {
                    move.Value++;
                    queue.Enqueue(move);
                    maze[move.Row, move.Col] = move.Value.ToString();
                }
            }
        }

        static List<Cell> GetPossibleMoves(string[,] maze, Cell currentCell, string freeSymbol)
        {
            var result = new List<Cell>();
            var totalRows = maze.GetLength(0);
            var totalCols = maze.GetLength(1);
            var currentRow = currentCell.Row;
            var currentCol = currentCell.Col;

            // check cell to the left
            if(currentCol > 0 && maze[currentRow, currentCol - 1] == freeSymbol)
            {
                result.Add(new Cell(currentRow, currentCol - 1, currentCell.Value));
            }
            // check cell above
            if (currentRow > 0 && maze[currentRow - 1, currentCol] == freeSymbol)
            {
                result.Add(new Cell(currentRow - 1, currentCol, currentCell.Value));
            }
            // check cell to the right
            if (currentCol < totalCols - 1 && maze[currentRow, currentCol + 1] == freeSymbol)
            {
                result.Add(new Cell(currentRow, currentCol + 1, currentCell.Value));
            }
            // check cell below
            if (currentRow < totalRows - 1 && maze[currentRow + 1, currentCol] == freeSymbol)
            {
                result.Add(new Cell(currentRow + 1, currentCol, currentCell.Value));
            }

            return result;
        }

        static void MarkUnreachableCells(string[,] maze, string freeSymbol, string unreachable)
        {
            var mazeRows = maze.GetLength(0);
            var mazeCols = maze.GetLength(1);
            for (int row = 0; row < mazeRows; row++)
            {
                for (int col = 0; col < mazeCols; col++)
                {
                    if (maze[row, col] == freeSymbol)
                    {
                        maze[row, col] = unreachable;
                    }
                }
            }
        }

        static void PrintLabyrinth(string[,] maze)
        {
            var mazeRows = maze.GetLength(0);
            var mazeCols = maze.GetLength(1);
            for (int row = 0; row < mazeRows; row++)
            {
                for (int col = 0; col < mazeCols; col++)
                {
                    Console.Write(maze[row, col].PadLeft(4));
                }

                Console.WriteLine();
            }
        }
    }
}
