namespace TheSlum.Characters
{
    using Interfaces;
    using System.Linq;
    using System.Collections.Generic;

    class Healer : CharacterUpgrade, IHeal
    {
        public Healer(string id, int x, int y, Team team) : base(id, x, y, 75, 50, team, 6, 60)
        {
            this.HealingPoints = 60;
        }

        public int HealingPoints { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Name: {0}, Team: {2}, Health: {1}, Defense: {3}, Healing: {4}",
                this.Id,
                this.HealthPoints,
                this.Team,
                this.DefensePoints,
                this.HealingPoints);
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            // healer - always picks the target with least health and not himself
            var target = targetsList.FirstOrDefault(character => (character.Team == this.Team && character.IsAlive && character.Id != this.Id));
            return target;
        }

    }
}
