namespace _07.LinkedQueue
{
    using System;

    class Program
    {
        static void Main()
        {
            LinkedQueue<int> collection = new LinkedQueue<int>();
            collection.Enqueue(1);
            collection.Enqueue(2);
            collection.Enqueue(3);
            collection.Enqueue(4);
            collection.Enqueue(5);
            collection.Enqueue(6);
            collection.Enqueue(7);
            collection.Enqueue(8);
            collection.Enqueue(9);

            Console.WriteLine("Total elements: " + collection.Count);
            Console.WriteLine(collection.Dequeue());
            Console.WriteLine(collection.Dequeue());
            Console.WriteLine(collection.Dequeue());
            Console.WriteLine(collection.Dequeue());
            Console.WriteLine("Total elements: " + collection.Count);

            collection.Enqueue(10);
            collection.Enqueue(11);

            Console.WriteLine(collection.Dequeue());
            Console.WriteLine("Total elements: " + collection.Count);

            var array = collection.ToArray();
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
