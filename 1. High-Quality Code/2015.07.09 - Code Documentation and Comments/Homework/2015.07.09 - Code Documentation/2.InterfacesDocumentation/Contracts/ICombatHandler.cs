namespace WinterIsComing.Contracts
{
    using System.Collections.Generic;

    /// <summary>
    /// The combat handler interface aims to assure that all combat handler classes that implement it have a Unit property and methods for choosing the next target(s) and attacking it/them.
    /// </summary>
    public interface ICombatHandler
    {
        /// <summary>
        /// The Unit property is necessary in order to provide the unit characteristics and parameters, needed so the methods below work properly.
        /// </summary>
        IUnit Unit { get; set; }

        /// <summary>
        /// This method is responsible for the provision of the targets that are to be attacked.
        /// </summary>
        /// <param name="candidateTargets">Enumeration of all targets that can be attacked.</param>
        /// <returns>A list of targets to be attacked, based on the character's class abilities.</returns>
        IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        /// <summary>
        /// This method generates the attack, which is different for every character class in the game.
        /// </summary>
        /// <returns>ISpell attack with specific Damage and Energy cost.</returns>
        ISpell GenerateAttack();
    }
}
