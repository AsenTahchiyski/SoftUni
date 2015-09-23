using System;
class TicTacToePower
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int number = int.Parse(Console.ReadLine());
        int[,] board = new int[3, 3];
        int[,] index = new int[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = number;
                index[i, j] = board[i, j] - board[0, 0] + 1;
                number++;
            }
        }
        Console.WriteLine((long)Math.Pow(board[y, x], index[y, x]));
    }
}
