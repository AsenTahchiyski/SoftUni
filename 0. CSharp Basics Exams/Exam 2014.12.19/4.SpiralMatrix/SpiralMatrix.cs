using System;
class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int startingN = n;
        string keyword = Console.ReadLine();
        string[,] matrix = new string[n, n];
        // define char vector
        char[] chars = new char[keyword.Length];
        chars = keyword.ToCharArray();
        int charPosition = 0;
        // fill string vector
        string[] keywordStringVector = new string[keyword.Length];
        for (int i = 0; i < keyword.Length; i++)
		{
			keywordStringVector[i] = Convert.ToString(chars[i]);
		}
        // fill matrix
        int matrixCharPos = 0;
        for (int subMatrix = 0; subMatrix <= (startingN + 1) / 2; subMatrix++)
        {
            // fill submatrices
            // fill top row
            for (int i = 0; i < n; i++)
            {
                if (matrixCharPos >= keyword.Length)
                {
                    matrixCharPos = 0;
                }
                matrix[0 + subMatrix, i + subMatrix] = keywordStringVector[matrixCharPos];
                matrixCharPos++;
            }
            // fill right middle
            for (int i = 0; i < n - 2; i++)
            {
                if (matrixCharPos >= keyword.Length)
                {
                    matrixCharPos = 0;
                }
                matrix[i + 1 + subMatrix, n - 1 + subMatrix] = keywordStringVector[matrixCharPos];
                matrixCharPos++;
            }
            // fill bottom row
            for (int i = n - 1; i >= 0; i--)
            {
                if (matrixCharPos >= keyword.Length)
                {
                    matrixCharPos = 0;
                }
                matrix[n - 1 + subMatrix, i + subMatrix] = keywordStringVector[matrixCharPos];
                matrixCharPos++;
            }
            // fill left middle
            for (int i = n - 2; i >= 1; i--)
            {
                if (matrixCharPos >= keyword.Length)
                {
                    matrixCharPos = 0;
                }
                matrix[i + subMatrix, 0 + subMatrix] = keywordStringVector[matrixCharPos];
                matrixCharPos++;
            }
            // change submatrix
            n -= 2;
            if (n == 1)
            {
                if (matrixCharPos >= keyword.Length)
                {
                    matrixCharPos = 0;
                }
                matrix[startingN / 2, startingN / 2] = keywordStringVector[matrixCharPos];
                n = 0;
            }
        }
        // calculate row weight
        int highestWeight = 0;
        int row = 0;
        for (int i = 0; i < startingN; i++)
        {
            int weight = 0;
            for (int j = 0; j < startingN; j++)
            {
                char letter = Convert.ToChar(matrix[i, j]);
                int letterWeight = (char.ToUpper(letter) - 64) * 10;
                weight += letterWeight;
            }
            if (weight > highestWeight)
            {
                highestWeight = weight;
                row = i;
            }
        }
        Console.WriteLine("{0} - {1}", row, highestWeight);
    }
}
