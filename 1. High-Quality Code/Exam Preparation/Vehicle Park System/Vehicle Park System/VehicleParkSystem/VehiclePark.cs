namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class VehiclePark : IVehicleParkExtended
    {
        private readonly Data data;
        private int numberOfSectors;
        private int placesPerSector;

        public VehiclePark(int numberOfSectors = 0, int placesPerSector = 0)
        {
            this.data = new Data(numberOfSectors);
            this.Sectors = numberOfSectors;
            this.PlacesPerSector = placesPerSector;
        }

        public int Sectors
        {
            get
            {
                return this.numberOfSectors;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of sectors must be positive.");
                }

                this.numberOfSectors = value;
            }
        }

        public int PlacesPerSector
        {
            get
            {
                return this.placesPerSector;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of places per sector must be positive.");
                }

                this.placesPerSector = value;
            }
        }

        public string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime timeOfEntry)
        {
            if (sector > this.Sectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > this.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (this.data.VehiclesByLocation.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (this.data.VehiclesByLicenseNumber.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park", vehicle.LicensePlate);
            }

            this.data.VehicleLocation[vehicle] = string.Format("({0},{1})", sector, place);
            this.data.VehiclesByLocation[string.Format("({0},{1})", sector, place)] = vehicle;
            this.data.VehiclesByLicenseNumber[vehicle.LicensePlate] = vehicle;
            this.data.VehiclesEntryTimes[vehicle] = timeOfEntry;
            this.data.VehiclesByOwner[vehicle.Owner].Add(vehicle);
            this.data.SectorsAndPlaces[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, place);
        }

        public string ExitVehicle(string licencePlateNumber, DateTime timeOfExit, decimal amountToPay)
        {
            var vehicle = (data.VehiclesByLicenseNumber.ContainsKey(licencePlateNumber)) ? this.data.VehiclesByLicenseNumber[licencePlateNumber] : null;
            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park", licencePlateNumber);
            }

            var timeOfEntry = data.VehiclesEntryTimes[vehicle];
            int timeInParking = (int)Math.Round((timeOfExit - timeOfEntry).TotalHours);
            var ticket = new StringBuilder();

            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle).AppendLine()
                .AppendFormat("at place {0}", data.VehicleLocation[vehicle]).AppendLine()
                .AppendFormat("Rate: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate)).AppendLine()
                .AppendFormat("Overtime rate: ${0:F2}", (timeInParking > vehicle.ReservedHours ?
                    (timeInParking - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)).AppendLine()
                .AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate + (timeInParking > vehicle.ReservedHours ? (timeInParking - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))).AppendLine()
                .AppendFormat("Paid: ${0:F2}", amountToPay).AppendLine()
                .AppendFormat("Change: ${0:F2}", amountToPay - ((vehicle.ReservedHours * vehicle.RegularRate) + (timeInParking > vehicle.ReservedHours ?
                    (timeInParking - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))).AppendLine()
                .Append(new string('*', 20));
            
            int sector = int.Parse(data.VehicleLocation[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);
            data.VehiclesByLocation.Remove(data.VehicleLocation[vehicle]);
            data.VehicleLocation.Remove(vehicle);
            data.VehiclesByLicenseNumber.Remove(vehicle.LicensePlate);
            data.VehiclesEntryTimes.Remove(vehicle);
            data.VehiclesByOwner.Remove(vehicle.Owner, vehicle);
            data.SectorsAndPlaces[sector - 1]--;

            return ticket.ToString();
        }

        public string GetStatus()
        {
            string format = "Sector {0}: {1} / {2} ({3}% full)";
            var output = new StringBuilder();
            for (int i = 0; i < this.Sectors; i++)
            {
                int placesTaken = data.SectorsAndPlaces[i];
                int percentageTaken = (int)(Math.Round(((double)placesTaken / this.PlacesPerSector) * 100));
                output
                    .AppendFormat(format, i + 1, placesTaken, this.PlacesPerSector, percentageTaken)
                    .AppendLine();
            }

            return string.Join(Environment.NewLine, output);
        }

        public string FindVehicleByLicensePlate(string licencePlateNumber)
        {
            var vehicle = (data.VehiclesByLicenseNumber.ContainsKey(licencePlateNumber)) ? data.VehiclesByLicenseNumber[licencePlateNumber] : null;
            return vehicle == null ? string.Format("There is no vehicle with license plate {0} in the park", licencePlateNumber) : Input(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (data.VehiclesByLocation.Values.All(v => v.Owner != owner))
            {
                return string.Format("No vehicles by {0}", owner);
            }
             
            var found = data.VehiclesByLocation.Values.ToList();
            var res = found;
            res = res.Where(v => v.Owner == owner).ToList();
            return string.Join(Environment.NewLine, Input(res));
        }

        private string Input(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(Environment.NewLine, vehicles.Select(vehicle => string
                .Format("{0}{1}Parked at {2}", 
                vehicle.ToString(), Environment.NewLine, data.VehicleLocation[vehicle])));
        }
    }
}


