namespace _02.CountSymbols
{
    using System;
    using System.Linq;
    using Dictionary;

    class CountSymbols
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("Input cannot be null or empty.");
            }

            CustomDictionary<char, int> dictionary = new CustomDictionary<char, int>();

            foreach (char c in input)
            {
                if (!dictionary.ContainsKey(c))
                {
                    dictionary.Add(c, 1);
                }
                else
                {
                    dictionary[c]++;
                }
            }

            var chars = dictionary.Keys;
            chars = chars.OrderBy(x => x);

            foreach (var c in chars)
            {
                Console.WriteLine("{0}: {1} time/s", c, dictionary[c]);
            }
        }
    }
}
