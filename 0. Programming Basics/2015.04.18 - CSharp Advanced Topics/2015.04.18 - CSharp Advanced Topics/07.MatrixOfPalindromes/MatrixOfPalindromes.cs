using System;
class MatrixOfPalindromes
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("{0}{1}{0} ", (char)('a' + row), (char)('a' + row + col));
            }
            Console.WriteLine();
        }
    }
}
