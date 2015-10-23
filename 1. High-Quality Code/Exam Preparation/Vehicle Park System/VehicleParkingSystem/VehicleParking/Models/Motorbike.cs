namespace VehicleParkingSystem.Models
{
    public class Motorbike : Vehicle
    {
        private const decimal DefaultRegularRate = 1.35M;
        private const decimal DefaultOvertimeRate = 3;
        
        public Motorbike(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours)
        {
            this.RegularRate = DefaultRegularRate;
            this.OvertimeRate = DefaultOvertimeRate;
        }
    }
}
