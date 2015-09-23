using System;
using System.Linq;
class ReverseString
{
    static void Main()
    {
        char[] array = Console.ReadLine().ToCharArray();
        array = array.Reverse().ToArray();
        foreach (char item in array)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}
