using System;
class ChessQueens
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int distance = int.Parse(Console.ReadLine());
        if (Math.Abs(n - distance) < 2)
        {
            Console.WriteLine("No valid positions");
            return;
        }
        for (int rowQ1 = 0; rowQ1 < n; rowQ1++)
        {
            for (int colQ1 = 0; colQ1 < n; colQ1++)
            {
                for (int rowQ2 = 0; rowQ2 < n; rowQ2++)
                {
                    for (int colQ2 = 0; colQ2 < n; colQ2++)
                    {
                        if (Math.Abs(rowQ1 - rowQ2) == distance + 1 && colQ1 == colQ2)
                        {
                            Console.WriteLine("{0}{1} - {2}{3}", GetLetter(colQ1), rowQ1 + 1, GetLetter(colQ2), rowQ2 + 1);
                        }
                        if (Math.Abs(colQ1 - colQ2) == distance + 1 && rowQ1 == rowQ2)
	                    {
                            Console.WriteLine("{0}{1} - {2}{3}", GetLetter(colQ1), rowQ1 + 1, GetLetter(colQ2), rowQ2 + 1);
	                    }
                        if (Math.Abs(rowQ1 - rowQ2) == distance + 1 && Math.Abs(colQ1 - colQ2) == distance + 1)
                        {
                            Console.WriteLine("{0}{1} - {2}{3}", GetLetter(colQ1), rowQ1 + 1, GetLetter(colQ2), rowQ2 + 1);
                        }
                        
                    }
                }
            }
        }
    }
    static char GetLetter(int position)
    {
        char letter = '0';
        switch (position)
        {
            case 0: letter = 'a'; break;
            case 1: letter = 'b'; break;
            case 2: letter = 'c'; break;
            case 3: letter = 'd'; break;
            case 4: letter = 'e'; break;
            case 5: letter = 'f'; break;
            case 6: letter = 'g'; break;
            case 7: letter = 'h'; break;
            case 8: letter = 'i'; break;
            case 9: letter = 'j'; break;
            case 10: letter = 'k'; break;
            case 11: letter = 'l'; break;
            case 12: letter = 'm'; break;
            case 13: letter = 'n'; break;
            case 14: letter = 'o'; break;
            case 15: letter = 'p'; break;
            case 16: letter = 'q'; break;
            case 17: letter = 'r'; break;
            case 18: letter = 's'; break;
            case 19: letter = 't'; break;
            case 20: letter = 'u'; break;
            case 21: letter = 'v'; break;
            case 22: letter = 'w'; break;
            case 23: letter = 'x'; break;
            case 24: letter = 'y'; break;
            case 25: letter = 'z'; break;
            default:               break;
        }
        return letter;
    }
}
