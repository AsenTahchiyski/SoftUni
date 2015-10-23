namespace VehicleParkingSystem.Controllers
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Interfaces;

    public class VehiclePark : IVehiclePark
    {
        private readonly Data database;
        private int sectors;
        private int placesPerSector;

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.Sectors = numberOfSectors;
            this.PlacesPerSector = placesPerSector;
            this.database = new Data();
            this.database.SectorSpacesTaken = new int[numberOfSectors];
        }

        public int Sectors
        {
            get
            {
                return this.sectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of sectors must be positive.");
                }

                this.sectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }

        public string InsertVehicle(IVehicle vehicle, int sector, int placeInSector, DateTime timeOfEntry)
        {
            if (this.database.VehiclesByLicensePlate.ContainsKey(vehicle.LicensePlate))
            {
                throw new ArgumentException(string.Format(GlobalMessages.VehicleAlreadyParked, vehicle.LicensePlate));
            }

            if (sector > this.Sectors || sector < 1)
            {
                throw new ArgumentException(string.Format(GlobalMessages.NoSuchSector, sector));
            }

            if (placeInSector > this.PlacesPerSector || placeInSector < 0)
            {
                throw new ArgumentException(string.Format(GlobalMessages.NoSuchPlaceInSector, placeInSector, sector));
            }

            string parkingSpace = "(" + sector + "," + placeInSector + ")";
            if (this.database.VehiclesByParkingSpace.ContainsKey(parkingSpace))
            {
                throw new ArgumentException(string.Format(GlobalMessages.PlaceIsOccupied, parkingSpace));
            }

            vehicle.TimeOfEntry = timeOfEntry;
            this.database.VehicleEntryTimes.Add(vehicle, timeOfEntry);
            this.database.VehiclesByLicensePlate.Add(vehicle.LicensePlate, vehicle);
            this.database.VehiclesByOwner.Add(vehicle.Owner, vehicle);
            this.database.VehiclesByParkingSpace.Add(parkingSpace, vehicle);
            this.database.VehicleParkingSpace.Add(vehicle, parkingSpace);
            this.database.SectorSpacesTaken[sector - 1]++;
            return string.Format(GlobalMessages.VehicleParked, vehicle.GetType().Name, parkingSpace);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid)
        {
            if (!this.database.VehiclesByLicensePlate.ContainsKey(licensePlate))
            {
                throw new ArgumentException(string.Format(GlobalMessages.VehicleNotPresent, licensePlate));
            }
            
            StringBuilder result = new StringBuilder();
            IVehicle vehicle = this.database.VehiclesByLicensePlate[licensePlate];
            var totalStay = endTime - this.database.VehicleEntryTimes[vehicle];
            int totalHours = totalStay.Hours + (24 * totalStay.Days);
            if (totalStay.Minutes >= 30)
            {
                totalHours++;
            }

            int overtime = totalHours - vehicle.ReservedHours >= 0 ? totalHours - vehicle.ReservedHours : 0;
            decimal reservedAmount = vehicle.ReservedHours * vehicle.RegularRate;
            decimal overtimeAmount = overtime * vehicle.OvertimeRate;
            decimal total = reservedAmount + overtimeAmount;
            result.AppendLine(new string('*', 20));
            result.AppendFormat("{0} [{1}], owned by {2}\nat place {3}\nRate: ${4:0.00}\nOvertime rate: ${5:0.00}", vehicle.GetType().Name, vehicle.LicensePlate, vehicle.Owner, this.database.VehicleParkingSpace[vehicle], reservedAmount, overtimeAmount).AppendLine();
            result.AppendLine(new string('-', 20));
            result.AppendFormat("Total: ${0:0.00}\nPaid: ${1:0.00}\nChange: ${2:0.00}", total, amountPaid, amountPaid - total).AppendLine();
            result.Append(new string('*', 20));

            this.database.VehicleEntryTimes.Remove(vehicle);
            this.database.VehiclesByLicensePlate.Remove(vehicle.LicensePlate);
            this.database.VehiclesByOwner.Remove(vehicle.Owner, vehicle);
            string parkingSpace = this.database.VehicleParkingSpace[vehicle];
            string sector = parkingSpace.Replace("(", string.Empty).Replace(")", string.Empty).Split(',')[0];
            this.database.VehiclesByParkingSpace.Remove(parkingSpace);
            this.database.VehicleParkingSpace.Remove(vehicle);
            this.database.SectorSpacesTaken[int.Parse(sector) - 1]--;

            return result.ToString();
        }

        public string GetStatus()
        {
            StringBuilder output = new StringBuilder();
            for (int sector = 0; sector < this.Sectors; sector++)
            {
                int sectorSpacesTaken = this.database.SectorSpacesTaken[sector];
                int filledPercentage = sectorSpacesTaken * 100 / this.PlacesPerSector;
                output.AppendFormat(GlobalMessages.SectorStatus, sector + 1, sectorSpacesTaken, this.PlacesPerSector, filledPercentage);
                if (sector < this.Sectors - 1)
                {
                    output.AppendLine();
                }
            }

            return output.ToString();
        }

        public string FindVehicle(string licensePlate)
        {
            if (!this.database.VehiclesByLicensePlate.ContainsKey(licensePlate))
            {
                throw new ArgumentException(string.Format(GlobalMessages.VehicleNotPresent, licensePlate));
            }

            StringBuilder result = new StringBuilder();
            IVehicle vehicle = this.database.VehiclesByLicensePlate[licensePlate];
            result.AppendFormat(GlobalMessages.FindByLicense, vehicle.GetType().Name, vehicle.LicensePlate, vehicle.Owner, this.database.VehicleParkingSpace[vehicle]);
            return result.ToString();
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.database.VehiclesByOwner.ContainsKey(owner))
            {
                throw new ArgumentException(string.Format(GlobalMessages.NoVehiclesByOwner, owner));
            }

            var vehicles = this.database.VehiclesByOwner[owner];
            var sortedVehicles = vehicles.OrderBy(v => v.TimeOfEntry).ThenBy(s => s.LicensePlate).ToList();
            StringBuilder result = new StringBuilder();
            int totalVehicles = sortedVehicles.Count;
            int counter = 0;
            foreach (IVehicle vehicle in sortedVehicles)
            {
                result.Append(this.FindVehicle(vehicle.LicensePlate));
                counter++;
                if (counter < totalVehicles)
                {
                    result.AppendLine();
                }
            }

            return result.ToString();
        }
    }
}
