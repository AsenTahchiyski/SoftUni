using System;
using System.Linq;
class MatrixShuffling
{
    static void Main()
    {
        // build matrix
        Console.Write("Enter matrix rows: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Enter matrix columns: ");
        int cols = int.Parse(Console.ReadLine());
        string[,] matrix = new string[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("Enter element at row {0} and column {1}: ", i + 1, j + 1);
                matrix[i, j] = Console.ReadLine();
            }
        }
        // command input
        Console.Write("Enter a command: ");
        string[] commands = Console.ReadLine().Split(' ');
        int x1 = 0, x2 = 0, y1 = 0, y2 = 0;
        while (commands[0] != "END")
        {
            // check if command type is valid
        Start:
            while (commands[0].ToLower() != "swap" && commands.Length != 5)
            {
                if (commands[0] == "END")
                {
                    return;
                }
                Console.WriteLine("Wrong input, please try again <swap> <x1> <y1> <x2> <y2>");
                commands = Console.ReadLine().Split(' ');
            }
            x1 = int.Parse(commands[1]);
            y1 = int.Parse(commands[2]);
            x2 = int.Parse(commands[3]);
            y2 = int.Parse(commands[4]);
            // check if command parameters are within range
            while (x1 >= matrix.GetLength(0) && x2 >= matrix.GetLength(0) &&
                y1 >= matrix.GetLength(1) && y2 >= matrix.GetLength(1))
            {
                if (commands[0] == "END")
                {
                    return;
                }
                Console.WriteLine("Wrong input, please provide correct indexes.");
                commands = Console.ReadLine().Split(' ');
                goto Start;
            }
            // swap elements
            string temp = matrix[x1, y1];
            matrix[x1, y1] = matrix[x2, y2];
            matrix[x2, y2] = temp;
            // print matrix
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            // get next command
            commands = Console.ReadLine().Split(' ');
        }
    }
}
