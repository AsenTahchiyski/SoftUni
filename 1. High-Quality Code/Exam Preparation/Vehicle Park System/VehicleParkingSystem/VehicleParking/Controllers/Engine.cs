namespace VehicleParkingSystem.Controllers
{
    using System;
    using Interfaces;
    using UI;

    public class Engine : IEngine
    {
        private readonly IRenderer renderer;
        private readonly CommandExecutor commandExecutor;

        public Engine(CommandExecutor commandExecutor, IRenderer renderer)
        {
            this.commandExecutor = commandExecutor;
            this.renderer = renderer;
        }

        public Engine()
            : this(new CommandExecutor(), new ConsoleRenderer())
        {
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = renderer.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                commandLine = commandLine.Trim();

                // BUG: bool statement inverted
                if (!string.IsNullOrEmpty(commandLine)) 
                {
                    try
                    {
                        var command = new Command(commandLine);
                        string commandResult = this.commandExecutor.Execute(command);
                        renderer.WriteLine(commandResult);
                    }
                    catch (Exception ex)
                    {
                        renderer.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}