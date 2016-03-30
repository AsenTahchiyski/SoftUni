using System;
using System.Collections.Generic;

namespace p2.BiDictionary
{
    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey;
        private Dictionary<K2, List<T>> valuesBySecondKey;
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKeys;

        public BiDictionary()
        {
            this.valuesByFirstKey = new Dictionary<K1, List<T>>();
            this.valuesBySecondKey = new Dictionary<K2, List<T>>();
            this.valuesByBothKeys = new Dictionary<Tuple<K1, K2>, List<T>>();
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            if (!this.valuesByFirstKey.ContainsKey(key1))
            {
                this.valuesByFirstKey.Add(key1, new List<T>());
            }
            this.valuesByFirstKey[key1].Add(value);

            if (!this.valuesBySecondKey.ContainsKey(key2))
            {
                this.valuesBySecondKey.Add(key2, new List<T>());
            }
            this.valuesBySecondKey[key2].Add(value);

            var tuple = new Tuple<K1, K2>(key1, key2);
            if (!this.valuesByBothKeys.ContainsKey(tuple))
            {
                this.valuesByBothKeys.Add(tuple, new List<T>());
            }
            this.valuesByBothKeys[tuple].Add(value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            var result = new List<T>();
            if (this.valuesByBothKeys.ContainsKey(tuple))
            {
                result = this.valuesByBothKeys[tuple];
            }

            Console.WriteLine("[{0}]", string.Join(", ", result));
            return result;
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            var result = new List<T>();
            if (this.valuesByFirstKey.ContainsKey(key1))
            {
                result = this.valuesByFirstKey[key1];
            }

            Console.WriteLine("[{0}]", string.Join(", ", result));
            return result;
        }

        public IEnumerable<T> FindByKey2(K2 key2)
        {
            var result = new List<T>();
            if (this.valuesBySecondKey.ContainsKey(key2))
            {
                result = this.valuesBySecondKey[key2];
            }

            Console.WriteLine("[{0}]", string.Join(", ", result));
            return result;
        }

        public bool Remove(K1 key1, K2 key2)
        {
            var tuple = new Tuple<K1, K2>(key1, key2);
            if (this.valuesByFirstKey.ContainsKey(key1) &&
                this.valuesBySecondKey.ContainsKey(key2) &&
                this.valuesByBothKeys.ContainsKey(tuple))
            {
                var values = this.valuesByBothKeys[tuple].ToArray();
                for (int i = 0; i < values.Length; i++)
                {
                    this.valuesByFirstKey[key1].Remove(values[i]);
                    this.valuesBySecondKey[key2].Remove(values[i]);
                    this.valuesByBothKeys[tuple].Remove(values[i]);
                }

                return true;
            }

            return false;
        }
    }
}
