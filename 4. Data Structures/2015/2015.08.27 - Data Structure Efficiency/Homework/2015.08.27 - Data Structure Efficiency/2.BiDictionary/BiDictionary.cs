namespace _2.BiDictionary
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<TK, TV>
    {
        private readonly Dictionary<TK, IList<TV>> dictionary1;
        private readonly Dictionary<TK, IList<TV>> dictionary2;
        private readonly Dictionary<TK, TK> firstKeysBySecondKey; 

        public BiDictionary()
        {
            this.dictionary1 = new Dictionary<TK, IList<TV>>();
            this.dictionary2 = new Dictionary<TK, IList<TV>>();
            this.firstKeysBySecondKey = new Dictionary<TK, TK>();
        }

        public void Add(TK key, TV value)
        {
            AddValue(this.dictionary1, key, value);
        }

        public void RemoveByFirstKey(TK key)
        {
            this.dictionary1.Remove(key);
        }

        public void RemoveBySecondKey(TK key2)
        {
            TK key1 = this.firstKeysBySecondKey[key2];
            this.dictionary1.Remove(key1);
            this.dictionary2.Remove(key2);
        }

        public void Add(TK key, IList<TV> values)
        {
            AddAllValues(this.dictionary1, key, values);
        }

        public void Add(TK key1, TK key2, TV value)
        {
            AddValue(this.dictionary1, key1, value);
            AddValue(this.dictionary2, key2, value);
            this.firstKeysBySecondKey.Add(key2, key1);
        }

        public void Add(TK key1, TK key2, IList<TV> values)
        {
            AddAllValues(this.dictionary1, key1, values);
            AddAllValues(this.dictionary2, key2, values);
            this.firstKeysBySecondKey.Add(key2, key1);
        }

        public IList<TV> GetValuesAnyKey(TK key)
        {
            if (dictionary1.ContainsKey(key))
            {
                return dictionary1[key];
            }
            else if (dictionary2.ContainsKey(key))
            {
                return dictionary2[key];
            }
            else
            {
                throw new ArgumentException("Key not found.");
            }

        }

        public IList<TV> GetAllValuesForKey(TK key)
        {
            IList<TV> allValues = new List<TV>();

            if (dictionary1.ContainsKey(key))
            {
                foreach (var value in dictionary1[key])
                {
                    allValues.Add(value);
                }
            }

            if (dictionary2.ContainsKey(key))
            {
                foreach (var value in dictionary2[key])
                {
                    allValues.Add(value);
                }
            }

            if (allValues.Count == 0)
            {
                throw new ArgumentException("Key not found.");
            }

            return allValues;
        }

        public IList<TV> GetValuesByFirstKey(TK key)
        {
            ValidateKey(dictionary1, key);
            return dictionary1[key];
        }

        public IList<TV> GetValuesBySecondKey(TK key)
        {
            ValidateKey(dictionary2, key);
            return dictionary2[key];
        }

        private static void ValidateKey(Dictionary<TK, IList<TV>> dictionary, TK key)
        {
            if (!dictionary.ContainsKey(key))
            {
                throw new ArgumentException("Key not found.");
            }
        }

        private static void AddAllValues(IDictionary<TK, IList<TV>> dictionary, TK key, IList<TV> values)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, values);
            }
            else
            {
                foreach (var value in values)
                {
                    dictionary[key].Add(value);
                }
            }
        }

        private static void AddValue(IDictionary<TK, IList<TV>> dictionary, TK key, TV value)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, new List<TV>() { value });
            }
            else
            {
                dictionary[key].Add(value);
            }
        }
    }
}
