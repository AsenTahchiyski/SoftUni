using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
class TextGravity
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        List<char[]> matrix = new List<char[]>();
        // fill matrix
        int index = 0, line = -1;
        while (index < text.Length)
        {
            matrix.Add(new char[n]);
            line++;
            for (int col = 0; col < n; col++)
			{
                matrix[line][col] = index >= text.Length ? ' ' : text[index];
                index++; 
			}
        }
        // move elements
        matrix = MoveNonEmptyElements(matrix, line, n);
        // print
        Console.Write(@"<table>");
        foreach (var row in matrix)
        {
            Console.Write(@"<tr>");
            foreach (var chr in row)
            {
                Console.Write(@"<td>{0}</td>", chr);
            }
            Console.Write(@"</tr>");
        }
        Console.Write(@"</table>");
    }
    static List<char[]> MoveNonEmptyElements(List<char[]> matrix, int line, int n)
    {
        int elementsMoved = 0;
        do
        {
            elementsMoved = 0;
            for (int row = line; row > 0; row--)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row][col] == ' ')
                    {
                        matrix[row][col] = matrix[row - 1][col];
                        if (matrix[row - 1][col] != ' ') elementsMoved++;
                        matrix[row - 1][col] = ' ';
                    }
                }
            }
        } while (elementsMoved > 0);
        return matrix;
    }
}
