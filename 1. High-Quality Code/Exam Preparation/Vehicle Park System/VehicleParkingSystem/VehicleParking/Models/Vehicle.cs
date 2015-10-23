namespace VehicleParkingSystem.Models
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private string licensePlate;
        private string owner;
        private decimal regularRate;
        private decimal overtimeRate;
        private int reservedHours;
        private DateTime timeOfEntry;
        
        protected Vehicle(string licensePlate, string owner, int reserverHours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = reserverHours;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            protected set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2,}$"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidCastException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidTimeZoneException(string.Format("The regular rate must be non-negative."));
                }

                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overtimeRate;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException(string.Format("The overtime rate must be non-negative."));
                }

                this.overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.reservedHours;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.reservedHours = value;
            }
        }

        public DateTime TimeOfEntry { get; set; }
        
        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{2}], owned by {1}", GetType().Name, this.LicensePlate, this.Owner);
            return vehicle.ToString();
        }
    }
}
