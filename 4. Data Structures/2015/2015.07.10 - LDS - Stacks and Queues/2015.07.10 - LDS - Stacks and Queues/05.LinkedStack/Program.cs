namespace _05.LinkedStack
{
    using System;

    class Program
    {
        static void Main()
        {
            var collection = new LinkedStack<int>();
            collection.Push(1);
            collection.Push(2);
            collection.Push(3);
            collection.Push(4);
            collection.Push(5);
            collection.Push(6);
            collection.Push(7);
            collection.Push(8);
            collection.Push(9);

            Console.WriteLine(collection.Pop());
            Console.WriteLine(collection.Pop());
            Console.WriteLine(collection.Pop());
            Console.WriteLine(collection.Pop());
            Console.WriteLine(collection.Pop());
            Console.WriteLine("Count: " + collection.Count);

            var array = collection.ToArray();
            Console.WriteLine(string.Join(", ", array));

            Console.WriteLine(collection.Pop());
            Console.WriteLine("Count: " + collection.Count);

        }
    }
}
