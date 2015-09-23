namespace ArmyOfCreatures.Extended.Creatures
{
    using ArmyOfCreatures.Logic.Creatures;
    using ArmyOfCreatures.Logic.Specialties;

    public class Griffin : Creature
    {
        private const int DefaultGriffinAttack = 8;
        private const int DefaultGriffinDefense = 8;
        private const int DefaultGriffinHealth = 25;
        private const decimal DefaultGriffinDamage = 4.5m;
        private const int DefaultGriffinDoubleDefenseWhenDefendingRounds = 5;
        private const int DefaultAddDefensePointsWhenSkip = 3;

        public Griffin()
            : base(DefaultGriffinAttack, DefaultGriffinDefense, DefaultGriffinHealth, DefaultGriffinDamage)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(DefaultGriffinDoubleDefenseWhenDefendingRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(DefaultAddDefensePointsWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
