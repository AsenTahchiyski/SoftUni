namespace AsyncTimer
{
    using System;

    class Program
    {
        static void Main()
        {
            Action<int> action = Console.WriteLine;
            AsyncTimer timer = new AsyncTimer(action, 10, 500);
            timer.Start();
            Console.ReadLine();
        }
    }
}
