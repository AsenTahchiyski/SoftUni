using System;
using System.Collections.Generic;
class SpyHard
{
    static void Main()
    {
        int key = int.Parse(Console.ReadLine());
        string message = Console.ReadLine();
        List<int> output = new List<int>();
        output.Add(key);
        output.Add(message.Length);
        output.AddRange(convertSum(key, messageSum(message)));
        foreach (var item in output)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
    static int messageSum(string message)
    {
        int msgSum = 0;
        foreach (char item in message)
        {
            if (char.IsLetter(item))
            {
                msgSum += char.ToUpper(item) - 64;
            }
            else
            {
                msgSum += item;
            }
        }
        return msgSum;
    }
    static List<int> convertSum(int key, int sum)
    {
        List<int> output = new List<int>();
        while (sum >= 1)
        {
            output.Add(sum % key);
            sum /= key;
        }
        output.Reverse();
        return output;
    }
}

