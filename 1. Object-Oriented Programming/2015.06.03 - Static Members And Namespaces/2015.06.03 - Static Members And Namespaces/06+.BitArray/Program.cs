using System;

namespace _06_.BitArray
{
    class Program
    {
        static void Main()
        {
            Console.BufferHeight = Int16.MaxValue - 1;
            
            int size = 100; // <- change with value from 1 to 100,000

            BitArray bitarr = new BitArray(size);
            bitarr[size - 1] = 1;
            Console.WriteLine("Decimal representation:");

            Console.WriteLine(bitarr.ToString());
            Console.WriteLine(new string('=', 60));
            // print bits
            Console.WriteLine("Binary representation:");
            for (int i = size - 1; i >= 0; i--)
            {
                Console.Write(bitarr[i]);
            }
            Console.WriteLine();
            Console.WriteLine(new string('=', 60));
        }
    }
}
