using System;
class MatrixOfNumbers
{
    static void Main()
    {
        Start:
        int n;
        do
        {
            Console.Write("n = ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1 || n > 20);
        for (int row = 0; row < n; row++)
        {
            for (int col = 1; col <= n; col++)
            {
                Console.Write("{0} ", col + row);
            }
            Console.WriteLine();
        }
        goto Start;
    }
}
