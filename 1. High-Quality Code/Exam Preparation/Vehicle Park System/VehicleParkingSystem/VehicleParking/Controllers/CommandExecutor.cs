namespace VehicleParkingSystem.Controllers
{
    using System;
    using Interfaces;
    using Models;

    public class CommandExecutor
    {
        private IVehiclePark VehiclePark { get; set; }

        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            switch (command.Name)
            {
                case "SetupPark":
                    int sectors = int.Parse(command.Parameters["sectors"]);
                    int placesPerSector = int.Parse(command.Parameters["placesPerSector"]);
                    this.VehiclePark = new VehiclePark(sectors, placesPerSector);
                    return "Vehicle park created";

                case "Park":
                    IVehicle vehicle = null;
                    string licensePlate = command.Parameters["licensePlate"];
                    string owner = command.Parameters["owner"];
                    int reservedHours = int.Parse(command.Parameters["hours"]);
                    int sector = int.Parse(command.Parameters["sector"]);
                    int placeInSector = int.Parse(command.Parameters["place"]);
                    DateTime timeOfEntry = DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind);
                    switch (command.Parameters["type"])
                    {
                        case "car":
                            vehicle = new Car(licensePlate, owner, reservedHours);
                            break;
                        case "motorbike":
                            vehicle = new Motorbike(licensePlate, owner, reservedHours);
                            break;
                        case "truck":
                            vehicle = new Truck(licensePlate, owner, reservedHours);
                            break;
                    }

                    string result = this.VehiclePark.InsertVehicle(vehicle, sector, placeInSector, timeOfEntry);
                    return result;

                case "Exit":
                    string licensePlateExit = command.Parameters["licensePlate"];
                    DateTime timeOfEntryExit = DateTime.Parse(command.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind);
                    decimal amountPaid = decimal.Parse(command.Parameters["paid"]); // BUG: parameter name is "paid", not "money"
                    string exitResult = this.VehiclePark.ExitVehicle(licensePlateExit, timeOfEntryExit, amountPaid);
                    return exitResult;

                case "Status":
                    return this.VehiclePark.GetStatus();

                case "FindVehicle":
                    return this.VehiclePark.FindVehicle(command.Parameters["licensePlate"]);

                case "VehiclesByOwner":
                    return this.VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);

                default: 
                    throw new InvalidOperationException("Invalid command.");
            }
        }
    }
}