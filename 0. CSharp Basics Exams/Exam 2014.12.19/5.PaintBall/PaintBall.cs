using System;
class PaintBall
{
    static void Main()
    {
        string input;
        bool color = false;
        // create matrix & populate elements
        bool[,] matrix = new bool[10, 10];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                matrix[i, j] = true;
            }
        }
        // start entering input
        do
        {
            // separate input parameters
            input = Console.ReadLine();
            if (input == "End")
            {
                break;
            }
            string[] splitInput = new string[3];
            splitInput = input.Split(' ');
            int row = Convert.ToInt16(splitInput[0]);
            int col = Convert.ToInt16(splitInput[1]);
            int rad = Convert.ToInt16(splitInput[2]);    
            // set bits
            for (int i = 0; i <= 2 * rad; i++)
            {
                for (int j = 0; j <= 2 * rad; j++) 
                {
                    if ((row - rad + i) >= 0 && (9 - (col - rad + j)) >= 0 && (row - rad + i) < 10 && (9 - (col - rad + j)) < 10)
                    {
                        matrix[row - rad + i, 9 - (col - rad + j)] = color;
                    }
                }
            }
            color = !color;
        }
        while (true);
        // calculate row numbers
        string number = null;
        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (matrix[i, j] == true)
                {
                    number = string.Concat(number, 1);
                }
                else
                {
                    number = string.Concat(number, 0);
                }
                if (j == 9)
                {
                    sum += Convert.ToInt32(number, 2);
                    // Console.WriteLine(number, 2);
                    number = null;
                }
            }
        }
        Console.WriteLine(sum);
    }
}
