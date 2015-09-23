namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// This interface ensures that engines implementing it will be able to start and stop, insert, hold and remove units, write output information and toggle effectors.
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// Ensures that engines implementing it will have a method to start their execution.
        /// </summary>
        void Start();

        /// <summary>
        /// Ensures that engines implementing it will have a method to stop their execution.
        /// </summary>
        void Stop();

        /// <summary>
        /// Ensures that engines implementing it will have a method to add units to the game.
        /// </summary>
        /// <param name="unit"></param>
        void InsertUnit(IUnit unit);

        /// <summary>
        /// Ensures that engines implementing it will have a method to remove units from the game.
        /// </summary>
        /// <param name="unit"></param>
        void RemoveUnit(IUnit unit);

        /// <summary>
        /// Ensures that engines implementing it will have a property keeping all units in the game.
        /// </summary>
        IEnumerable<IUnit> Units { get; } 

        /// <summary>
        /// Ensures that engines implementing it will have a property keeping all units in the current game board.
        /// </summary>
        IUnitContainer UnitContainer { get; }

        /// <summary>
        /// Ensures that engines implementing it will have a way to write output data so the player knows what's going on.
        /// </summary>
        IOutputWriter OutputWriter { get; }

        /// <summary>
        /// Ensures that engines implementing it will be able to keep a unit effector property.
        /// </summary>
        IUnitEffector UnitEffector { get; }
    }
}
