namespace _2.IntervalTree
{
    using System;

    public class Demo
    {
        public static void Main()
        {
            var intervalTree = new IntervalTree<int>();
            intervalTree.Add(new Interval<int>(1, 10));
            intervalTree.Add(new Interval<int>(11, 20));
            intervalTree.Add(new Interval<int>(-10, 5));
            intervalTree.Add(new Interval<int>(4, 30));
            intervalTree.Add(new Interval<int>(100, 130));
            intervalTree.Add(new Interval<int>(-20, 5));
            intervalTree.Add(new Interval<int>(2, 7));

            Console.Write("Enter interval START (integer) to search for in the tree: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("Enter interval END (integer) to search for in the tree: ");
            int end = int.Parse(Console.ReadLine());

            var result = intervalTree.Search(new Interval<int>(start, end));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("{0} overlapping intervals found:", result.Count);
            Console.WriteLine(new string('-', 40));
            foreach (Interval<int> interval in result)
            {
                Console.WriteLine("{0} - {1}", interval.Start, interval.End);
            }
        }
    }
}
