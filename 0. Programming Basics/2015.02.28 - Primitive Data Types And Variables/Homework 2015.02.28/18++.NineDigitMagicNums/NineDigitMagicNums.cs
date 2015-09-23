using System;
class NineDigitMagicNums
{
    static void Main()
    {
        int sum = int.Parse(Console.ReadLine());
        int diff = int.Parse(Console.ReadLine());
        int counter = 0;
        for (int i = 1; i <= 7; i++)
        {
            for (int j = 1; j <= 7; j++)
            {
                for (int k = 1; k <= 7; k++)
                {
                    for (int a = 1 ; a <= 7; a++)
                    {
                        for (int b = 1; b <= 7; b++)
                        {
                            for (int c = 1; c <= 7; c++)
                            {
                                for (int x = 1; x <= 7; x++)
                                {
                                    for (int y = 1; y <= 7; y++)
                                    {
                                        for (int z = 1; z <= 7; z++)
                                        {
                                            if (i + j + k + a + b + c + x + y + z == sum)
                                            {
                                                int ijk = i * 100 + j * 10 + k;
                                                int abc = a * 100 + b * 10 + c;
                                                int xyz = x * 100 + y * 10 + z;
                                                if (ijk + diff == abc && abc + diff == xyz)
                                                {
                                                    Console.WriteLine("{0}{1}{2}", ijk, abc, xyz);
                                                    counter++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        if (counter == 0)
        {
            Console.WriteLine("No");
        }
    }
}
