namespace WinterIsComing.Contracts
{
    /// <summary>
    /// This interface ensures that all output writers will know how to provide an output and flush their buffer if necessary.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Ensures that all output writers will know how to output data from the engine.
        /// </summary>
        /// <param name="line">The information to be displayed.</param>
        void Write(string line);

        /// <summary>
        /// Ensures all output writers will be able to flush their buffers on command.
        /// </summary>
        void Flush();
    }
}
