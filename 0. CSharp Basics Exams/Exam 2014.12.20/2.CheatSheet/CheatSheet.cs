using System;
class CheatSheet
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());
        long rowStart = int.Parse(Console.ReadLine());
        long colStart = int.Parse(Console.ReadLine());
        for (long row = rowStart; row < rows + rowStart; row++)
        {
            for (long col = colStart; col < cols + colStart; col++)
            {
                Console.Write(row * col);
                if (col < cols + colStart - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
