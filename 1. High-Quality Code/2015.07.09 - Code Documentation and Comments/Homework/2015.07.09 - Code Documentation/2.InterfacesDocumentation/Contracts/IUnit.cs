namespace WinterIsComing.Contracts
{
    /// <summary>
    /// This interface ensures that all units implementing it will have the necessary properties in order for them to function properly with the rest of the game components.
    /// </summary>
    public interface IUnit
    {
        /// <summary>
        /// Ensures all units will have a valid X position on the game board.
        /// </summary>
        int X { get; set; }

        /// <summary>
        /// Ensures all units will have a valid Y position on the game board.
        /// </summary>
        int Y { get; set; }

        /// <summary>
        /// Ensures all units will have a valid name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Ensures all units will have a valid range.
        /// </summary>
        int Range { get; }

        /// <summary>
        /// Ensures that all units will be able to store their current attack points.
        /// </summary>
        int AttackPoints { get; set; }

        /// <summary>
        /// Ensures that all units will be able to store their current health points.
        /// </summary>
        int HealthPoints { get; set; }

        /// <summary>
        /// Ensures that all units will be able to store their current defense points.
        /// </summary>
        int DefensePoints { get; set; }

        /// <summary>
        /// Ensures that all units will be able to store their current energy points.
        /// </summary>
        int EnergyPoints { get; set; }

        /// <summary>
        /// Ensures that all units will have a combat handler, enabling them actively participate in the battle.
        /// </summary>
        ICombatHandler CombatHandler { get; }
    }
}
