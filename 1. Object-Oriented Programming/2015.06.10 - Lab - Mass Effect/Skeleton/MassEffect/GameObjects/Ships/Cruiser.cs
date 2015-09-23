using System;
using MassEffect.GameObjects.Locations;
using MassEffect.Interfaces;
using MassEffect.GameObjects.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    public class Cruiser : Starship
    {
        public Cruiser(string name, int health, int shields, int damage, double fuel, StarSystem location) : base(name, health, shields, damage, fuel, location)
        {
            this.Type = StarshipType.Cruiser;
        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
