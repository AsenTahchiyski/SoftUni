namespace ReversedList
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var reversedList = new ReversedList<int>();
            reversedList.Add(5);
            reversedList.Add(10);
            reversedList.Add(15);
            reversedList.Add(20);
            reversedList.Add(25);

            Console.WriteLine(reversedList);

            foreach (var num in reversedList)
            {
                Console.Write(num + ", ");
            }

            Console.WriteLine();

            Console.WriteLine(reversedList[4]);

            Console.WriteLine(reversedList.Capacity());

            Console.WriteLine(reversedList.Count());

            reversedList.Remove(4);
            Console.WriteLine(reversedList);

            reversedList.Add(30);
            reversedList.Add(31);
            reversedList.Add(32);
            reversedList.Add(33);
            reversedList.Add(34);
            reversedList.Add(35);
            reversedList.Add(36);
            reversedList.Add(37);
            reversedList.Add(38);
            reversedList.Add(39);
            reversedList.Add(40);
            reversedList.Add(30);
            reversedList.Add(31);
            reversedList.Add(32);

            Console.WriteLine(reversedList);
        }
    }
}
