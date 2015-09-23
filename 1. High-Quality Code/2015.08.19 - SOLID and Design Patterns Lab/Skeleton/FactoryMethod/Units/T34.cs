namespace FactoryMethod.Units
{
    using TankManufacturer.Units;

    public class T34 : Tank
    {
        private const double DefaultT34Speed = 3.3;
        private const int DefaultT34Damage = 75;
        private const string DefaultT34Name = "T-34";

        public T34()
            : base(DefaultT34Name, DefaultT34Speed, DefaultT34Damage)
        {
        }
    }
}
