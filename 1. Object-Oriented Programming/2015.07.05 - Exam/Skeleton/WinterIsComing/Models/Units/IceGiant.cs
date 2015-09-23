using WinterIsComing.Models.CombatHandlers;

namespace WinterIsComing.Models.Units
{
    public class IceGiant : Unit
    {
        private const int DefaultAttackPoints = 150;
        private const int DefaultHealthPoints = 300;
        private const int DefaultDefensePoints = 60;
        private const int DefaultEnergyPoints = 50;
        private const int DefaultRange = 1;

        public IceGiant(int x, int y, string name)
            : base(x, y, name, DefaultAttackPoints, DefaultHealthPoints, DefaultDefensePoints, DefaultEnergyPoints, DefaultRange)
        {
            this.CombatHandler = new IceGiantCombatHandler(this);
        }
    }
}
