using System;
using System.Collections.Generic;
class CrossingSequences
{
    static void Main()
    {
        int tri1 = int.Parse(Console.ReadLine());
        int tri2 = int.Parse(Console.ReadLine());
        int tri3 = int.Parse(Console.ReadLine());
        int spiralStart = int.Parse(Console.ReadLine());
        int spiralStep = int.Parse(Console.ReadLine());
        List<int> tribonacci = new List<int>();
        List<int> spiral = new List<int>();
        int triPrev1 = tri1;
        int triPrev2 = tri2;
        int triPrev3 = tri3;
        tribonacci.Add(tri1);
        tribonacci.Add(tri2);
        tribonacci.Add(tri3);
        int spiralCurrent = spiralStart;
        spiral.Add(spiralStart);
        if (tribonacci.Contains(spiralStart))
        {
            Console.WriteLine(spiralStart);
            return;
        }
        int i = 0;
        do
        {
            // get tribonacci numbers
            int triCurrent = triPrev1 + triPrev2 + triPrev3;
            triCurrent = triPrev1 + triPrev2 + triPrev3;
            tribonacci.Add(triCurrent);
            triPrev1 = triPrev2;
            triPrev2 = triPrev3;
            triPrev3 = triCurrent;
            // get spiral numbers
            spiralCurrent = spiralCurrent + spiralStep + (i / 2) * spiralStep;
            spiral.Add(spiralCurrent);
            if (spiral[spiral.Count - 1] > tribonacci[tribonacci.Count - 1])
            {
                if (spiral.Contains(triCurrent))
                {
                    Console.WriteLine(spiralCurrent);
                    return;
                }
            }
            else
            {
                if (tribonacci.Contains(spiralCurrent))
                {
                    Console.WriteLine(spiralCurrent);
                    return;
                }
            }
            i++;
        } while (spiral[spiral.Count - 1] <= 1000000 || tribonacci[tribonacci.Count - 1] <= 1000000);
        Console.WriteLine("No");
    }
}
