using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class Mage : Unit
    {
        private const int DefaultAttackPoints = 80;
        private const int DefaultHealthPoints = 80;
        private const int DefaultDefensePoints = 40;
        private const int DefaultEnergyPoints = 120;
        private const int DefaultRange = 2;

        public Mage(int x, int y, string name)
            : base(x, y, name, DefaultAttackPoints, DefaultHealthPoints, DefaultDefensePoints, DefaultEnergyPoints, DefaultRange)
        {
            this.CombatHandler = new MageCombatHandler(this);
        }
    }
}
