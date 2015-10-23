namespace HotelBookingSystem.Data
{
    using System.Collections.Generic;
    using Interfaces;

    public class Repository<T> : IRepository<T> where T : IDbEntity
    {
        private int nextAddId = 1;
        private SortedDictionary<int, T> items;

        public Repository()
        {
            this.items = new SortedDictionary<int, T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            // PERFORMANCE: use ordered collection
            return this.items.Values;
        }

        public virtual T Get(int id)
        {
            T item;
            try
            {
                item = this.items[id];
            }
            catch (KeyNotFoundException)
            {
                item = default(T);
            }

            return item;
        }

        public virtual void Add(T item)
        {
            item.Id = this.nextAddId;
            this.items.Add(this.nextAddId, item);
            this.nextAddId++;
        }

        public virtual bool Update(int id, T newItem)
        {
            var item = this.Get(id);
            if (item == null)
            {
                return false;
            }

            return true;
        }

        public virtual bool Delete(int id)
        {
            return this.items.Remove(id);
        }
    }
}