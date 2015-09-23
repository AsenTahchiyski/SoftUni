using System;
class TextBombardment
{
    static void Main()
    {
        string input = Console.ReadLine(); // "Well this problem is gonna be a ride."
        int width = int.Parse(Console.ReadLine()); // 10
        int rows = 1 + input.Length / width; // 4
        string bombCols = Console.ReadLine(); // "1 3 7 9"
        // populate matrix
        char[,] matrix = new char[rows, width];
        char[] inputSplit = new char[input.Length];
        inputSplit = input.ToCharArray();
        int counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (counter < input.Length)
                {
                    matrix[i, j] = inputSplit[counter];
                    counter++;
                }
            }
        }
        // get columns
        string[] bombedCol = bombCols.Split(' ');
        // bomb cells
        for (int bomb = 0; bomb < bombedCol.Length; bomb++)
        {
            counter = 0;
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row, Convert.ToInt16(bombedCol[bomb])] == ' ' && counter != row)
	            {
                    row = rows;
	            }
                else if (matrix[row, Convert.ToInt16(bombedCol[bomb])] == ' ' && counter == row)
                {
                    counter++;
                }
                else
                {
                    matrix[row, Convert.ToInt16(bombedCol[bomb])] = ' ';
                }
            }
        }
        // get final string
        string result = null;
        counter = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (counter < input.Length)
                {
                    result = string.Concat(result, matrix[i, j]);
                    counter++;
                }
            }
        }
        Console.WriteLine(result);
    } 
}
