namespace CodeFormatting
{
    using System;

    internal class Program
    {
        private static void Main()
        {
            while (EventHolder.ExecuteNextCommand())
            {
            }

            Console.WriteLine(Messages.Output);
        }
    }
}
