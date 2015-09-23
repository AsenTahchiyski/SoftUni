using System;
class LongestAreaInArray
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] elements = new string[n];
        int counter = 1;
        int lastCombo = 0;
        string longest = "";
        for (int i = 0; i < n; i++)
        {
            elements[i] = Console.ReadLine();
            if (i == 0)
            {
                longest = elements[i];
            }
            else if (elements[i] == elements[i - 1])
            {
                counter++;
                if (counter > lastCombo)
                {
                    longest = elements[i];
                }
            }
            else
            {
                lastCombo = counter;
                counter = 1;
            }
        }
        Console.WriteLine();
        Console.WriteLine(counter);
        for (int i = 0; i < counter; i++)
        {
            Console.WriteLine(longest);
        }
    }
}
