using System;
class Pairs
{
    static void Main()
    {
        string[] elements = Console.ReadLine().Split(' ');
        int sum = int.Parse(elements[0]) + int.Parse(elements[1]);
        int prevSum = sum, counter = 1, maxDiff = 0;
        for (int i = 2; i < elements.Length - 1; i += 2)
        {
            int currentSum = int.Parse(elements[i]) + int.Parse(elements[i + 1]);
            if (currentSum != sum)
            {
                if (Math.Abs(currentSum - prevSum) > maxDiff)
                {
                    maxDiff = Math.Abs(currentSum - prevSum);
                }
            }
            else
            {
                counter++;
            }
            prevSum = currentSum;
        }
        if (counter == elements.Length / 2)
        {
            Console.WriteLine("Yes, value={0}", sum);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDiff);
        }
    }
}
