using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class ITVillage
{
    static void Main()
    {
        // build board
        string boardData = Console.ReadLine();
        string[] boardRows = boardData.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
        string[,] board = new string[4, 4];
        int totalInns = 0;
        for (int i = 0; i < 4; i++)
        {
            string[] rowChars = boardRows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < 4; j++)
            {
                board[i, j] = rowChars[j];
                if (rowChars[j] == "I") totalInns++;
            }
        }
        // get starting position
        string[] startPosition = Console.ReadLine().Split(' ');
        Player player = new Player();
        player.CurrentRow = int.Parse(startPosition[0]) - 1;
        player.CurrentCol = int.Parse(startPosition[1]) - 1;
        // roll dice
        string[] diceResult;
        diceResult = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);    
        foreach (var roll in diceResult)
        {
            if (player.SkipTurn == 0)
            {
                if (player.InnsOwned > 0) player.Coins += 20 * player.InnsOwned;
                MovePlayerPosition(player, int.Parse(roll));
                PerformFieldAction(player, board);
            }
            else player.SkipTurn--;
            // check for game end conditions
            if (player.Coins < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
                return;
            }
            else if (player.InnsOwned == totalInns)
            {
                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>", player.Coins);
                return;
            }
        }
        Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", player.Coins);
    }
    static void MovePlayerPosition(Player player, int diceRoll)
    {
        int movesLeft = diceRoll;
        while (movesLeft > 0)
        {
            if (movesLeft > 0 && player.CurrentRow == 0)
            {
                while (movesLeft > 0 && player.CurrentCol < 3)
                {
                    player.CurrentCol++;
                    movesLeft--;
                }
            }
            if (movesLeft > 0 && player.CurrentCol == 3)
            {
                while (movesLeft > 0 && player.CurrentRow < 3)
                {
                    player.CurrentRow++;
                    movesLeft--;
                }
            }
            if (movesLeft > 0 && player.CurrentRow == 3)
            {
                while (movesLeft > 0 && player.CurrentCol > 0)
                {
                    player.CurrentCol--;
                    movesLeft--;
                }
            }
            if (movesLeft > 0 && player.CurrentCol == 0)
            {
                while (movesLeft > 0 && player.CurrentRow > 0)
                {
                    player.CurrentRow--;
                    movesLeft--;
                }
            }
        }
    }
    static void PerformFieldAction(Player player, string[,] board)
    {
        switch (board[player.CurrentRow, player.CurrentCol])
        {
            case "P": player.Coins -= 5; break;
            case "I":
                if (player.Coins >= 100)
                {
                    player.Coins -= 100;
                    player.InnsOwned++;
                }
                else player.Coins -= 10;
                break;
            case "F": player.Coins += 20; break;
            case "S": player.SkipTurn += 2; break;
            case "V": player.Coins *= 10; break;
            case "N": 
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
                Environment.Exit(0);
                break;
            default: break;
        }
    }
}
class Player
{
    public int Coins = 50;
    public int InnsOwned = 0;
    public int CurrentRow;
    public int CurrentCol;
    public int SkipTurn = 0;
}
