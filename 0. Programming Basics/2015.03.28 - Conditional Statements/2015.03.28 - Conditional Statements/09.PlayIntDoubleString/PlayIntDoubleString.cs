using System;
class PlayIntDoubleString
{
    static void Main()
    {
        Start:
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        Console.Write("-> ");
        int choise = int.Parse(Console.ReadLine());
        switch (choise)
        {
            case 1: 
                Console.Write("Please enter an int: ");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Output: {0}\n", a + 1);
                break;
            case 2: 
                Console.Write("Please enter a double: ");
                double b = double.Parse(Console.ReadLine());
                Console.WriteLine("Output: {0}\n", b + 1);
                break;
            case 3: 
                Console.Write("Please enter a string: ");
                string c = Console.ReadLine();
                Console.WriteLine("Output: " + c + "*\n");
                break;
            default: break;
        }
        goto Start;
    }
}
