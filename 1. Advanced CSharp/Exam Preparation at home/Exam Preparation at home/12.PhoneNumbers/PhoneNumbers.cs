using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class PhoneNumbers
{
    static void Main()
    {
        string input;
        StringBuilder allInputData = new StringBuilder();
        Dictionary<string, string> phonebook = new Dictionary<string, string>();
        while ((input = Console.ReadLine()) != "END")
        {
            allInputData.Append(input);
        }
        Match matches = Regex.Match(allInputData.ToString(), @"([A-Z][A-Za-z]*)[^0-9A-Za-z+]*([+]?[0-9]+[0-9\- \.\/\)\(]*[0-9]+)"); // Katya Marincheva
        if (!matches.Success)
        {
            Console.WriteLine("<p>No matches!</p>");
            return;
        }
        while (matches.Success)
        {
            phonebook.Add(matches.Groups[1].Value, GetNumberDigits(matches.Groups[2].Value));
            matches = matches.NextMatch();
        }
        PrintCollection(phonebook);
    }
    static string GetNumberDigits(string messyNum)
    {
        StringBuilder newNum = new StringBuilder();
        foreach (char chr in messyNum)
        {
            if (char.IsDigit(chr) || chr == '+') newNum.Append(chr);
        }
        return newNum.ToString();
    }
    static void PrintCollection(Dictionary<string, string> phonebook)
    {
        Console.Write("<ol>");
        foreach (var item in phonebook)
        {
            Console.Write("<li><b>{0}:</b> {1}</li>", item.Key, item.Value);
        }
        Console.WriteLine("</ol>");
    }
}
