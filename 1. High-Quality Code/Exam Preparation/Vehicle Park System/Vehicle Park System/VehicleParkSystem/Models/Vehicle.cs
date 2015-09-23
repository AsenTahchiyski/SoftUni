namespace VehicleParkSystem.Models
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

        protected Vehicle(string licensePlate, string owner, int reservedHours, decimal regularRate, decimal overtimeRate)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = reservedHours;
            this.RegularRate = regularRate;
            this.OvertimeRate = overtimeRate;
        }

        public string LicensePlate 
        {
            get
            {
                return licensePlate;
            }
            protected set
            {
                if (!Regex.IsMatch(value, @"[A-Z]{1,2}[0-9]{4}[A-Z]{2}"))
                {
                    throw new ArgumentException("The license plate number is invalid.");
                }

                licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return owner;
            }
            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("value", "The owner is required.");
                }

                owner = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return regularRate;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The regular rate must be non-negative.");
                }

                regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return overtimeRate;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The overtime rate must be non-negative.");
                }

                overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return reservedHours;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("value", "The reserved hours must be positive.");
                }

                reservedHours = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", this.GetType().Name, this.LicensePlate, this.Owner);
            return vehicle.ToString();
        }
    }
}
