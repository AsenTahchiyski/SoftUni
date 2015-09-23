namespace WinterIsComing.Models.CombatHandlers
{
    using Contracts;
    using System.Collections.Generic;
    using Spells;
    using Core;
    using Core.Exceptions;
    using System.Linq;

    public class WarriorCombatHandler : CombatHandler
    {
        private const int DefaultWarriorAddHealthToDamageThreshold = 80;
        private const int DefaultWarriorFreeEnergyHealthThreshold = 50;
        
        public WarriorCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }
        
        public new IUnit Unit { get; private set; }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            List<IUnit> sortedTargets = candidateTargets
                .OrderBy(t => t.HealthPoints)
                .ThenBy(t => t.Name)
                .ToList();
            List<IUnit> foundTarget = new List<IUnit>();
            if (sortedTargets.Any())
            {
                foundTarget.Add(sortedTargets[0]);
            }
            return foundTarget;
        }

        public override ISpell GenerateAttack()
        {
            int energyCost = new Cleave(0).EnergyCost;
            if (this.Unit.EnergyPoints > energyCost)
            {
                if (Unit.HealthPoints > DefaultWarriorFreeEnergyHealthThreshold)
                {
                    this.Unit.EnergyPoints -= energyCost;
                }
                if (this.Unit.HealthPoints > DefaultWarriorAddHealthToDamageThreshold)
                {
                    return new Cleave(this.Unit.AttackPoints);
                }
                return new Cleave(this.Unit.AttackPoints + 2 * this.Unit.HealthPoints);
            }
            
            throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, "Cleave"));
        }
    }
}
