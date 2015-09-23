namespace VehicleParkSystem.Interfaces
{
    using System;
    using Models;

    public interface IVehiclePark
    {
        // TODO: Document this
        string InsertCar(Car car, int sector, int place, DateTime time);
        // TODO: Document this
        string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime time);
        // TODO: Document this
        string InsertTruck(Truck truck, int sector, int place, DateTime time);
        // TODO: Document this
        string ExitVehicle(string licencePlateNumber, DateTime endTime, decimal amountPaid);
        // TODO: Document this
        string GetStatus();
        // TODO: Document this
        string FindVehicleByLicensePlate(string licencePlateNumber);
        // TODO: Document this
        string FindVehiclesByOwner(string owner);
    }
}