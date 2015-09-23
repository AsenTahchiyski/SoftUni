using System;
class SequencesOfEqualStrings
{
    static void Main()
    {
        Console.WriteLine("Enter some strings separated by a space:");
        string[] array = Console.ReadLine().Split(' ');
        Console.WriteLine("Grouped by equity:");
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != null)
            {
                Console.Write(array[i] + " ");
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] != null && array[j] == array[i])
                    {
                        Console.Write(array[j] + " ");
                        array[j] = null;
                    }
                }
                Console.WriteLine();
            }
            array[i] = null;
        }
    }
}
