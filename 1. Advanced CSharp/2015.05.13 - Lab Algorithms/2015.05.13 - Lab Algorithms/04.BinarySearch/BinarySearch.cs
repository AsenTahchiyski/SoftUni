using System;
using System.Collections.Generic;
class BinarySearch
{
    static void Main()
    {
        List<int> numbers = new List<int>(Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse));
        numbers.Sort();
        int search = int.Parse(Console.ReadLine());
        int indexMin = 0, indexMax = numbers.Count - 1, counter = 0;
        int indexMid = numbers.Count % 2 == 0 ? numbers.Count / 2 : (numbers.Count + 1) / 2;
        do
        {
            counter++;
            if (numbers[indexMid] == search)
            {
                while (indexMid > 0 && numbers[indexMid - 1] == search)
                {
                    if (numbers[indexMid - 1] == search)
                    {
                        indexMid -= 1;
                    }
                }
                Console.WriteLine(indexMid);
                return;
            }
            else if(numbers[indexMid] > search)
            {
                indexMax = indexMid;
            }
            else
            {
                indexMin = indexMid;
            }
            indexMid = (indexMax + indexMin) / 2;
            if (counter > numbers.Count)
            {
                Console.WriteLine(-1);
                return;
            }
        } while (true);
    }
}
