namespace MinesweeperGame
{
    public class Minesweeper
    {
        private static void Main()
        {
            IRenderer renderer = new ConsoleRenderer();
            Engine engine = new Engine(renderer);
            engine.Run();
        }
    }
}