namespace WinterIsComing.Contracts
{
    /// <summary>
    /// This interface ensures that all input readers that the engine receive will know how to read a command line.
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// The method that is responsible to receive a command from the input.
        /// </summary>
        /// <returns>The command itself as a string.</returns>
        string ReadNextLine();
    }
}
