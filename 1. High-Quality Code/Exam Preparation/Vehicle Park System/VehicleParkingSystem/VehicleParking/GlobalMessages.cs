namespace VehicleParkingSystem
{
    public static class GlobalMessages
    {
        public const string VehicleParked = "{0} parked successfully at place {1}";
        public const string SectorStatus = "Sector {0}: {1} / {2} ({3}% full)";
        public const string FindByLicense = "{0} [{1}], owned by {2}\nParked at {3}";
        public const string VehicleAlreadyParked = "There is already a vehicle with license plate {0} in the park";
        public const string VehicleNotPresent = "There is no vehicle with license plate {0} in the park";
        public const string NoVehiclesByOwner = "No vehicles by {0}";
        public const string PlaceIsOccupied = "The place {0} is occupied";
        public const string NoSuchSector = "There is no sector {0} in the park";
        public const string NoSuchPlaceInSector = "There is no place {0} in sector {1}";
    }
}
