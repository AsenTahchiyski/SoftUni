namespace WinterIsComing.Models.Spells
{
    using Contracts;
    using Core;
    using Core.Exceptions;

    public abstract class Spell : ISpell
    {
        private int damage;
        private int energyCost;

        protected Spell(int damage, int energyCost)
        {
            this.EnergyCost = energyCost;
            this.Damage = damage;
        }

        public int Damage
        {
            get { return this.damage; }
            protected set
            {
                if (value < 0)
                {
                    throw new GameException(string.Format(MoreGlobalMessages.ParameterNonNegative, "damage"));
                }
                this.damage = value;
            }
        }

        public int EnergyCost
        {
            get { return this.energyCost; }
            private set
            {
                if (value < 0)
                {
                    throw new GameException(string.Format(MoreGlobalMessages.ParameterNonNegative, "energy cost"));
                }
                this.energyCost = value;
            }
        }
    }
}
