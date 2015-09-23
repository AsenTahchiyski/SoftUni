namespace _03.BinaryHeap
{
    class Program
    {
        static void Main()
        {
            //var testHeap = new BinaryHeap<int>();
            //testHeap.Add(5);
            //testHeap.Add(6);
            //testHeap.Add(7);
            //testHeap.Add(8);
            //testHeap.Add(9);
            //testHeap.Add(1);
            //testHeap.Add(2);
            //testHeap.Add(3);
            //testHeap.Add(31);
            //testHeap.Add(4);

            var testPriorityQueue = new PriorityQueue<string>();
            testPriorityQueue.Insert("Pesho", 1);
            testPriorityQueue.Insert("Gosho", 3);
            testPriorityQueue.Insert("Ganka", 2);
            testPriorityQueue.Insert("Tyanko", 7);
            testPriorityQueue.Insert("Minka", 5);
            testPriorityQueue.Insert("Zhelyo", 6);

        }
    }
}
