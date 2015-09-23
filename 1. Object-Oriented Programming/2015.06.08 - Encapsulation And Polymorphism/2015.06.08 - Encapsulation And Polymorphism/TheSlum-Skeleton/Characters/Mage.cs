namespace TheSlum.Characters
{
    using Interfaces;
    using System.Linq;
    using System.Collections.Generic;

    class Mage : CharacterUpgrade, IAttack
    {
        public Mage(string id, int x, int y, Team team) : base(id, x, y, 150, 50, team, 5, 300)
        {
            this.AttackPoints = 300;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            // mage - always picks the last target
            var target = targetsList.LastOrDefault(character => (character.Team != this.Team && character.IsAlive));
            return target;
        }
    }
}
