using System;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;
using MassEffect.GameObjects.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    public class Dreadnought : Starship
    {
        public Dreadnought(string name, int health, int shields, int damage, double fuel, StarSystem location)
            : base(name, health, shields, damage, fuel, location)
        {
            this.Type = StarshipType.Dreadnought;
        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            base.RespondToAttack(attack);
            this.Shields -= 50;
        }
    }
}
