namespace Theatre.Interfaces
{
    using System;
    using System.Collections.Generic;
    using DataModels;

    // Do not modify the interface members
    // Moving the interface to separate namespace is allowed
    // Adding XML documentation is allowed

    /// <summary>
    /// This interface defined the behaviour a database of theater performances should have in order to wirk with this application.
    /// </summary>
    internal interface IPerformanceDatabase
    {
        /// <summary>
        /// Adds a theatre to the database.
        /// </summary>
        /// <param name="theatre">Name of the theatre to add.</param>
        void AddTheatre(string theatre);

        /// <summary>
        /// Lists all theatres currently in the database.
        /// </summary>
        /// <returns>IEnumerable of the theatres.</returns>
        IEnumerable<string> ListTheatres();

        /// <summary>
        /// Adds a performance to the daabase.
        /// </summary>
        /// <param name="theatre">Name of the theatre the performance will happen at.</param>
        /// <param name="name">Name of the performance.</param>
        /// <param name="start">Date and time of the performance start.</param>
        /// <param name="duration">Duration of the performance.</param>
        /// <param name="price">Price of the performance ticket.</param>
        void AddPerformance(string theatre, string name, DateTime start, TimeSpan duration, decimal price);

        /// <summary>
        /// Lists all performances currently in the database.
        /// </summary>
        /// <returns>IEnumerable of all performances.</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Lists all performances in a given theatre.
        /// </summary>
        /// <param name="theatre">Name of the theatre.</param>
        /// <returns>IEnumerable of all performances in the given theatre.</returns>
        IEnumerable<Performance> ListPerformances(string theatre);
    }
}
