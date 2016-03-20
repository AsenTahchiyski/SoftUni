// We are given numbers n and m, and the following operations:
// a)	n -> n + 1
// b)	n -> n + 2
// c)	n -> n * 2
// Write a program that finds the shortest sequence of operations from the list above that starts from n and finishes in m.
// If several shortest sequences exist, find one of them.

namespace _09_.SequenceNtoM
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private class Member
        {
            public int Value { get; set; }
            public Member PreviousMember { get; set; }

            public Member(int value, Member previous)
            {
                this.Value = value;
                this.PreviousMember = previous;
            }
        }

        static void Main()
        {
            Console.Write("Enter n = ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter m = ");
            int m = int.Parse(Console.ReadLine());

            Queue<Member> sequence = new Queue<Member>(); 
            sequence.Enqueue(new Member(n, null));
            while (sequence.Count > 0)
            {
                Member currentItem = sequence.Dequeue();
                if (currentItem.Value < m)
                {
                    sequence.Enqueue(new Member(currentItem.Value + 1, currentItem));
                    sequence.Enqueue(new Member(currentItem.Value + 2, currentItem));
                    sequence.Enqueue(new Member(currentItem.Value * 2, currentItem));
                }

                if (currentItem.Value == m) // print output
                {
                    List<int> output = new List<int>();
                    while (currentItem != null)
                    {
                        output.Add(currentItem.Value);
                        currentItem = currentItem.PreviousMember;
                    }

                    output.Reverse();
                    Console.WriteLine(string.Join(" -> ", output));
                    return;
                }
            }

            Console.WriteLine("(no solution)");
        }
    }
}
