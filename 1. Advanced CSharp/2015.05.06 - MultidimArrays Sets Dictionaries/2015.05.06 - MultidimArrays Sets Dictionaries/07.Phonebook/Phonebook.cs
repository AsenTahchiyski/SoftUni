// + bonus
using System;
using System.Collections.Generic;
class Phonebook
{
    static void Main()
    {
        var phonebook = new Dictionary<string, List<string>>();
        Console.Write("Enter <name>-<number> : ");
        string[] input = Console.ReadLine().Split('-');
        while (input[0] != "search")
        {
            if (phonebook.ContainsKey(input[0]))
            {
                List<string> temp = phonebook[input[0]];
                temp.Add(input[1]);
                phonebook[input[0]] = temp;
            }
            else
            {
                List<string> temp = new List<string>();
                temp.Add(input[1]);
                phonebook.Add(input[0], temp);
            }
            Console.Write("Enter <name>-<number> : ");
            input = Console.ReadLine().Split('-');
        }
        Console.WriteLine(new string('-', 30));
        do
        {
            Console.Write("Search for: ");
            string searchName = Console.ReadLine();
            if (string.IsNullOrEmpty(searchName)) return;
            if (!phonebook.ContainsKey(searchName)) Console.WriteLine("Contact {0} does not exist.", searchName);
            else
            {
                foreach (var num in phonebook[searchName])
                {
                    Console.WriteLine("{0} -> {1}", searchName, num);    
                }
            }
        } while (true);
    }
}
