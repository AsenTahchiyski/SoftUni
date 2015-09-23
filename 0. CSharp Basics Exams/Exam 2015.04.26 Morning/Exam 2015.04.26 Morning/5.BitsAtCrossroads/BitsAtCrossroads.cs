using System;
class BitsAtCrossroads
{
    static uint[] board;
    static int n;
    static int crossroads = 0;
    static void Main()
    {
        n = int.Parse(Console.ReadLine());
        board = new uint[n];
        string command = Console.ReadLine();
        while (command.ToLower() != "end")
        {
            crossroads++;
            string[] parameters = command.Split(' ');
            uint line = uint.Parse(parameters[0]);
            int bit = int.Parse(parameters[1]);
            leftDown(line, bit);
            leftUp(line, bit);
            rightDown(line, bit);
            rightUp(line, bit);
            command = Console.ReadLine();
        }
        foreach (var item in board)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine(crossroads);
    }
    static void leftUp(uint line, int bit)
    {
        uint i = line;
        int j = bit;
        while (i >= 0 && j < n)
        {
            if ((((board[i] >> j) & 1) == 1) && j != bit)
            {
                crossroads++;
            }
            board[i] |= ((uint)1 << j);
            if (i != 0)
            {
                i--;
            }
            else
            {
                return;
            }
            j++;
        }
    }
    static void leftDown(uint line, int bit)
    {
        uint i = line;
        int j = bit;
        while (i < n && j < n)
        {
            if ((((board[i] >> j) & 1) == 1) && j != bit)
            {
                crossroads++;
            }
            board[i] |= (uint)1 << j;
            i++;
            j++;
        }
    }
    static void rightUp(uint line, int bit)
    {
        uint i = line;
        int j = bit;
        while (i >= 0 && j >= 0)
        {
            if ((((board[i] >> j) & 1) == 1) && j != bit)
            {
                crossroads++;
            }
            board[i] |= (uint)1 << j;
            if (i != 0)
            {
                i--;
            }
            else
            {
                return;
            }
            j--;
        }
    }
    static void rightDown(uint line, int bit)
    {
        uint i = line;
        int j = bit;
        while (i < n && j >= 0)
        {
            if ((((board[i] >> j) & 1) == 1) && j != bit)
            {
                crossroads++;
            }
            board[i] |= (uint)1 << j;
            i++;
            j--;
        }
    }
}
