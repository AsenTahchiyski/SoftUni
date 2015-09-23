using System;
using System.Collections.Generic;
using System.Linq;
class LegoBlocks
{
    static void Main()
    {
        // input
        int n = int.Parse(Console.ReadLine());
        List<List<int>> arrays = new List<List<int>>();
        for (int i = 0; i < 2 * n; i++)
        {
            List<int> input = Console.ReadLine().Trim()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            if (i >= n)
            {
                input.Reverse();
            }
            arrays.Add(input);
        }
        // check for match
        int width = arrays[0].Count + arrays[n].Count;
        for (int i = 1; i < n; i++)
        {
            if (arrays[i].Count + arrays[i + n].Count != width)
            {
                int count = 0; // a single misfit
                foreach (var sublist in arrays)
                {
                    count += sublist.Count;
                }
                Console.WriteLine("The total number of cells is: " + count);
                return;
            }
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("[" + string.Join(", ", arrays[i]) + ", " + string.Join(", ", arrays[i + n]) + "]");
        }
    }
}
