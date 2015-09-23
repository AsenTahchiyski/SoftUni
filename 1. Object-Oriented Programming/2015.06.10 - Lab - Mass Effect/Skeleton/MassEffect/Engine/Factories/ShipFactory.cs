namespace MassEffect.Engine.Factories
{
    using System;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;

    public class ShipFactory
    {
        public IStarship CreateShip(StarshipType type, string name, StarSystem location)
        {
            switch (type)
            {
                case StarshipType.Frigate:
                    return new Frigate(name, 60, 50, 30, 220, location);
                case StarshipType.Cruiser:
                    return new Cruiser(name, 100, 100, 50, 300, location);
                case StarshipType.Dreadnought:
                    return new Dreadnought(name, 200, 300, 150, 700, location);
                default:
                    throw new NotSupportedException("Starship type not supported.");
            }
        }
    }
}
