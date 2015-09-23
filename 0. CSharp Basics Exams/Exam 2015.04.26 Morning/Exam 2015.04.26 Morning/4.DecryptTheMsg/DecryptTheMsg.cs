using System;
using System.Collections.Generic;
class DecryptTheMsg
{
    static void Main()
    {
        int messages = 0;
        string input = Console.ReadLine();
        while (input.ToLower() != "start")
        {
            input = Console.ReadLine();
        }
        List<char> currentMsg = new List<char>();
        List<string> output = new List<string>();
        if (input.ToLower() == "start")
        {
            input = Console.ReadLine();
            while (input.ToLower() != "end")
            {
                if (!string.IsNullOrEmpty(input))
                {
                    messages++;
                }
                foreach (char symbol in input)
                {
                    currentMsg.Add(convertChar(symbol));
                }
                currentMsg.Reverse();
                string temp = "";
                foreach (var item in currentMsg)
                {
                    temp += item;
                }
                if (!string.IsNullOrEmpty(temp))
                {
                    output.Add(temp);
                }
                currentMsg.Clear();
                input = Console.ReadLine();
            }
        }
        
        if (messages > 0)
        {
            Console.WriteLine("Total number of messages: {0}", messages);
            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
        else
        {
            Console.WriteLine("No message received.");
        }
    }
    static char convertChar(char symbol)
    {
        if (char.IsLetter(symbol))
        {
            if ((symbol >= 97 && symbol <= 109) || (symbol >= 65 && symbol <= 77)) // a-m
            {
                symbol += (char)13;
            }
            else if ((symbol >= 110 && symbol <= 122) || (symbol >= 78 && symbol <= 90)) // n-z
            {
                symbol -= (char)13;
            }
        }
        else
        {
            switch (symbol)
            {
                case '+': symbol = ' '; break;
                case '%': symbol = ','; break;
                case '&': symbol = '.'; break;
                case '#': symbol = '?'; break;
                case '$': symbol = '!'; break;
                default: break;
            }
        }
        return symbol;
    }
}
