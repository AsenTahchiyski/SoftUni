namespace VehicleParkingSystem.Interfaces
{
    using System;

    /// <summary>
    /// Defines all actions a vehicle park should be able to perform.
    /// </summary>
    public interface IVehiclePark
    {
        /// <summary>
        /// Inserts a vehicle in the park.
        /// </summary>
        /// <param name="vehicle">The vehicle to insert.</param>
        /// <param name="sector">Sector number to park the vehicle in.</param>
        /// <param name="placeInSector">Place in the sector to park the vehicle at.</param>
        /// <param name="timeOfEntry">Vehicle time of entry in the park.</param>
        /// <returns>Action result as string.</returns>
        string InsertVehicle(IVehicle vehicle, int sector, int placeInSector, DateTime timeOfEntry);
        
        /// <summary>
        /// Removes a vehicle from the park, provides payment details.
        /// </summary>
        /// <param name="licensePlate">Vehicle license plate number.</param>
        /// <param name="endTime">Time of vehicle exit from the park.</param>
        /// <param name="amountPaid">Amount paid.</param>
        /// <returns>Action result as string. Contains payment details (receipt).</returns>
        string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);
        
        /// <summary>
        /// Provides vehicle park status, containing places occupied and percentage of places occupied for all sectors.
        /// </summary>
        /// <returns>Action result as string.</returns>
        string GetStatus();
        
        /// <summary>
        /// Finds a vehicle in the park by its license plate.
        /// </summary>
        /// <param name="licensePlate">Vehicle's license plate number.</param>
        /// <returns>Action result as string, containing vehicle owner and position in the park.</returns>
        string FindVehicle(string licensePlate);
        
        /// <summary>
        /// Finds all vehicles for a specified owner.
        /// </summary>
        /// <param name="owner">Owner name.</param>
        /// <returns>Action result as string, containing vehicle owner and position in the park.</returns>
        string FindVehiclesByOwner(string owner);
    }
}
