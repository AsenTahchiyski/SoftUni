using System;
using MassEffect.GameObjects.Locations;
using System.Text;
using MassEffect.Interfaces;
using MassEffect.GameObjects.Projectiles;

namespace MassEffect.GameObjects.Ships
{
    public class Frigate : Starship
    {
        private int projectilesFired;

        public int ProjectilesFired 
        {
            get
            {
                return this.projectilesFired;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Projectiles fired cannot be negative.");
                }
                this.projectilesFired = value;
            }
        }

        public Frigate(string name, int health, int shields, int damage, double fuel, StarSystem location) : base(name, health, shields, damage, fuel, location)
        {
            this.Type = StarshipType.Frigate;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder(base.ToString());
            if (this.Health > 0)
            {
                output.AppendLine(string.Format("-Projectiles fired: {0}", this.ProjectilesFired));
            }
            return output.ToString();
        }

        public override IProjectile ProduceAttack()
        {
            projectilesFired++;
            return new ShieldReaver(this.Damage);
        }
    }
}
