namespace p6.ReversedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(1);
            reversedList.Add(2);
            reversedList.Add(3);
            reversedList.Add(4);
            reversedList.Add(5);
            System.Console.WriteLine("Elements: " + string.Join(" ", reversedList));
            System.Console.WriteLine("Element count: {0}", reversedList.Count);
            System.Console.WriteLine(new string('-', 20));

            var removeIndex = 1;
            reversedList.Remove(removeIndex);
            System.Console.WriteLine("Elements: {0} (removed element at index {1})", string.Join(" ", reversedList), removeIndex);
            System.Console.WriteLine("Element count: {0}", reversedList.Count);
            System.Console.WriteLine(new string('-', 20));

            System.Console.WriteLine("Current capacity: {0}", reversedList.Capacity);
            System.Console.WriteLine("Current elements count: {0}", reversedList.Count);
            var elementsToAdd = 20;
            for (int i = 0; i < elementsToAdd; i++)
            {
                reversedList.Add(i + 1);
            }

            System.Console.WriteLine("{0} elements added", elementsToAdd);
            System.Console.WriteLine("Current capacity: {0}", reversedList.Capacity);
            System.Console.WriteLine("Current elements count: {0}", reversedList.Count);
            System.Console.WriteLine(new string('-', 20));

            var indexCheck = 20;
            System.Console.WriteLine("Element at index {0}: {1}", indexCheck, reversedList[indexCheck]);
        }
    }
}
