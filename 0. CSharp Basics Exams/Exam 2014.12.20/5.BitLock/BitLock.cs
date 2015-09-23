using System;
class BitLock
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] numbers = input.Split(' ');
        // commands
        string command = null;
        do
        {
            command = Console.ReadLine();
            // check numbers
            string[] parameters = command.Split(' ');
            if (parameters.Length == 2)
            {
                Console.WriteLine(ColumnCheck(numbers, Convert.ToInt32(parameters[1])));
            }
            // rotation
            if (parameters.Length == 3)
            {
                int row = Convert.ToInt32(parameters[0]);
                bool right;
                if (parameters[1] == "right")
                {
                    right = true;
                }
                else if (parameters[1] == "left")
                {
                    right = false;
                }
                else
                {
                    Console.WriteLine("get your shit together man");
                    return;
                }
                int rotations = Convert.ToInt32(parameters[2]);
                numbers[row] = Rotation(numbers[row], right, rotations);
                
            }
        } while (command != "end");
        foreach (var item in numbers)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    static int ColumnCheck(string[] numbers, int col)
    {
        int ColCheckResult = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            int number = Convert.ToInt32(numbers[i]);
            int nthDigit = ((number >> col) & 1) % 10;
            if (nthDigit == 1)
            {
                ColCheckResult++;
            }
        }
        return ColCheckResult;
    }
    static string Rotation(string number, bool right, int rotations)
    {
        int newNumber = Convert.ToInt32(number);
        if (right == true)
        {
            for (int i = 0; i < rotations; i++)
            {
                int corrector = newNumber & 1;
                newNumber >>= 1;
                if (corrector == 0)
                {
                    newNumber = newNumber & ~(1 << 11);
                }
                else if (corrector == 1)
                {
                    newNumber = newNumber | 1 << 11;
                }
            }
        }
        else if (right == false)
        {
            for (int i = 0; i < rotations; i++)
            {
                int corrector = newNumber >> 11 & 1;
                newNumber <<= 1;
                newNumber = newNumber & 4095;
                if (corrector == 0)
                {
                    newNumber = newNumber & ~1;
                }
                else if (corrector == 1)
                {
                    newNumber = newNumber | 1;
                }
            }
        }
        return Convert.ToString(newNumber);
    }
}
