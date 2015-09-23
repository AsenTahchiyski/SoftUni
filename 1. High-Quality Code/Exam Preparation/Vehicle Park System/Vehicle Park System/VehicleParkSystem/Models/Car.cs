namespace VehicleParkSystem.Models
{
    public class Car : Vehicle
    {
        private const decimal DefaultRegularRateCar = 2;
        private const decimal DefaultOvertimeRateCar = 3.5m;

        public Car(string licensePlate, string owner, int reservedHours)
            : base(licensePlate, owner, reservedHours, DefaultRegularRateCar, DefaultOvertimeRateCar)
        {
        }
    }
}
