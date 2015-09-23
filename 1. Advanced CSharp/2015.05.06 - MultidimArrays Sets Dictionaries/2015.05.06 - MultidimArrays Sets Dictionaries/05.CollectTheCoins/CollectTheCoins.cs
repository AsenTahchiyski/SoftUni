using System;
class CollectTheCoins
{
    static void Main()
    {
        // build jagged array
        int size = 4; // avoiding hadrcoded size
        char[][] jaggedArr = new char[size][];
        for (int i = 0; i < size; i++)
        {
            Console.Write("Please enter string for row {0}: ", i + 1);
            jaggedArr[i] = Console.ReadLine().ToCharArray();
        }
        // process commands
        Console.Write("Enter commands string: ");
        char[] commands = Console.ReadLine().ToCharArray();
        int coinsFound = 0, wallsHit = 0, currentRow = 0, currentCol = 0;
        if (jaggedArr[0][0] == '$') coinsFound++;
        foreach (char command in commands)
        {
            if (command == '>')
            {
                if (currentCol + 1 < jaggedArr[currentRow].Length)
                {
                    currentCol++;
                    if (jaggedArr[currentRow][currentCol] == '$') coinsFound++;
                }
                else wallsHit++;
            }
            else if (command == '<')
            {
                if (currentCol - 1 >= 0)
                {
                    currentCol--;
                    if (jaggedArr[currentRow][currentCol] == '$') coinsFound++;
                }
                else wallsHit++;
            }
            else if (command == 'V' || command == 'v')
            {
                if ((currentRow + 1 < size) && (currentCol < jaggedArr[currentRow + 1].Length))
                {
                    currentRow++;
                    if (jaggedArr[currentRow][currentCol] == '$') coinsFound++;
                }
                else wallsHit++;
            }
            else if (command == '^')
            {
                if ((currentRow - 1 >= 0) && (currentCol < jaggedArr[currentRow - 1].Length))
                {
                    currentRow--;
                    if (jaggedArr[currentRow][currentCol] == '$') coinsFound++;
                }
                else wallsHit++;
            }
        }
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Coins collected: " + coinsFound);
        Console.WriteLine("Walls hit: " + wallsHit);
    }
}
