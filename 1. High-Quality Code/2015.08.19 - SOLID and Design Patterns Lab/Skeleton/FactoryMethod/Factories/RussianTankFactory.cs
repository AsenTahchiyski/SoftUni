namespace FactoryMethod.Factories
{
    using Interfaces;
    using Units;

    public class RussianTankFactory : TankFactory
    {
        public override ITank CreateTank()
        {
            return new T34();
        }
    }
}
