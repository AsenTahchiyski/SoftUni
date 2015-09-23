namespace WinterIsComing.Models.Units
{
    using Contracts;
    using Core;
    using Core.Exceptions;
    using System.Text;

    public abstract class Unit : IUnit
    {
        private int x;
        private int y;
        private string name;
        private int attackPoints;
        private int healthPoints;
        private int defensePoints;
        private int energyPoints;
        private int range;

        protected Unit(int x, int y, string name, int attack, int health, int defense, int energy, int range)
        {
            this.X = x;
            this.Y = y;
            this.Name = name;
            this.AttackPoints = attack;
            this.HealthPoints = health;
            this.DefensePoints = defense;
            this.EnergyPoints = energy;
            this.Range = range;
        }

        public int X
        {
            get { return this.x; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidPositionException(GlobalMessages.InvalidPosition);
                }
                this.x = value;
            }
        }

        public int Y
        {
            get { return this.y; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidPositionException(GlobalMessages.InvalidPosition);
                }
                this.y = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new GameException(string.Format(MoreGlobalMessages.ParameterRequired, "name"));
                }
                this.name = value;
            }
        }

        public int Range
        {
            get { return this.range; }
            private set
            {
                if (value <= 0)
                {
                    throw new GameException(string.Format(MoreGlobalMessages.ParameterPositive, "range"));
                }
                this.range = value;
            }
        }

        public int AttackPoints
        {
            get { return this.attackPoints; }
            set
            {
                if (value <= 0)
                {
                    throw new GameException(string.Format(MoreGlobalMessages.ParameterPositive, "attack points"));
                }
                this.attackPoints = value;
            }
        }

        public int HealthPoints
        {
            get { return this.healthPoints; }
            set
            {
                if (value < 0)
                {
                    this.healthPoints = 0;
                }
                this.healthPoints = value;
            }
        }

        public int DefensePoints
        {
            get { return this.defensePoints; }
            set
            {
                if (value <= 0)
                {
                    throw new GameException(string.Format(MoreGlobalMessages.ParameterPositive, "defense points"));
                }
                this.defensePoints = value;
            }
        }

        public int EnergyPoints
        {
            get { return this.energyPoints; }
            set
            {
                if (value <= 0)
                {
                    throw new GameException(string.Format(MoreGlobalMessages.ParameterPositive, "energy points"));
                }
                this.energyPoints = value;
            }
        }

        public ICombatHandler CombatHandler { get; protected set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format(">{0} - {1} at ({2},{3})", 
                this.Name, this.GetType().Name, this.X, this.Y));
            if (this.HealthPoints > 0)
            {
                output.AppendLine(string.Format("-Health points = {0}", this.HealthPoints));
                output.AppendLine(string.Format("-Attack points = {0}", this.AttackPoints));
                output.AppendLine(string.Format("-Defense points = {0}", this.DefensePoints));
                output.AppendLine(string.Format("-Energy points = {0}", this.EnergyPoints));
                output.AppendLine(string.Format("-Range = {0}", this.Range));
            }
            else
            {
                output.AppendLine("(Dead)");
            }
            return output.ToString().TrimEnd();
        }
    }
}
