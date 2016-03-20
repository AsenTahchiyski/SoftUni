using System;

namespace p3.ArrayBasedStack
{
    class Program
    {
        static void Main()
        {
            var arrayStack = new ArrayStack<int>();
            for (int i = 0; i < 20; i++)
            {
                arrayStack.Push(i + 1);
            }

            while (arrayStack.Count > 0)
            {
                Console.Write(arrayStack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
