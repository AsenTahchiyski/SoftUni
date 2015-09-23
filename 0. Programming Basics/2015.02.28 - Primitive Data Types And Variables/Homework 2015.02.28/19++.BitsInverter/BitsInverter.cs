using System;

class BitsInverter
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int step = int.Parse(Console.ReadLine());
        int counter = 1;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            string number = Convert.ToString(num, 2).PadLeft(8, '0');
            char[] binarySplit = number.ToCharArray();
            for (; counter <= (i + 1) * 8; counter+= step)
            {
                if (counter % step == 1 || step == 1)
                {
                    if (binarySplit[counter - 8 * i - 1] == '0')
                    {
                        binarySplit[counter - 8 * i - 1] = '1';
                    }
                    else if (binarySplit[counter - 8 * i - 1] == '1')
                    {
                        binarySplit[counter - 8 * i - 1] = '0';
                    }
                }
            }
            string tempOutput = new string(binarySplit);
            int output = Convert.ToInt32(tempOutput, 2);
            Console.WriteLine(output);
        }
    }
}
