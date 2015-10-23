namespace HotelBookingSystem.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the actions a repository should be able to perform.
    /// </summary>
    /// <typeparam name="T">Type of data contained in the repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns all items'values currently in the repository.
        /// </summary>
        /// <returns>IEnumerable of the values.</returns>
        IEnumerable<T> GetAll();
      
        /// <summary>
        /// Returns an item based on id.
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>The item with the proivded id.</returns>
        T Get(int id);
        
        /// <summary>
        /// Adds an item to the repository.
        /// </summary>
        /// <param name="item">The item to add.</param>
        void Add(T item);
        
        /// <summary>
        /// Updates the details on existing item.
        /// </summary>
        /// <param name="id">Id of the item.</param>
        /// <param name="newItem">Updated item to replace the old one.</param>
        /// <returns>Boolean value stating if the operation is successfull.</returns>
        bool Update(int id, T newItem);
        
        /// <summary>
        /// Removes an item from the repository.
        /// </summary>
        /// <param name="id">Id of the item to remove.</param>
        /// <returns>Boolean value stating if the operation is successfull.</returns>
        bool Delete(int id);
    }
}
