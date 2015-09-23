using System;
class OddAndEvenJumps
{
    static void Main()
    {
        string input = Console.ReadLine();
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());
        
        int counter = 1;
        int oddCounter = 1;
        int evenCounter = 1;
        long oddResult = 0;
        long evenResult = 0;
        foreach (char item in input)
        {
            if (char.IsLetter(item)) 
            {
                if (counter % 2 != 0) // is odd
                {
                    if (oddCounter % oddJump != 0 || oddCounter == 0)
                    {
                        oddResult += (int)char.ToLower(item);   
                    }
                    else
                    {
                        oddResult = oddResult * (int)char.ToLower(item);
                    }
                    oddCounter++;
                }
                else // is even
                {
                    if (evenCounter % evenJump != 0 || evenCounter == 0)
                    {
                        evenResult += (int)char.ToLower(item);
                    }
                    else
                    {
                        evenResult = evenResult * (int)char.ToLower(item);
                    }
                    evenCounter++;
                }
                counter++;    
            }
        }
        Console.WriteLine("Odd: {0}\nEven: {1}", Convert.ToString(oddResult, 16).ToUpper(), Convert.ToString(evenResult, 16).ToUpper());
    }
}
