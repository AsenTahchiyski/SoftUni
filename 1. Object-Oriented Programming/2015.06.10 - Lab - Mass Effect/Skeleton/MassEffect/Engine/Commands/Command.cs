namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using MassEffect.GameObjects.Ships;

    using MassEffect.Interfaces;
    using MassEffect.Exceptions;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        protected void ValidateAlive(IStarship ship)
        {
            if (ship.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
        }
    }
}
