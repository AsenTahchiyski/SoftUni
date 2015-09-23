using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
class CommandInterpreter
{
    static void Main()
    {
        // collect input elements
        string input = Console.ReadLine();
        string[] elements = Regex.Split(input, @"\s+");
        // process commands
        string command;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] commandParam = Regex.Split(command, @"\s+");
            switch (commandParam[0])
	        {
                case "reverse": elements = Reverse(elements, command); break;
                case "sort": elements = Sort(elements, command); break;
                case "rollLeft": elements = RollLeft(elements, command); break;
                case "rollRight": elements = RollRight(elements, command); break;
		        default: break;
	        }
        }
        Console.WriteLine("[" + string.Join(", ", elements) + "]");
    }
    static string[] Reverse(string[] elements, string commandInput)
    {
        string[] command = Regex.Split(commandInput, @"\s+");
        if (command.Length != 5) Console.WriteLine("Invalid input parameters.");
        int index = int.Parse(command[2]);
        int count = int.Parse(command[4]);
        if (index < 0 || index > elements.Length - 1 ||
            count < 0 || count > elements.Length ||
            (index + count - 1) > elements.Length)
        {
            Console.WriteLine("Invalid input parameters.");
            return elements;
        }
        string[] reversed = elements.ToArray();
        int countRev = 0;
        for (int ind = index; ind <= index + count - 1; ind++)
        {
            int move = index + (count - 1) - countRev;
            reversed[ind] = elements[move];
            countRev++;
        }
        return reversed;
    }
    static string[] Sort(string[] elements, string commandInput)
    {
        string[] command = Regex.Split(commandInput, @"\s+");
        if (command.Length != 5)
        {
            Console.WriteLine("Invalid input parameters.");
            return elements;
        }
        int index = int.Parse(command[2]);
        int count = int.Parse(command[4]);
        if (index < 0 || index > elements.Length - 1 ||
            count < 0 || count > elements.Length ||
            (index + count - 1) > (elements.Length - 1))
        {
            Console.WriteLine("Invalid input parameters.");
            return elements;
        }
        List<string> sort = new List<string>();
        int sortIndex = 0;
        for (int ind = index; ind < index + count; ind++)
        {
            sort.Add(elements[ind]);
            sortIndex++;
        }
        sort.Sort();
        sortIndex = 0;
        string[] sortedOut = elements.ToArray();
        for (int ind = index; ind < index + count; ind++)
        {
            sortedOut[ind] = sort[sortIndex];
            sortIndex++;
        }
        return sortedOut;
    }
    static string[] RollRight(string[] elements, string commandInput)
    {
        string[] command = Regex.Split(commandInput, @"\s+");
        if (command.Length < 2)
        {
            Console.WriteLine("Invalid input parameters.");
            return elements;
        }
        int count = int.Parse(command[1]);
        if (count < 0 || count > int.MaxValue)
        {
            Console.WriteLine("Invalid input parameters.");
            return elements;
        }
        count = count % elements.Length;
        string[] result = elements.ToArray(); // <-- result should not be initialized empty
        string[] temp = elements.ToArray();
        for (int i = 0; i < count; i++)
        {
            for (int j = 1; j < temp.Length; j++)
            {
                result[j] = temp[j - 1];
            }
            result[0] = temp[temp.Length - 1];
            temp = result.ToArray();
        }
        return result;
    }
    static string[] RollLeft(string[] elements, string commandInput)
    {
        string[] command = Regex.Split(commandInput, @"\s+");
        if (command.Length < 2)
        {
            Console.WriteLine("Invalid input parameters.");
            return elements;
        }
        int count = int.Parse(command[1]);
        if (count < 0 || count > int.MaxValue)
        {
            Console.WriteLine("Invalid input parameters.");
            return elements;
        }
        count = count % elements.Length;
        string[] result = elements.ToArray(); // <-- result should not be initialized empty
        string[] temp = elements.ToArray();
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < temp.Length - 1; j++)
            {
                result[j] = temp[j + 1];
            }
            result[temp.Length - 1] = temp[0];
            temp = result.ToArray();
        }
        return result;
    }
}
