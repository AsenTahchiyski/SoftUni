namespace TheSlum.Characters
{
    using Interfaces;
    using System.Linq;
    using System.Collections.Generic;

    class Warrior : CharacterUpgrade, IAttack
    {
        public Warrior(string id, int x, int y, Team team) : base(id, x, y, 200, 100, team, 2, 150)
        {
            this.AttackPoints = 150;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            // warrior - always picks the first target
            var target = targetsList.FirstOrDefault(character => (character.Team != this.Team && character.IsAlive));
            return target;
        }
    }
}
