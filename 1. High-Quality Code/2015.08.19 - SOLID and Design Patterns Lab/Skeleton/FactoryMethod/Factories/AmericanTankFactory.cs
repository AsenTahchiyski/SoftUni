namespace FactoryMethod.Factories
{
    using Interfaces;
    using Units;

    public class AmericanTankFactory : TankFactory
    {
        public override ITank CreateTank()
        {
            return new M1Abrams();
        }
    }
}
