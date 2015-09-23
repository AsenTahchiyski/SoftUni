using System;
class NakovsMatching
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        long d = int.Parse(Console.ReadLine());
        char[] arrayA = a.ToCharArray();
        char[] arrayB = b.ToCharArray();
        string aLeft = null;
        string aRight = null;
        string bLeft = null;
        string bRight = null;
        int counter = 0;
        for (int i = 0; i < a.Length - 1; i++)
        {
            aLeft = aLeft + arrayA[i];
            aRight = a.Substring(i + 1, a.Length - i - 1);
            for (int j = 0; j < b.Length - 1; j++)
            {
                bLeft = bLeft + arrayB[j];
                bRight = b.Substring(j + 1, b.Length - j - 1);
                long nakovs = Math.Abs(weight(aLeft) * weight(bRight) - weight(aRight) * weight(bLeft));
                if (nakovs <= d)
                {
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs", aLeft, aRight, bLeft, bRight, nakovs);
                    counter++;
                }
            }
            bLeft = null;
            bRight = null;
        }
        if (counter == 0)
        {
            Console.WriteLine("No");
        }
    }
    static long weight(string input)
    {
        long weight = 0;
        foreach (char item in input)
        {
            weight += (int)item;
        }
        return weight;
    }
}
