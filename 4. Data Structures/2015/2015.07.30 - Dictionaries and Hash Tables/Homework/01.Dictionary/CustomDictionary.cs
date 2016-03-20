namespace Dictionary
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomDictionary<TKey, TValue> : IEnumerable<TKey>
    {
        public const int DefaultCapacity = 16;
        
        private readonly HashTable<TKey, TValue> hashTable;

        public CustomDictionary(int capacity = DefaultCapacity)
        {
            this.hashTable = new HashTable<TKey, TValue>(capacity);
        }

        public void Add(TKey key, TValue value)
        {
            this.hashTable.Add(key, value);
        }

        public void Clear()
        {
            this.hashTable.Clear();
        }

        public bool ContainsKey(TKey key)
        {
            return this.hashTable.ContainsKey(key);
        }

        public bool ContainsValue(TValue value)
        {
            return this.Values.Contains(value);
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            return this.hashTable.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.hashTable.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return this.hashTable.GetHashCode();
        }

        public void Remove(TKey key)
        {
            this.hashTable.Remove(key);
        }

        public override string ToString()
        {
            return this.hashTable.ToString();
        }

        public TValue Get(TKey key)
        {
            return this.hashTable.Get(key);
        }

        public TValue this[TKey key]
        {
            get
            {
                return this.hashTable.Get(key);
            }

            set
            {
                this.hashTable.AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return this.hashTable.TryGetValue(key, out value);
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            return this.hashTable.Find(key);
        }

        public IEnumerable<TKey> Keys
        {
            get
            {
                return this.hashTable.Select(element => element.Key);
            }
        }

        public IEnumerable<TValue> Values
        {
            get
            {
                return this.hashTable.Select(element => element.Value);
            }
        }

        public int Count
        {
            get
            {
                return this.hashTable.Count;
            }
        }
    }
}
