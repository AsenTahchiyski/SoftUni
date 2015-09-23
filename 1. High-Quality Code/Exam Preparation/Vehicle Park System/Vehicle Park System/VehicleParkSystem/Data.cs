namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Wintellect.PowerCollections;

    internal class Data
    {
        public Data(int numberOfSectors)
        {
            this.VehicleLocation = new Dictionary<IVehicle, string>();
            this.VehiclesByOwner = new MultiDictionary<string, IVehicle>(false);
            this.VehiclesByLocation = new Dictionary<string, IVehicle>(); 
            this.VehiclesByLicenseNumber = new Dictionary<string, IVehicle>();
            this.VehiclesEntryTimes = new Dictionary<IVehicle, DateTime>();
            this.SectorsAndPlaces = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> VehicleLocation { get; set; }
        
        public Dictionary<string, IVehicle> VehiclesByLocation { get; set; }
        
        public Dictionary<string, IVehicle> VehiclesByLicenseNumber { get; set; }
        
        public Dictionary<IVehicle, DateTime> VehiclesEntryTimes { get; set; }
        
        public MultiDictionary<string, IVehicle> VehiclesByOwner { get; set; }

        public int[] SectorsAndPlaces { get; set; }
    }
}
