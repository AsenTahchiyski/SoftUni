using System;
class StudentCables
{
    static void Main()
    {
        int availableCables = int.Parse(Console.ReadLine());
        int totalLenghtAvailable = 0;
        for (int i = availableCables; i > 0; i--)
        {
            int cableLength = int.Parse(Console.ReadLine());
            string measure = Console.ReadLine();
            if (measure == "meters")
            {
                cableLength *= 100;
            }
            if (cableLength < 20)
            {
                availableCables--;
                continue;
            }
            totalLenghtAvailable += cableLength;
        }
        totalLenghtAvailable -= 3 * (availableCables - 1);
        int studentCables = totalLenghtAvailable / 504;
        int remainder = totalLenghtAvailable % 504;
        Console.WriteLine(studentCables);
        Console.WriteLine(remainder);
    }
}
