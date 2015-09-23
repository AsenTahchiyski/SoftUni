namespace WinterIsComing.Contracts
{
    /// <summary>
    /// This interface ensures that all command dispatchers implementing it will receive the instance of the engine currently running, and also that every dispatcher will know how to identify and dispatch a command.
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Ensures that all command dispatchers implementing the interface will have the instance of the engine currently running.
        /// </summary>
        IEngine Engine { get; set; }

        /// <summary>
        /// Ensures that all command dispatchers implementing it will know how to check if the command entered is supported by the engine and execute it if it is.
        /// </summary>
        /// <param name="commandArgs">Parameters of the command.</param>
        void DispatchCommand(string[] commandArgs);

        /// <summary>
        /// Ensures that all command dispatchers implementing it will know how to generate instances for all commands supported by the engine.
        /// </summary>
        void SeedCommands();
    }
}
