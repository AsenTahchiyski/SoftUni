namespace MassEffect.Engine.Commands
{
    using MassEffect.Interfaces;
    using System.Linq;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Exceptions;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackerName = commandArgs[1];
            string targetName = commandArgs[2];

            IStarship attackingShip = (IStarship)GameEngine.Starships.Select(x => x.Name == attackerName);
            IStarship targetShip = (IStarship)GameEngine.Starships.Select(x => x.Name == targetName);

            this.ProcessShipBattle(attackingShip, targetShip);
        }

        private void ProcessShipBattle(IStarship attackingShip, IStarship targetShip)
        {
            base.ValidateAlive(attackingShip);
            base.ValidateAlive(targetShip);
            if (!ShipsInSameStarSystem(attackingShip, targetShip))
            {
                throw new LocationOutOfRangeException(Messages.NoSuchShipInStarSystem);
            }
            IProjectile attack = attackingShip.ProduceAttack();
            targetShip.RespondToAttack(attack);
            System.Console.WriteLine(Messages.ShipAttacked, attackingShip.Name, targetShip.Name);
            if (targetShip.Shields < 0)
            {
                targetShip.Shields = 0;
            }
            if (targetShip.Health <= 0)
            {
                targetShip.Health = 0;
                System.Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }
        }

        private bool ShipsInSameStarSystem(IStarship ship1, IStarship ship2)
        {
            if (ship1.Location.Name == ship2.Location.Name)
            {
                return true;
            }
            else return false;
        }
    }
}
