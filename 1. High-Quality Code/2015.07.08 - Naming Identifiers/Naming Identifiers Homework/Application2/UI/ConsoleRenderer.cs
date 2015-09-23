namespace MinesweeperGame
{
    using System;

    internal class ConsoleRenderer : IRenderer
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public string Read()
        {
            return Console.Read().ToString();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}
