namespace VehicleParkingSystem.Models
{
    public class Car : Vehicle
    {
        private const decimal DefaultRegularRate = 2;
        private const decimal DefaultOvertimeRate = 3.5M;
        
        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours)
        {
            this.RegularRate = DefaultRegularRate;
            this.OvertimeRate = DefaultOvertimeRate;
        }
    }
}
