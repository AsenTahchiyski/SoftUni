using MassEffect.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassEffect.GameObjects.Projectiles
{
    class Laser : Projectile
    {
        public Laser(int damage) : base(damage)
        {
        }

        public override void Hit(IStarship targetShip)
        {
            if (targetShip.Shields >= this.Damage)
            {
                targetShip.Shields -= this.Damage;
            }
            else
            {
                targetShip.Health -= this.Damage - targetShip.Shields;
                targetShip.Shields = 0;
            }
        }
    }
}
