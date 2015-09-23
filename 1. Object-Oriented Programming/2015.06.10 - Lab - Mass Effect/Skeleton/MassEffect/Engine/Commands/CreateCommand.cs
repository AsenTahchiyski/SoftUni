namespace MassEffect.Engine.Commands
{
    using MassEffect.GameObjects.Ships;
    using MassEffect.Engine.Factories;
    using MassEffect.GameObjects.Enhancements;
    using MassEffect.Interfaces;
    using MassEffect.Exceptions;
    using MassEffect.Engine;
    using System;
    using System.Linq;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string type = commandArgs[1];
            string shipName = commandArgs[2];
            string locationName = commandArgs[3];

            bool shipAlreadyExists = this.GameEngine.Starships.Any(s => s.Name == shipName);

            if (shipAlreadyExists)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            StarshipType shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);
            var ship = GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            GameEngine.Starships.Add(ship);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);
                Enhancement enhancement = GameEngine.EnhancementFactory.Create(enhancementType);
                ship.AddEnhancement(enhancement);
            }
            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
