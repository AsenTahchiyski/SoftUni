namespace WinterIsComing.Contracts
{
    /// <summary>
    /// This interface ensires that all spell attacks implementing it will have Damage and Energy cost properties.
    /// </summary>
    public interface ISpell
    {
        /// <summary>
        /// This property keeps the damage that the current attack deals to the enemy.
        /// </summary>
        int Damage { get; }

        /// <summary>
        /// This property keeps the energy cost of the current attack.
        /// </summary>
        int EnergyCost { get; }
    }
}
