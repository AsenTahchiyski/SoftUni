using System;
using Wintellect.PowerCollections;

namespace p2
{
    class Program
    {
        private static BigList<char> rope = new BigList<char>();

        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            for (int i = 0; i < 10000; i++)
            {
                Insert(alphabet);
                Append(alphabet);
                Delete(3, 20);
            }

            Print();
        }

        static void Insert(string text)
        {
            rope.AddRangeToFront(text);
            Console.WriteLine("OK");
        }

        static void Append(string text)
        {
            rope.AddRange(text);
            Console.WriteLine("OK");
        }

        static void Delete(int startIndex, int count)
        {
            try
            {
                rope.RemoveRange(startIndex, count);
                Console.WriteLine("OK");
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR");
            }
        }

        static void Print()
        {
            Console.WriteLine(rope);
        }
    }
}
