namespace RemoveOddOccurence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string> numbers = Console.ReadLine().Split(' ').ToList();
            Dictionary<string, int> occurencesDict = new Dictionary<string, int>();
            foreach (var number in numbers)
            {
                if (!occurencesDict.ContainsKey(number))
                {
                    occurencesDict.Add(number, 1);
                }
                else
                {
                    occurencesDict[number]++;
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (occurencesDict[numbers[i]] % 2 != 0)
                {
                    numbers[i] = null;
                }
            }
            numbers.RemoveAll(n => n == null);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
