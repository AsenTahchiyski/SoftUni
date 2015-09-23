using System;
using MassEffect.Interfaces;
using MassEffect.GameObjects.Locations;
using MassEffect.GameObjects.Enhancements;
using System.Collections.Generic;
using System.Text;

namespace MassEffect.GameObjects.Ships
{
    public abstract class Starship : IStarship
    {
        private string name;
        private int health;
        private int shields;
        private int damage;
        private double fuel;
        private StarSystem location;
        private StarshipType type;
        private IList<Enhancement> enhancements;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Starship name cannot be empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health must be non-negative.");
                }
                this.health = value;
            }
        }

        public int Shields
        {
            get
            {
                return this.shields;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Shields must be non-negative.");
                }
                this.shields = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage must be non-negative.");
                }
                this.damage = value;
            }
        }

        public double Fuel
        {
            get
            {
                return this.fuel;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Fuel must be non-negative.");
                }
                this.fuel = value;
            }
        }

        public StarSystem Location { get; set; }

        public StarshipType Type { get; set; }

        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }

        public abstract IProjectile ProduceAttack();

        public void AddEnhancement(Enhancement enhancement)
        {
            if (enhancement == null)
            {
                throw new ArgumentNullException("Enhancement cannot be null");
            }
            this.enhancements.Add(enhancement);
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
            this.Damage += enhancement.DamageBonus;
        }

        public Starship(string name, int health, int shields, int damage, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));
            if (this.Health <= 0)
            {
                output.Append("(Destroyed)");
            }
            else
            {
                output.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                output.AppendLine(string.Format("-Health: {0}", this.Health));
                output.AppendLine(string.Format("-Shields: {0}", this.Shields));
                output.AppendLine(string.Format("-Damage: {0}", this.Damage));
                output.AppendLine(string.Format("-Fuel: {0}", this.Fuel));
                if (this.enhancements != null || this.enhancements.Count == 0)
                {
                    output.AppendLine(string.Format("-Enhancements: {0}", string.Join(", ", this.enhancements)));
                }
                else
                {
                    output.AppendLine("N/A");
                }
            }
            return output.ToString();
        }

        public virtual void RespondToAttack(IProjectile projectile)
        {
            projectile.Hit(this);
        }
    }
}
