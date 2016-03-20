using System;
using System.Collections.Generic;

namespace p2.CalcSequenceWithQueue
{
    class Program
    {
        static void Main()
        {
            PrintSequence(2);
            PrintSequence(-1);
            PrintSequence(1000);
        }

        static void PrintSequence(int n)
        {
            var memberQueue = new Queue<int>();
            memberQueue.Enqueue(n);
            for (int i = 0; i < 50; i++)
            {
                var currentNum = memberQueue.Dequeue();
                Console.Write(currentNum + " ");
                memberQueue.Enqueue(currentNum + 1);
                memberQueue.Enqueue(currentNum * 2 + 1);
                memberQueue.Enqueue(currentNum + 2);
            }

            Console.WriteLine("\n" + new string('-', 20));
        }
    }
}
