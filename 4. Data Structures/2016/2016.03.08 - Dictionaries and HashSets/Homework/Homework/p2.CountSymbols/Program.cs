using System;
using System.Linq;

namespace p2.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashTable<char, int> dictionary = new HashTable<char, int>();
            foreach (char ch in input)
            {
                if(!dictionary.ContainsKey(ch))
                {
                    dictionary.Add(ch, 0);
                }

                dictionary[ch]++;
            }

            var result = dictionary.OrderBy(x => x.Key);
            foreach (var ch in result)
            {
                Console.WriteLine("{0}: {1} time/s", ch.Key, ch.Value);
            }
        }
    }
}
