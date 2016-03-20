namespace _03.ArrayBasedStack
{
    using System;

    class Example
    {
        static void Main()
        {
            var stack = new ArrayStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            var first = stack.Pop();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            stack.Push(-7);
            stack.Push(-8);
            stack.Push(-9);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            first = stack.Pop();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            stack.Push(-10);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");

            first = stack.Pop();
            Console.WriteLine("First = {0}", first);
            Console.WriteLine("Count = {0}", stack.Count);
            Console.WriteLine(string.Join(", ", stack.ToArray()));
            Console.WriteLine("---------------------------");
        }
    }
}

