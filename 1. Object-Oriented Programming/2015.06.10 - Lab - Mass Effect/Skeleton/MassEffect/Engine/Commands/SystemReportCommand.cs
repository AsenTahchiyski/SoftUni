using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.Engine.Commands
{
    class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) : base(gameEngine)
        {
        }
        
        public override void Execute(string[] commandArgs)
        {
            string locationName = commandArgs[1];

            IEnumerable<IStarship> ships = (IEnumerable<IStarship>)this.GameEngine.Starships.Where(s => s.Location.Name == locationName);

            var intactShips = ships.Where(s => s.Health > 0).OrderByDescending(s => s.Health).ThenByDescending(s => s.Shields);
            var destroyedShips = ships.Where(s => s.Health == 0).OrderBy(s => s.Name);

            StringBuilder output = new StringBuilder();
            if (intactShips.Any())
            {
                foreach (var intactShip in intactShips)
                {
                    Console.WriteLine(intactShip);
                }
            }
            else
            {
                Console.WriteLine("N/A");
            }

            if (destroyedShips.Any())
            {
                foreach (var destroyedShip in destroyedShips)
                {
                    Console.WriteLine(destroyedShip);
                }
            }
            else
            {
                Console.WriteLine("N/A");
            }

        }
    }
}
