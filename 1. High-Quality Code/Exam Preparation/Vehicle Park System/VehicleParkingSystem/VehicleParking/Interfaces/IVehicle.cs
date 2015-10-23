namespace VehicleParkingSystem.Interfaces
{
    using System;
    
    public interface IVehicle
    {
        string LicensePlate { get; }

        string Owner { get; }

        decimal RegularRate { get; }

        decimal OvertimeRate { get; }

        int ReservedHours { get; }

        DateTime TimeOfEntry { get; set;  }
    }
}
