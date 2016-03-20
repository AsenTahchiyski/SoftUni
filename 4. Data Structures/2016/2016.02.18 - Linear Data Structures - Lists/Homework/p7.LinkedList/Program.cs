namespace p7.LinkedList
{
    class Program
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(1);
            linkedList.Add(2);
            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            System.Console.WriteLine("Elements: " + string.Join(" ", linkedList));
            System.Console.WriteLine("Element count: {0}", linkedList.Count);
            System.Console.WriteLine(new string('-', 20));

            var removeIndex = 1;
            linkedList.Remove(removeIndex);
            System.Console.WriteLine("Elements: {0} (removed element at index {1})", string.Join(" ", linkedList), removeIndex);
            System.Console.WriteLine("Element count: {0}", linkedList.Count);
            System.Console.WriteLine(new string('-', 20));

            System.Console.WriteLine("Current elements count: {0}", linkedList.Count);
            var elementsToAdd = 20;
            for (int i = 0; i < elementsToAdd; i++)
            {
                linkedList.Add(i + 1);
            }

            System.Console.WriteLine("{0} elements added", elementsToAdd);
            System.Console.WriteLine("Current elements count: {0}", linkedList.Count);
            System.Console.WriteLine(new string('-', 20));

            int valueToFind = 1;
            System.Console.WriteLine("Elements: " + string.Join(" ", linkedList));
            System.Console.WriteLine("First index of {0}: {1}", valueToFind, linkedList.FirstIndexOf(valueToFind));
            System.Console.WriteLine("Last index of {0}: {1}", valueToFind, linkedList.LastIndexOf(valueToFind));

        }
    }
}
