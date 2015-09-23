namespace VehicleParkSystem.Interfaces
{
    using System;

    public interface IVehicleParkExtended
    {
        // TODO: Document this
        string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime timeOfEntry);
        // TODO: Document this
        string ExitVehicle(string licencePlateNumber, DateTime timeOfExit, decimal amountPaid);
        // TODO: Document this
        string GetStatus();
        // TODO: Document this
        string FindVehicleByLicensePlate(string licencePlateNumber);
        // TODO: Document this
        string FindVehiclesByOwner(string owner);

        int Sectors { get; }

        int PlacesPerSector { get; }
    }
}