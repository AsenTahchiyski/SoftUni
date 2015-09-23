using System;
class GameOfBits
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        uint output = 0;
        string cmd;
        do
        {
            cmd = Console.ReadLine();
            string bits = Convert.ToString(n, 2);
            if (cmd == "Even")
            {
                for (int i = 0; i < bits.Length; i += 2)
                {
                    uint bit = (n >> bits.Length - 1 - i) & 1;
                    output = output << 1;
                    output = output | bit;
                }
                n = output;
                output = 0;
            }
            else if (cmd == "Odd")
            {
                for (int i = 0; i < bits.Length; i += 2)
                {
                    uint bit = (n >> bits.Length - 2 - i) & 1;
                    output = output << 1;
                    output = output | bit;
                }
                n = output;
                output = 0;
            }
        } while (cmd != "Game Over!");
        string check1s = Convert.ToString(n, 2);
        int ones = 0;
        for (int i = 0; i < check1s.Length; i++)
        {
            if (check1s[i] == '1')
            {
                ones++;
            }
        }
        Console.WriteLine("{0} -> {1}", n, ones);
    }
}
