namespace MinesweeperGame
{
    public interface IRenderer
    {
        string ReadLine();

        string Read();

        void WriteLine(string line);

        void Write(string text);
    }
}
