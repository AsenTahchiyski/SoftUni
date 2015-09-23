namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface ensures that all unit effectors implementing it will know how to apply their effects on the units in the game.
    /// </summary>
    public interface IUnitEffector
    {
        /// <summary>
        /// The method to apply an effector on the units.
        /// </summary>
        /// <param name="units">The units to apply the effector to.</param>
        void ApplyEffect(IEnumerable<IUnit> units);
    }
}
