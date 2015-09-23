using System;
class BitsUp
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int index = 1;
        for (int i = 0; i < n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            do
            {
                if (index < 8)
                {
                    number = number | 1 << 7 - index;
                    index += step;    
                }
            } while (index < 8);
            index -= 8;
            Console.WriteLine(number);
        }
    }
}