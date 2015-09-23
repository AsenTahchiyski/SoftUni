using System;
using System.Threading;
class FallingRocks
{
    public static string[] row = new string[9];
    public static string rowE = "|                                     |";
    public static int dwarfIndex = 17;
    public static int gameSpeed = 150;
    public static int lives = 3;
    static void Main()
    {
        
        row[0] = "| ^                              @    |";
        row[1] = "|      *          *                   |";
        row[2] = "|           +         %               |";
        row[3] = "| +                              .    |";
        row[4] = "|         ++              !           |";
        row[5] = "|    +         ;              *       |";
        row[6] = "|.       *           +                |";
        row[7] = "|                      *        --    |";
        row[8] = "| ;     .                    @        |";
        
        Console.ForegroundColor = ConsoleColor.Green;
        ConsoleKeyInfo cki = new ConsoleKeyInfo();
        start(cki);
        do
        {
            loop(cki);
        } while (true);
    }
    static void movement(ConsoleKeyInfo cki)
    {
        if (Console.KeyAvailable)
        {
            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.LeftArrow || cki.Key == ConsoleKey.A)
            {
                if (dwarfIndex > 2)
                {
                    dwarfIndex--;    
                }
            }
            if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.D)
            {
                if (dwarfIndex < 36)
                {
                    dwarfIndex++;    
                }
            }
        }
    }
    static string embedDwarf(string input, int index)
    {
        string output = input;
        if (index > 2 || index < 36)
        {
            char[] array = output.ToCharArray();
            if (array[index] == ' ' && array[index - 1] == ' ' && array[index + 1] == ' ')
            {
                array[index] = '0';
                array[index - 1] = '(';
                array[index + 1] = ')';    
            }
            else if (array[index] != ' ' || array[index - 1] != ' ' || array[index + 1] != ' ')
            {
                Console.WriteLine("Въй!");
                lives--;
                if (lives < 1)
                {
                    Console.WriteLine("GAME OVER");
                    return;
                }
            }
            output = new string(array);
        }
        return output;
    }
    static void start(ConsoleKeyInfo cki)
    {
        Console.WriteLine(row[0]);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(embedDwarf(rowE, dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(embedDwarf(rowE, dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(embedDwarf(rowE, dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(embedDwarf(rowE, dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(embedDwarf(rowE, dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(rowE);
        Console.WriteLine(rowE);
        Console.WriteLine(embedDwarf(rowE, dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(rowE);
        Console.WriteLine(embedDwarf(rowE, dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[7]);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(embedDwarf(rowE, dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
    }
    static void loop(ConsoleKeyInfo cki)
    {
        Console.WriteLine(row[8]);
        Console.WriteLine(row[7]);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(embedDwarf(row[0], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[0]);
        Console.WriteLine(row[8]);
        Console.WriteLine(row[7]);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(embedDwarf(row[1], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(row[8]);
        Console.WriteLine(row[7]);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(embedDwarf(row[2], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(row[8]);
        Console.WriteLine(row[7]);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(embedDwarf(row[3], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(row[8]);
        Console.WriteLine(row[7]);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(embedDwarf(row[4], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(row[8]);
        Console.WriteLine(row[7]);
        Console.WriteLine(row[6]);
        Console.WriteLine(embedDwarf(row[5], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(row[8]);
        Console.WriteLine(row[7]);
        Console.WriteLine(embedDwarf(row[6], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(row[8]);
        Console.WriteLine(embedDwarf(row[7], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
        Console.WriteLine(row[7]);
        Console.WriteLine(row[6]);
        Console.WriteLine(row[5]);
        Console.WriteLine(row[4]);
        Console.WriteLine(row[3]);
        Console.WriteLine(row[2]);
        Console.WriteLine(row[1]);
        Console.WriteLine(row[0]);
        Console.WriteLine(embedDwarf(row[8], dwarfIndex));
        Thread.Sleep(gameSpeed);
        Console.Clear();
        movement(cki);
    }
}
