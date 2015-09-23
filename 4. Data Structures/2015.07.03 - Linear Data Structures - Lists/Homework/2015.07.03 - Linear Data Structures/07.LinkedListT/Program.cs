namespace LinkedList
{
    using System;

    public class Program
    {
        internal static void Main()
        {
            LinkedList<int> numbers = new LinkedList<int>();
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(7);
            numbers.Add(8);
            numbers.Add(9);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);

            Console.WriteLine(numbers);
            Console.WriteLine(numbers.Count);

            numbers.Remove(4);
            Console.WriteLine(numbers);

            numbers.Add(5);
            Console.WriteLine(numbers);
            Console.WriteLine(numbers.FirstIndexOf(5));
            Console.WriteLine(numbers.LastIndexOf(5));
        }
    }
}
