namespace VehicleParkingSystem.Data
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Wintellect.PowerCollections;

    internal class Data
    {
        internal Data()
        {
            this.VehicleParkingSpace = new Dictionary<IVehicle, string>();
            this.VehiclesByParkingSpace = new Dictionary<string, IVehicle>(); 
            this.VehiclesByLicensePlate = new Dictionary<string, IVehicle>(); 
            this.VehicleEntryTimes = new Dictionary<IVehicle, DateTime>(); 
            this.VehiclesByOwner = new MultiDictionary<string, IVehicle>(false); 
        }

        public Dictionary<IVehicle, string> VehicleParkingSpace { get; set; }

        public Dictionary<string, IVehicle> VehiclesByParkingSpace { get; set; }
        
        public Dictionary<string, IVehicle> VehiclesByLicensePlate { get; set; }
        
        public Dictionary<IVehicle, DateTime> VehicleEntryTimes { get; set; }
        
        public MultiDictionary<string, IVehicle> VehiclesByOwner { get; set; }

        public int[] SectorSpacesTaken { get; set; }
    }
}
