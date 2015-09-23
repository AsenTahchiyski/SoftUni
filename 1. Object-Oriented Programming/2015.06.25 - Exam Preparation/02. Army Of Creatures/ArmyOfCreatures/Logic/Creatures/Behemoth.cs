namespace ArmyOfCreatures.Logic.Creatures
{
    using Specialties;

    public class Behemoth : Creature
    {
        private const int DefaultBehemothAttack = 20;
        private const int DefaultBehemothDefense = 20;
        private const int DefaultBehemothHealth = 200;
        private const decimal DefaultBehemothDamage = 50;
        private const int BehemothEnemyDefenseReductionPercentage = 40;

        public Behemoth()
            : base(DefaultBehemothAttack, DefaultBehemothDefense, DefaultBehemothHealth, DefaultBehemothDamage)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(BehemothEnemyDefenseReductionPercentage));
        }
    }
}
