namespace VehicleParkingSystem.UI
{
    using System;
    using Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        public string ReadLine()
        {
            return Console.ReadLine();
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
