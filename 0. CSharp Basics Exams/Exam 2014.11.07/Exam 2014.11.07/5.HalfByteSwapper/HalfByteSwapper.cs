using System;
class HalfByteSwapper
{
    static void Main()
    {
        uint[] numbers = new uint[4];
        for (int num = 0; num < 4; num++)
        {
            numbers[num] = uint.Parse(Console.ReadLine());
        }
        // get binary strings from numbers
        string[] BinaryNumbers = new string[4];
        for (int i = 0; i < 4; i++)
        {
            BinaryNumbers[i] = Convert.ToString(numbers[i], 2).PadLeft(32, '0');
        }
        // input commands
        int[,] Commands = new int[2, 2];
        do
        {
            string CommandsInput = Console.ReadLine();
            if (CommandsInput == "End")
            {
                for (int i = 0; i < 4; i++)
                {
                    uint NumberOut = Convert.ToUInt32(BinaryNumbers[i], 2);
                    Console.WriteLine(NumberOut);
                }
                return;
            }
            string[] temp = CommandsInput.Split(' ');
            Commands[0, 0] = Convert.ToInt32(temp[0]);
            Commands[0, 1] = Convert.ToInt32(temp[1]);
            CommandsInput = Console.ReadLine();
            temp = CommandsInput.Split(' ');
            Commands[1, 0] = Convert.ToInt32(temp[0]);
            Commands[1, 1] = Convert.ToInt32(temp[1]);
            // save byte values
            string FirstByte = BinaryNumbers[Commands[0, 0]].Substring(32 - ((1 + Commands[0, 1]) * 4), 4);
            string SecondByte = BinaryNumbers[Commands[1, 0]].Substring(32 - ((1 + Commands[1, 1]) * 4), 4);
            // swap bytes
            BinaryNumbers[Commands[0, 0]] = BinaryNumbers[Commands[0, 0]].Substring(0, 32 - ((1 + Commands[0, 1]) * 4)) 
                + SecondByte + BinaryNumbers[Commands[0, 0]].Substring(32 - (Commands[0, 1] * 4));
            BinaryNumbers[Commands[1, 0]] = BinaryNumbers[Commands[1, 0]].Substring(0, 32 - ((1 + Commands[1, 1]) * 4)) 
                + FirstByte + BinaryNumbers[Commands[1, 0]].Substring(32 - (Commands[1, 1] * 4));
        } while (true);
    }
}
