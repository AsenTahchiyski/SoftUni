namespace TheSlum.Characters
{
    using System.Linq;
    using System.Collections.Generic;

    abstract class CharacterUpgrade : Character
    {
        public int AttackPoints { get; set; }

        public CharacterUpgrade(string id, int x, int y, int healthPoints, int defensePoints, Team team, int range, int attackPoints) : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.AttackPoints = attackPoints;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        protected override void ApplyItemEffects(Item item)
        {
            this.HealthPoints += item.HealthEffect;
            this.DefensePoints += item.DefenseEffect;
            this.AttackPoints += item.AttackEffect;
        }

        protected override void RemoveItemEffects(Item item)
        {
            this.HealthPoints -= item.HealthEffect;
            this.DefensePoints -= item.DefenseEffect;
            if (this.HealthPoints < 0)
            {
                this.HealthPoints = 1;
            }
            this.AttackPoints -= item.AttackEffect;
        }

        //public override Character GetTarget(IEnumerable<Character> targetsList)
        //{
        //    // warrior - always picks the first target
        //    // healer - always picks the target with least health and not himself
        //    // mage - always picks the last target
        //    var target = targetsList.FirstOrDefault(character => (character.Team != this.Team && character.IsAlive));
        //    return target;
        //}

        public override string ToString()
        {
            return string.Format(
                "Name: {0}, Team: {2}, Health: {1}, Defense: {3}, Attack: {4}",
                this.Id,
                this.HealthPoints,
                this.Team,
                this.DefensePoints,
                this.AttackPoints);
        }
    }
}
