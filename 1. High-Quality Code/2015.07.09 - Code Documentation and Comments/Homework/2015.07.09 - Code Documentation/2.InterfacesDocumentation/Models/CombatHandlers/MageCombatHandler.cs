namespace WinterIsComing.Models.CombatHandlers
{
    using Contracts;
    using System.Collections.Generic;
    using Spells;
    using System;
    using System.Linq;
    using Core;
    using Core.Exceptions;

    public class MageCombatHandler : CombatHandler
    {
        public MageCombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }

        public new IUnit Unit { get; private set; }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var ordered = candidateTargets
                .OrderByDescending(t => t.HealthPoints)
                .ThenBy(t => t.Name)
                .ToList();
            var targets = new List<IUnit>();
            for (int i = 0; i < Math.Min(3, ordered.Count); i++)
            {
                if (ordered[i] != null)
                {
                    targets.Add(ordered[i]);
                }
            }
            return targets;
        }

        private string lastSuccessfulAttack = "Blizzard";

        public override ISpell GenerateAttack()
        {
            if (lastSuccessfulAttack == "FireBreath")
            {
                int energyCost = new Blizzard(0).EnergyCost;
                if (this.Unit.EnergyPoints >= energyCost)
                {
                    lastSuccessfulAttack = "Blizzard";
                    this.Unit.EnergyPoints -= energyCost;
                    return new Blizzard(this.Unit.AttackPoints * 2);
                }
            }
            else if (lastSuccessfulAttack == "Blizzard")
            {
                int energyCost = new FireBreath(0).EnergyCost;
                if (this.Unit.EnergyPoints >= energyCost)
                {
                    lastSuccessfulAttack = "FireBreath";
                    this.Unit.EnergyPoints -= energyCost;
                    return new FireBreath(this.Unit.AttackPoints);
                }
            }
            
            throw new NotEnoughEnergyException(string.Format(GlobalMessages.NotEnoughEnergy, this.Unit.Name, lastSuccessfulAttack == "Blizzard" ? "FireBreath" : "Blizzard"));
        }
    }
}
