namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Battles;
    using System.Globalization;

    public class DoubleDamage : Specialty
    {
        private int doubleDamageRounds;
        private int doubleDamageMinRounds = 0;
        private int doubleDamageMaxRounds = 10;
        private decimal currentDamage;

        public DoubleDamage(int rounds)
        {
            this.Rounds = rounds;
        }

        public int Rounds 
        {
            get
            {
                return this.doubleDamageRounds;
            }
            set
            {
                if (value < doubleDamageMinRounds || value > doubleDamageMaxRounds)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Invalid number of rounds, should be between {0} and {1}.", doubleDamageMinRounds, doubleDamageMaxRounds));
                }
                this.doubleDamageRounds = value;
            }
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender, decimal currentDamage)
        {
            this.currentDamage = currentDamage;
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.Rounds <= 0)
            {
                return currentDamage;
            }

            this.Rounds--;
            return currentDamage * 2;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
        }
        
        public override void ApplyWhenDefending(ICreaturesInBattle defenderWithSpecialty, ICreaturesInBattle attacker)
        {
        }

        public override void ApplyAfterDefending(ICreaturesInBattle defenderWithSpecialty)
        {
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Rounds);
        }
    }
}
