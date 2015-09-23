// 93/100
using System;
using System.Text;
class LongestAlphabWord
{
    static void Main()
    {
        string word = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        char[,] matrix = new char[n, n];
        int counter = 0;
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                matrix[row, col] = word[counter];
                counter++;
                if (counter == word.Length)
                {
                    counter = 0;
                }
            }
        }
        string longestWord = "";
        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < n; col++)
            {
                if (leftWord(matrix, row, col, n).Length > longestWord.Length)
                {
                    longestWord = leftWord(matrix, row, col, n);
                }
                else if (leftWord(matrix, row, col, n).Length == longestWord.Length)
                {
                    longestWord = compareEqualWords(longestWord, leftWord(matrix, row, col, n));
                }
                if (rightWord(matrix, row, col, n).Length > longestWord.Length)
                {
                    longestWord = rightWord(matrix, row, col, n);
                }
                else if (rightWord(matrix, row, col, n).Length == longestWord.Length)
                {
                    longestWord = compareEqualWords(longestWord, rightWord(matrix, row, col, n));
                }
                if (upWord(matrix, row, col, n).Length > longestWord.Length)
                {
                    longestWord = upWord(matrix, row, col, n);
                }
                else if (upWord(matrix, row, col, n).Length == longestWord.Length)
                {
                    longestWord = compareEqualWords(longestWord, upWord(matrix, row, col, n));
                }
                if (downWord(matrix, row, col, n).Length > longestWord.Length)
                {
                    longestWord = downWord(matrix, row, col, n);
                }
                else if (downWord(matrix, row, col, n).Length == longestWord.Length)
                {
                    longestWord = compareEqualWords(longestWord, downWord(matrix, row, col, n));
                }
            }
        }
        Console.WriteLine(longestWord);
    }
    static string leftWord(char[,] matrix, int row, int col, int n)
    {
        StringBuilder currentWord = new StringBuilder();
        currentWord.Append(matrix[row, col]);
        if (col > 0)
        {
            for (int i = col; i > 0; i--)
            {
                if (matrix[row, i - 1] > matrix[row, i])
                {
                    currentWord.Append(matrix[row, i - 1]);
                }
                else
                {
                    break;
                }
            }
        }
        return currentWord.ToString();
    }
    static string rightWord(char[,] matrix, int row, int col, int n)
    {
        StringBuilder currentWord = new StringBuilder();
        currentWord.Append(matrix[row, col]);
        if (col < n - 1)
        {
            for (int i = col; i < n - 1; i++)
            {
                if (matrix[row, i + 1] > matrix[row, i])
                {
                    currentWord.Append(matrix[row, i + 1]);
                }
                else
                {
                    break;
                }
            }
        }
        return currentWord.ToString();
    }
    static string upWord(char[,] matrix, int row, int col, int n)
    {
        StringBuilder currentWord = new StringBuilder();
        currentWord.Append(matrix[row, col]);
        if (row > 0)
        {
            for (int i = row; i > 0; i--)
            {
                if (matrix[i - 1, col] > matrix[i, col])
                {
                    currentWord.Append(matrix[i - 1, col]);
                }
                else
                {
                    break;
                }
            }
        }
        return currentWord.ToString();
    }
    static string downWord(char[,] matrix, int row, int col, int n)
    {
        StringBuilder currentWord = new StringBuilder();
        currentWord.Append(matrix[row, col]);
        if (row < n - 1)
        {
            for (int i = row; i < n - 1; i++)
            {
                if (matrix[i + 1, col] > matrix[i, col])
                {
                    currentWord.Append(matrix[i + 1, col]);
                }
                else
                {
                    break;
                }
            }
        }
        return currentWord.ToString();
    }
    static string compareEqualWords(string word1, string word2)
    {
        int sum1 = 0, sum2 = 0;
        foreach (char letter in word1)
        {
            sum1 += letter;
        }
        foreach (char letter in word2)
        {
            sum2 += letter;
        }
        return sum1 > sum2 ? word2 : word1;
    }
}
