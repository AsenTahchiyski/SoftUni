namespace WinterIsComing.Models.CombatHandlers
{
    using Contracts;
    using System.Collections.Generic;
    using Core;
    using Core.Exceptions;
    using Spells;
    using System.Linq;

    public class IceGiantCombatHandler : CombatHandler
    {
        private const int DefaultHealthTriggerTargets = 150;
        private const int DefaultAttackIncreasePoints = 5;

        public IceGiantCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public new IUnit Unit { get; private set; }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints > DefaultHealthTriggerTargets)
            {
                return candidateTargets;
            }
            IUnit enemy = candidateTargets.FirstOrDefault();
            if (enemy == null)
            {
                return new List<IUnit>();
            }
            return new List<IUnit>{enemy};
        }

        public override ISpell GenerateAttack()
        {
            int energyCost = new Stomp(0).EnergyCost;
            if (this.Unit.EnergyPoints > energyCost)
            {
                this.Unit.EnergyPoints -= energyCost;
                var currentAttack = new Stomp(this.Unit.AttackPoints);
                this.Unit.AttackPoints += DefaultAttackIncreasePoints;
                return currentAttack;
            }
            throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, "Stomp"));
        }
    }
}
