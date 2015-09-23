using System;
class NumberAsWords
{
    static void Main()
    {
        Start:
        Console.Write("Enter a number between 0 and 999: ");
        int num = int.Parse(Console.ReadLine());
        if (num == 0)
        {
            Console.WriteLine("Zero");
        }
        else if (num > 0 && num < 20)
        {
            Console.WriteLine(number20(num));
        }
        else if (num >= 20 && num < 100)
        {
            if (num % 10 == 0)
            {
                Console.WriteLine(number10s(num / 10));
            }
            else
            {
                Console.WriteLine("{0} {1}", number10s(num / 10), number20(num % 10).ToLower());
            }
        }
        else if (num >= 100 && num < 1000)
        {
            if (num % 100 == 0)
            {
                Console.WriteLine("{0} hundred", number20(num / 100));
            }
            else if (num % 100 < 20)
            {
                Console.WriteLine("{0} hundred and {1}", number20(num / 100), number20(num % 100).ToLower());
            }
            else if (num % 10 == 0)
            {
                Console.WriteLine("{0} hundred and {1}", number20(num / 100), number10s((num % 100) / 10).ToLower());
            }
            else
            {
                Console.WriteLine("{0} hundred and {1} {2}", number20(num / 100), number10s((num % 100) / 10).ToLower(), number20(num % 10).ToLower());
            }
        }
        goto Start;
    }
    static string number20(int number)
    {
        switch (number)
        {
            case 1: return "One";
            case 2: return "Two";
            case 3: return "Three";
            case 4: return "Four";
            case 5: return "Five";
            case 6: return "Six";
            case 7: return "Seven";
            case 8: return "Eight";
            case 9: return "Nine";
            case 10: return "Ten";
            case 11: return "Eleven";
            case 12: return "Twelve";
            case 13: return "Thirteen";
            case 14: return "Fourteen";
            case 15: return "Fifteen";
            case 16: return "Sixteen";
            case 17: return "Seventeen";
            case 18: return "Eighteen";
            case 19: return "Nineteen";
            default: return "error";
        }
    }
    static string number10s(int number)
    {
        switch (number)
        {
            case 2: return "Twenty";
            case 3: return "Thirty";
            case 4: return "Fourty";
            case 5: return "Fifty";
            case 6: return "Sixty";
            case 7: return "Seventy";
            case 8: return "Eighty";
            case 9: return "Ninety";
            default: return "error";
        }
    }
}
