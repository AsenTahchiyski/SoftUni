namespace FactoryMethod.Units
{
    using TankManufacturer.Units;

    public class M1Abrams : Tank
    {
        private const double DefaultM1AbramsSpeed = 5.4;
        private const int DefaultM1AbramsDamage = 120;
        private const string DefaultM1AbramsName = "M1 Abrams";
        
        public M1Abrams()
            : base(DefaultM1AbramsName, DefaultM1AbramsSpeed, DefaultM1AbramsDamage)
        {
        }
    }
}
