using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class TheNumbers
{
    static void Main()
    {
        string messageInput = Console.ReadLine();
        MatchCollection numbers = Regex.Matches(messageInput, @"\d+");
        List<string> result = new List<string>();
        foreach (var number in numbers)
        {
            int temp = int.Parse(number.ToString());
            string num = "0x" + temp.ToString("X").PadLeft(4, '0');
            result.Add(num);
        }
        Console.WriteLine(string.Join("-", result));
    }
}
