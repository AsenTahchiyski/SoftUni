using System;
class ChangeEvenBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        int L = int.Parse(Console.ReadLine());
        int changedBits = 0;
        for (int i = 0; i < n; i++)
        {
            string len = Convert.ToString(numbers[i], 2);
            for (int j = 0; j < len.Length; j++)
            {
                int check = L;
                L = L | 1 << j * 2;
                if (check != L)
                {
                    changedBits++;
                }
            }
        }
        Console.WriteLine("{0}\n{1}", L, changedBits);
    }
}
