namespace BangaloreUniversityLearningSystem.UserInterface
{
    using System;
    using Interfaces;

    class ConsoleRenderer : IRenderer
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Read(string text)
        {
            Console.Write(text);
        }
    }
}
