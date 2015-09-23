using System;
using System.Linq;
class Parachute
{
    static void Main()
    {
        string line;
        int lineCounter = 0;
        int jumperPosition = 0;
        while ((line = Console.ReadLine()) != "END")
        {
            if (line.Contains('o'))
            {
                jumperPosition = line.IndexOf('o');
                continue;
            }
            int nextPosition = jumperPosition + GetNextMovement(line);
            if(nextPosition >= 0 && nextPosition < line.Length) jumperPosition += GetNextMovement(line);
            lineCounter++;
            switch (line[jumperPosition])
            {
                case '_':
                    Console.WriteLine("Landed on the ground like a boss!");
                    Console.WriteLine("{0} {1}", lineCounter, jumperPosition);
                    return;
                case '~':
                    Console.WriteLine("Drowned in the water like a cat!");
                    Console.WriteLine("{0} {1}", lineCounter, jumperPosition);
                    return;
                case '/':
                case '\\':
                case '|':
                    Console.WriteLine("Got smacked on the rock like a dog!");
                    Console.WriteLine("{0} {1}", lineCounter, jumperPosition);
                    return;
                default: break;
            }
        }
    }
    static int GetNextMovement(string line)
    {
        int movement = 0;
        foreach (char ch in line)
        {
            switch (ch)
            {
                case '>': movement++; break;
                case '<': movement--; break;
                default: break;
            }
        }
        return movement;
    }
}
