namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using Interfaces;
    using Models;

    public class Command : ICommand
    {
        public string Name { get; set; }

        public IDictionary<string, string> Parameters { get; set; }

        public Command(string commandString)
        {
            this.Name = commandString.Substring(0, commandString.IndexOf(' '));
            this.Parameters = new JavaScriptSerializer()
                .Deserialize<Dictionary<string, string>>(commandString.Substring(commandString.IndexOf(' ') + 1));
        }

        public string Execute(ref IVehicleParkExtended vehiclePark)
        {
            if (this.Name != "SetupPark" && vehiclePark.Sectors == 0)
            {
                return "The vehicle park has not been set up";
            }

            switch (this.Name)
            {
                case "SetupPark":
                    var emptyVehiclePark = new VehiclePark(
                        int.Parse(this.Parameters["sectors"]), 
                        int.Parse(this.Parameters["placesPerSector"]));
                    vehiclePark = emptyVehiclePark;
                    return "Vehicle park created";

                case "Park":
                        string licensePlate = this.Parameters["licensePlate"];
                        string owner = this.Parameters["owner"];
                        int reservedTime = int.Parse(this.Parameters["hours"]);
                        int sector = int.Parse(this.Parameters["sector"]);
                        int place = int.Parse(this.Parameters["place"]);
                        var timeOfEntry = DateTime.Parse(this.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind);
                        string result = null;

                        switch (this.Parameters["type"])
                        {
                            case "car":
                                var car = new Car(licensePlate, owner, reservedTime);
                                result = vehiclePark.InsertVehicle(car, sector, place, timeOfEntry);
                                break;
                            case "motorbike":
                                var motorCycle = new Motorbike(licensePlate, owner, reservedTime);
                                result = vehiclePark.InsertVehicle(motorCycle, sector, place, timeOfEntry);
                                break;
                            case "truck":
                                var truck = new Truck(licensePlate, owner, reservedTime);
                                result = vehiclePark.InsertVehicle(truck, sector, place, timeOfEntry);
                                break;
                        }

                        return result;

                case "Exit":
                    string plate = this.Parameters["licensePlate"];
                    var timeOfExit = DateTime.Parse(this.Parameters["time"], null, System.Globalization.DateTimeStyles.RoundtripKind);
                    decimal amountToPay = decimal.Parse(this.Parameters["paid"]);
                    return vehiclePark.ExitVehicle(plate, timeOfExit, amountToPay);

                case "Status":
                    return vehiclePark.GetStatus();

                case "FindVehicle":
                    return vehiclePark.FindVehicleByLicensePlate(this.Parameters["licensePlate"]);

                case "VehiclesByOwner":
                    return vehiclePark.FindVehiclesByOwner(this.Parameters["owner"]);

                default:
                    throw new IndexOutOfRangeException("Invalid commandString.");
            }
        }
    }
}















