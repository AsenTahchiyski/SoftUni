using System;
class EncryptedMatrix
{
    static void Main()
    {
        string input = Console.ReadLine();
        char direction;
        string messageToNum1 = "", num1ToNum2 = "";
        foreach (char letter in input)
        {
            messageToNum1 = String.Concat(messageToNum1, ((int)letter % 10));
        }
        for (int i = 0; i < messageToNum1.Length; i++)
        {
            int currentNum = (int)char.GetNumericValue(messageToNum1[i]);
            if (currentNum % 2 == 0)
            {
                num1ToNum2 = string.Concat(num1ToNum2 + currentNum * currentNum);
            }
            else
            {
                int prevNum = i == 0 ? 0 : (int)char.GetNumericValue(messageToNum1[i - 1]);
                int nextNum = i == messageToNum1.Length - 1 ? 0 : (int)char.GetNumericValue(messageToNum1[i + 1]);
                num1ToNum2 = string.Concat(num1ToNum2 + (currentNum + prevNum + nextNum));
            }
        }
        direction = char.Parse(Console.ReadLine());
        int n = num1ToNum2.Length;
        char[,] matrix = new char[n, n];
        int counter = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = '0';
                if (direction == '\\' && row == col)
	            {
                    matrix[row, col] = num1ToNum2[counter];
	            }
                else if (direction == '/' && row == n - col - 1)
                {
                    matrix[row, col] = num1ToNum2[n - 1 - counter];
                }
            }
            counter++;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
