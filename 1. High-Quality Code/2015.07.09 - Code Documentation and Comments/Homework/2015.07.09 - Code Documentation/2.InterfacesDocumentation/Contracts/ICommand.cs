namespace WinterIsComing.Contracts
{
    /// <summary>
    /// This interface ensures that all commands implementing it will receive the engine instance that is currently running, and will implement a method for their execution.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Property to hold the instance of the engine that is currently running.
        /// </summary>
        IEngine Engine { get; }

        /// <summary>
        /// This method aims to ensure that each command implementing the interface will know how to execute itself.
        /// </summary>
        /// <param name="commandArgs">The command arguments.</param>
        void Execute(string[] commandArgs);
    }
}
