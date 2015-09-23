namespace FactoryMethod.Factories
{
    using Interfaces;
    using Units;

    public class GermanTankFactory : TankFactory
    {
        public override ITank CreateTank()
        {
            return new Tiger();
        }
    }
}
