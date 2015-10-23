namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the actions a repository should be able to perform.
    /// </summary>
    /// <typeparam name="T">Type of the data stored in the repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Provides IEnumerable of all objects stored in the repository.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Provides a specific object with a given ID.
        /// </summary>
        /// <param name="id">Object ID integer.</param>
        /// <returns></returns>
        T Get(int id);
        
        /// <summary>
        /// Adds a given object to the repository.
        /// </summary>
        /// <param name="item">The object to add.</param>
        void Add(T item);
    }
}
