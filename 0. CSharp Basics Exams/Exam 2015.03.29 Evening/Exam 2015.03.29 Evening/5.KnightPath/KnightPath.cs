using System;
class KnightPath
{
    
    static void Main()
    {
        int[] rows = { 1, 0, 0, 0, 0, 0, 0, 0 };
        string command = "";
        int[] currentPos = { 0, 0 }; // row - col
        while (command != "stop")
        {
            command = Console.ReadLine();
            if (currentPos[1] != getNewPosition(command, currentPos)[1])
            {
                currentPos = getNewPosition(command, currentPos);
                if (((rows[currentPos[0]] >> currentPos[1]) & 1) == 0)
                {
                    rows[currentPos[0]] |= 1 << currentPos[1];
                }
                else if (((rows[currentPos[0]] >> currentPos[1]) & 1) == 1)
                {
                    rows[currentPos[0]] &= ~(1 << currentPos[1]);
                }
            }
        }
        int counter = 0;
        for (int i = 0; i < 8; i++)
        {
            if (rows[i] != 0)
            {
                Console.WriteLine(rows[i]);
                counter++;
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("[Board is empty]");
        }
    }
    static int[] getNewPosition(string command, int[] currentPos)
    {
        int[] nextPos = { currentPos[0], currentPos[1] };
        switch (command)
        {
            case "left up":
                if (nextPos[0] - 1 >= 0 && nextPos[0] - 1 < 8 && nextPos[1] + 2 >= 0 && nextPos[1] + 2 < 8)
                {
                    nextPos[0]--;
                    nextPos[1] += 2;
                }
                break;
            case "left down":
                if (nextPos[0] + 1 >= 0 && nextPos[0] + 1 < 8 && nextPos[1] + 2 >= 0 && nextPos[1] + 2 < 8)
                {
                    nextPos[0]++;
                    nextPos[1] += 2;
                }
                break;
            case "right up":
                if (nextPos[0] - 1 >= 0 && nextPos[0] - 1 < 8 && nextPos[1] - 2 >= 0 && nextPos[1] - 2 < 8)
                {
                    nextPos[0]--;
                    nextPos[1] -= 2;
                }
                break;
            case "right down":
                if (nextPos[0] + 1 >= 0 && nextPos[0] + 1 < 8 && nextPos[1] - 2 >= 0 && nextPos[1] - 2 < 8)
                {
                    nextPos[0]++;
                    nextPos[1] -= 2;
                }
                break;
            case "up left":
                if (nextPos[0] - 2 >= 0 && nextPos[0] - 2 < 8 && nextPos[1] + 1 >= 0 && nextPos[1] + 1 < 8)
                {
                    nextPos[0] -= 2;
                    nextPos[1]++;
                }
                break;
            case "up right":
                if (nextPos[0] - 2 >= 0 && nextPos[0] - 2 < 8 && nextPos[1] - 1 >= 0 && nextPos[1] - 1 < 8)
                {
                    nextPos[0] -= 2;
                    nextPos[1]--;
                }
                break;
            case "down left":
                if (nextPos[0] + 2 >= 0 && nextPos[0] + 2 < 8 && nextPos[1] + 1 >= 0 && nextPos[1] + 1 < 8)
                {
                    nextPos[0] += 2;
                    nextPos[1]++;
                }
                break;
            case "down right":
                if (nextPos[0] + 2 >= 0 && nextPos[0] + 2 < 8 && nextPos[1] - 1 >= 0 && nextPos[1] - 1 < 8)
                {
                    nextPos[0] += 2;
                    nextPos[1]--;
                }
                break;
            default:
                break;
        }
        return nextPos;
    }
}
