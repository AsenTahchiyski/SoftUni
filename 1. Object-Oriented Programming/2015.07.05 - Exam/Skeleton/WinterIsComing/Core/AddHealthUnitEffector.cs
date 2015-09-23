namespace WinterIsComing.Core
{
    using Contracts;
    using System.Collections.Generic;

    public class AddHealthUnitEffector : IUnitEffector
    {
        private const int HealthToAdd = 50;

        public void ApplyEffect(IEnumerable<IUnit> units)
        {
            foreach (IUnit unit in units)
            {
                unit.HealthPoints += HealthToAdd;
            }
        }
    }
}
