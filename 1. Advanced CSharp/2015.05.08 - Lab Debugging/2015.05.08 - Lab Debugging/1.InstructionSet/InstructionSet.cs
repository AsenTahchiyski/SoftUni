using System;
class InstructionSet_broken
{
    static void Main()
    {
        string opCode = Console.ReadLine();
        long result = 0; // moved before while cycle
        while (opCode != "END") // changed to uppercase
        {
            string[] codeArgs = opCode.Split(' ');
            switch (codeArgs[0])
            {
                case "INC":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        result = (long)operandOne + 1; // added cast for long and changed the ++ with +1
                        break;
                    }
                case "DEC":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        result = (long)operandOne - 1; // added cast for long and changed the -- with -1
                        break;
                    }
                case "ADD":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (long)operandOne + operandTwo; // added long cast
                        break;
                    }
                case "MLA":
                    {
                        int operandOne = int.Parse(codeArgs[1]);
                        int operandTwo = int.Parse(codeArgs[2]);
                        result = (long)operandOne * operandTwo; // cast moved to the first variable
                        break;
                    }
            }
            Console.WriteLine(result);
            opCode = Console.ReadLine(); // added line to read next command
        }
        
    }
}