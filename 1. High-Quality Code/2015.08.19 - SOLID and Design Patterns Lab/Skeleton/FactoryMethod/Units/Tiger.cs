namespace FactoryMethod.Units
{
    using TankManufacturer.Units;

    public class Tiger : Tank
    {
        private const double DefaultTigerSpeed = 4.5;
        private const int DefaultTigerDamage = 120;
        private const string DefaultTigerName = "Tiger";
        
        public Tiger()
            : base(DefaultTigerName, DefaultTigerSpeed, DefaultTigerDamage)
        {
        }
    }
}
