using System;
class Star
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("{0}*{0}", new string('.', n));
        int DotsEdge = n - 1;
        int DotsCenter = 1;
        for (int TopLines = 0; TopLines < n/2 - 1; TopLines++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', DotsEdge), new string('.', DotsCenter));
            DotsCenter += 2;
            DotsEdge--;
        }
        Console.WriteLine("{0}{1}{0}", new string('*', DotsEdge + 1), new string('.', DotsCenter));
        int StarsEnd = DotsEdge + 1;
        int DotsEnd = DotsCenter;
        DotsEdge = 1;
        DotsCenter = 2 * n + 1 - 4;
        for (int MidLines = 0; MidLines < n/2 - 1; MidLines++)
        {
            Console.WriteLine("{0}*{1}*{0}", new string('.', DotsEdge), new string('.', DotsCenter));
            DotsEdge++;
            DotsCenter -= 2;
        }
        Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', n/2), new string('.', n/2 - 1));
        DotsEdge = n/2 - 1;
        DotsCenter = 1;
        int DotsLeg = n/2 - 1;
        for (int BottomLine = 0; BottomLine < n/2 - 1; BottomLine++)
        {
            Console.WriteLine("{0}*{1}*{2}*{1}*{0}", new string('.', DotsEdge), new string('.', DotsLeg), new string('.', DotsCenter));
            DotsEdge--;
            DotsCenter += 2;
        }
        Console.WriteLine("{0}{1}{0}", new string('*', StarsEnd), new string('.', DotsEnd));
    }
}
