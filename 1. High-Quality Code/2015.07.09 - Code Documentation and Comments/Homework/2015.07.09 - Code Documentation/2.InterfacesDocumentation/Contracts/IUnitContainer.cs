namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface ensures all unit containers implementing it will know how to add, remove and move units to/from the game board, as well as get all units in a specified range for a given position.
    /// </summary>
    public interface IUnitContainer
    {
        /// <summary>
        /// Ensures all unit containers will be able to get all units in a given range for a specific position.
        /// </summary>
        /// <param name="x">Position X coordinate.</param>
        /// <param name="y">Position Y coordinate.</param>
        /// <param name="range">Range to check for enemy units.</param>
        /// <returns>Enumeration of all enemy units in the given range for the specified position.</returns>
        IEnumerable<IUnit> GetUnitsInRange(int x, int y, int range);

        /// <summary>
        /// Ensures all unit containers will be able to add units to the game board.
        /// </summary>
        /// <param name="unit">Unit to add.</param>
        void Add(IUnit unit);

        /// <summary>
        /// Ensures all unit containers will be able to remove units from the game board.
        /// </summary>
        /// <param name="unit">Unit to remove.</param>
        void Remove(IUnit unit);

        /// <summary>
        /// Ensures all unit containers will be able to move units on the game board.
        /// </summary>
        /// <param name="unit">Unit to move.</param>
        /// <param name="newX">X coordinate of the new position.</param>
        /// <param name="newY">Y coordinate of the new position.</param>
        void Move(IUnit unit, int newX, int newY);
    }
}
