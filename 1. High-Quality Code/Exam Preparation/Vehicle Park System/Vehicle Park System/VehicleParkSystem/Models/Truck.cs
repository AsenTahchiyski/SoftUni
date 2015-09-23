namespace VehicleParkSystem.Models
{
    public class Truck : Vehicle
    {
        private const decimal DefaultRegularRateTruck = 4.75m;
        private const decimal DefaultOvertimeRateTruck = 6.2m;

        public Truck(string licensePlate, string owner, int reservedHours)
            :base(licensePlate, owner, reservedHours, DefaultRegularRateTruck, DefaultOvertimeRateTruck)
        {
        }
    }
}
