using System;
class BitBuilder
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int commandCounter = 0;
        do
        {
            int bitPosition = 0;
            string proceed = Console.ReadLine();
            if (proceed == "quit")
            {
                Console.WriteLine(number);
                return;
            } 
            bitPosition = Convert.ToInt32(proceed);
            if (bitPosition > 31 | bitPosition < 0)
            {
                return;
            }
            commandCounter++;
            string command = Console.ReadLine();
            switch (command)
            {
                case "flip": number = flipBit(number, bitPosition); break;
                case "remove": number = removeBit(number, bitPosition); break;
                case "insert": number = insertBit1(number, bitPosition); break;
                case "skip": break;
                default: break;
            }
        } while (commandCounter < 30);
    }
    static int flipBit(int number, int bitPosition)
    {
        int bit = (number >> bitPosition) & 1;
        if (bit == 0)
        {
            number = number | (1 << bitPosition);
        }
        else if(bit == 1)
        {
            number = number & ~(1 << bitPosition);
        }
        return number;
    }
    static int removeBit(int number, int bitPosition)
    {
        string numString = Convert.ToString(number, 2).PadLeft(32, '0');
        numString = numString.Remove(31 - bitPosition, 1);
        number = Convert.ToInt32(numString, 2);
        return number;
    }
    static int insertBit1(int number, int bitPosition)
    {
        string numString = Convert.ToString(number, 2).PadLeft(32, '0');
        numString = numString.Insert(31 - (bitPosition - 1), "1");
        number = Convert.ToInt32(numString, 2);
        return number;
    }
}
