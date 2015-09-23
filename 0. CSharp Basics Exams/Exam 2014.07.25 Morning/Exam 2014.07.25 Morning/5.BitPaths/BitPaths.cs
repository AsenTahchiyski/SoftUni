using System;
class BitPaths
{
    static void Main()
    {
        int paths = int.Parse(Console.ReadLine());
        int[] rowNumbers = {0, 0, 0, 0, 0, 0, 0, 0};
        int sum = 0;
        for (int i = 0; i < paths; i++)
        {
            // get directions
            string[] path = Console.ReadLine().Split(',');
            int[] directions = new int[8];
            int index = 0;
            for (int j = 0; j < 8; j++)
            {
                directions[j] = Convert.ToInt32(path[j]);
            }
            // set bits
            int startIndex = 3 - directions[0];
            rowNumbers[0] ^= 1 << startIndex; // set starting position and bit
            if (i == paths - 1)
            {
                sum += rowNumbers[0];
            }
            for (int k = 1; k < directions.Length; k++)
            {
                index = startIndex - directions[k];
                rowNumbers[k] ^= 1 << index;
                startIndex = index;
                if (i == paths - 1)
                {
                    sum += rowNumbers[k];
                }
            }
        }
        Console.WriteLine("{0}\n{1}", Convert.ToString(sum, 2), Convert.ToString(sum, 16).ToUpper());
    }
}
