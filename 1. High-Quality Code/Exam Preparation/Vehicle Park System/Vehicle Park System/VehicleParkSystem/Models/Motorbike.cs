namespace VehicleParkSystem.Models
{
    public class Motorbike : Vehicle
    {
        private const decimal DefaultRegularRateMotorcycle = 1.35m;
        private const decimal DefaultOvertimeRateMotorcycle = 3m;
        
        public Motorbike(string licensePlate, string owner, int reservedHours)
            :base(licensePlate, owner, reservedHours, DefaultRegularRateMotorcycle, DefaultOvertimeRateMotorcycle)
        {
        }
    }
}
