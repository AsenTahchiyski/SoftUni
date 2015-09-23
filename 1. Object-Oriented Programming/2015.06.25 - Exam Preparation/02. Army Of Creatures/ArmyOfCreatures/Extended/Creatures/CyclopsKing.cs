namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Extended.Specialties;
    using ArmyOfCreatures.Logic.Creatures;

    public class CyclopsKing : Creature
    {
        private const int DefaultCyclopsKingAttack = 17;
        private const int DefaultCyclopsKingDefense = 13;
        private const int DefaultCyclopsKingHealth = 70;
        private const decimal DefaultCyclopsKingDamage = 18;
        private const int DefaultCyclopsKingAddAttackWhenSkip = 3;
        private const int DefaultCyclopsKingDoubleAttackWhenAttacking = 4;
        private const int DefaultCyclopsKingDoubleDamage = 1;

        public CyclopsKing()
            : base(DefaultCyclopsKingAttack, DefaultCyclopsKingDefense, DefaultCyclopsKingHealth, DefaultCyclopsKingDamage)
        {
            this.AddSpecialty(new AddAttackWhenSkip(DefaultCyclopsKingAddAttackWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(DefaultCyclopsKingDoubleAttackWhenAttacking));
            this.AddSpecialty(new DoubleDamage(DefaultCyclopsKingDoubleDamage));
        }
    }
}
