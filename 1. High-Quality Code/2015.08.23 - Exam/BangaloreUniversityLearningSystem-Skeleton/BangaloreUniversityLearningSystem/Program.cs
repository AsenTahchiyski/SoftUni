namespace BangaloreUniversityLearningSystem
{
    using Core;
    using Interfaces;
    using UserInterface;

    public class Program
    {
        public static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            var engine = new Engine(renderer);
            engine.Run();
        }
    }
}