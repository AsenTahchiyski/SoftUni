using System;
class ChessboardGame
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        int[,] board = new int[n, n];
        int index = 0;
        // fill matrix
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                if (char.IsLetterOrDigit(input[index]))
                {
                    board[col, row] = input[index];
                }
                else
                {
                    board[col, row] = 0;
                }
                index++;
                if (index >= input.Length)
                {
                    index = 0;
                    goto Next;
                }
            }
        }
        Next:
        // calc scores
        int blackScore = 0, whiteScore = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (j % 2 == 0)
                {
                    if (i % 2 == 0)
                    {
                        if (board[i, j] > 64 && board[i, j] < 91)
                        {
                            whiteScore += board[i, j];
                        }
                        else
                        {
                            blackScore += board[i, j];
                        }
                    }
                    else
                    {
                        if (board[i, j] > 64 && board[i, j] < 91)
                        {
                            blackScore += board[i, j];
                        }
                        else
                        {
                            whiteScore += board[i, j];
                        }
                    }
                }
                else
                {
                    if (i % 2 == 1)
                    {
                        if (board[i, j] > 64 && board[i, j] < 91)
                        {
                            whiteScore += board[i, j];
                        }
                        else
                        {
                            blackScore += board[i, j];
                        }
                    }
                    else
                    {
                        if (board[i, j] > 64 && board[i, j] < 91)
                        {
                            blackScore += board[i, j];
                        }
                        else
                        {
                            whiteScore += board[i, j];
                        }
                    }
                }
            }
        }
        if (blackScore > whiteScore)
        {
            Console.WriteLine("The winner is: black team");
            Console.WriteLine(blackScore - whiteScore);
        }
        else if (whiteScore > blackScore)
        {
            Console.WriteLine("The winner is: white team");
            Console.WriteLine(whiteScore - blackScore);
        }
        else
        {
            Console.WriteLine("Equal result: {0}", blackScore);
        }
    }
}
