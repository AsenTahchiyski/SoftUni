namespace FactoryMethod.Factories
{
    using Interfaces;

    public abstract class TankFactory : ITankFactory
    {
        public abstract ITank CreateTank();
    }
}
