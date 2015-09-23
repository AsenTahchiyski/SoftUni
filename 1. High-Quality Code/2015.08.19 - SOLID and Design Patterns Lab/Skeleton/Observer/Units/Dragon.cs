namespace Skyrim.Units
{
    using System.Collections.Generic;
    using Items;

    public class Dragon : Unit
    {
        private readonly IList<Warrior> warriors;
        private int health;

        public Dragon(string name, int attackPoints, int healthPoints) 
            : base(name, attackPoints, healthPoints)
        {
            this.warriors = new List<Warrior>();
        }

        public override int HealthPoints
        {
            get { return this.health; }
            set
            {
                this.health = value;

                if (this.health <= 0)
                {
                    Notify();
                }
            }
        }

        public void Attach(Warrior warrior)
        {
            this.warriors.Add(warrior);
        }

        public void Detach(Warrior warrior)
        {
            this.warriors.Remove(warrior);
        }

        public void Notify()
        {
            foreach (var warrior in warriors)
            {
                warrior.Update(new Weapon(20, 50));
            }
        }
    }
}
