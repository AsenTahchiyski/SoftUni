using System;
class DoubleDowns
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());    
        }
        int right = 0;
        int left = 0;
        int vertical = 0;
        for (int num = 0; num < n - 1; num++)
        {
            string temp1 = Convert.ToString(numbers[num], 2).PadLeft(31, '0');
            string temp2 = Convert.ToString(numbers[num + 1], 2).PadLeft(31, '0');
            char[] tmp1 = temp1.ToCharArray();
            char[] tmp2 = temp2.ToCharArray();
            for (int i = 0; i < 31; i++)
            {
                if (tmp1[i] == tmp2[i] && tmp1[i] == '1')
                {
                    vertical++;
                }
            }
            for (int i = 0; i < 30; i++)
            {
                if (tmp1[i] == tmp2[i + 1] && tmp1[i] == '1')
                {
                    right++;
                }
            }
            for (int i = 0; i < 30; i++)
            {
                if (tmp1[i + 1] == tmp2[i] && tmp2[i] == '1')
                {
                    left++;
                }
            }
        }
        Console.WriteLine("{0}\n{1}\n{2}", right, left, vertical);
    }
}
