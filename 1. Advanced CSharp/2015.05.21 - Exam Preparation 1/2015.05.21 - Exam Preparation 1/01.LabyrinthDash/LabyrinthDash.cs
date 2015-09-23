// Files and Streams Problem 12*
using System;
using System.Collections.Generic;
using System.Linq;
class LabyrinthDash
{
    static void Main()
    {
        const string obstacles = "*#@";
        int n = int.Parse(Console.ReadLine());
        char[][] board = new char[n][];
        for (int i = 0; i < n; i++)
        {
            board[i] = Console.ReadLine().ToCharArray();
        }
        char[] moves = Console.ReadLine().ToCharArray();
        int lives = 3;
        int row = 0;
        int col = 0;
        int movesMade = 0;
        foreach (var direction in moves)
        {
            int prevRow = row;
            int prevCol = col;
            switch (direction)
            {
                case '<': col--; break;
                case '>': col++; break;
                case 'v': row++; break;
                case '^': row--; break;
                default: break;
            }
            if (!isCellInsideBoard(row, col, board) || board[row][col] == ' ')
            {
                Console.WriteLine("Fell off a cliff! Game Over!");
                movesMade++;
                break;
            }
            else if (board[row][col] == '_' || board[row][col] == '|')
            {
                Console.WriteLine("Bumped a wall.");
                row = prevRow;
                col = prevCol;
            }
            else if (obstacles.Contains(board[row][col].ToString()))
            {
                lives--;
                movesMade++;
                Console.WriteLine("Ouch! That hurt! Lives left: {0}", lives);
                if (lives <= 0)
                {
                    Console.WriteLine("No lives left! Game Over!");
                    break;
                }
            }
            else if (board[row][col] == '$')
            {
                board[row][col] = '.';
                lives++;
                movesMade++;
                Console.WriteLine("Awesome! Lives left: {0}", lives);
            }
            else
            {
                movesMade++;
                Console.WriteLine("Made a move!");
            }
            char currentCell = board[row][col];
        }
        Console.WriteLine("Total moves made: {0}", movesMade);
    }
    private static bool isCellInsideBoard(int row, int col, char[][] board)
    {
        bool isRowInsideBoard = row >= 0 && row < board.Length;
        if (!isRowInsideBoard)
        {
            return false;
        }
        bool isColInRange = col >= 0 && col < board[row].Length;
        return isColInRange;
    }
}
