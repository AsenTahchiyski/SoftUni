namespace VehicleParkSystem
{
    using System;
    using Interfaces;

    public class Engine : IEngine
    {
        private IVehicleParkExtended vehiclePark;

        public Engine(IVehicleParkExtended vehiclePark)
        {
            this.vehiclePark = vehiclePark;
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == null)
                {
                    break;
                }

                try
                {
                    var command = new Command(commandLine);
                    string commandResult = command.Execute(ref vehiclePark);
                    Console.WriteLine(commandResult);
                }
                catch(Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }
            }
        }
    }
}