using System;
class JumpingSums
{
    static void Main()
    {
        string s = Console.ReadLine();
        string[] numbers = s.Split(' ');
        int jumps = int.Parse(Console.ReadLine());
        int MaxSum = 0;
        for (int num = 0; num < numbers.Length; num++)
        {
            int index = num;
            int CurrentSum = Convert.ToInt32(numbers[num]);
            for (int jump = 0; jump < jumps; jump++)
            {
                index += Convert.ToInt32(numbers[index]);
                while (index > numbers.Length - 1)
                {
                    index -= numbers.Length;
                }
                CurrentSum += Convert.ToInt32(numbers[index]);
            }
            if (MaxSum < CurrentSum)
            {
                MaxSum = CurrentSum;
            }
        }
        Console.WriteLine("max sum = " + MaxSum);
    }
}
