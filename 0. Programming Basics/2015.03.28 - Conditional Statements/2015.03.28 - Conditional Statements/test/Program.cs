using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11_Number_as_Words
{
    class Program
    {
        static void Main(string[] args)
        {
           Start:
            int a = int.Parse(Console.ReadLine());
            string words = "";
            var numbers = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var numbersTwo = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            if (a == 0)
            {
                Console.WriteLine("zero");

            }
            if ((a / 100) > 0)
            {
                words += numbers[a / 100] + " hundred ";
                a %= 100;
            }
            if (a > 0)
            {
                if (words != "")
                    words += " and ";

                if (a < 20)
                    words += numbers[a];


                else
                {
                    words += numbersTwo[a / 10];
                    if ((a % 10) > 0)
                    {
                        words += "-" + numbers[a % 10];
                    }
                }
            }
            Console.WriteLine(words);
            secondVariant();
            goto Start;
        }
        public static void secondVariant()
        {
            string s = Console.ReadLine();
            string[] placement = { "thousand", "hundred", "ten", "" };
            string[] numbersToLetters = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            for (int i = 0; i < s.Length; i++)
            {
                int digits = s[i] != '0' ? (placement.Length - s.Length) + i : 3;
                int result = int.Parse(s[i].ToString());
                var type = placement[digits];
                var number = numbersToLetters[result];
                Console.WriteLine(number + type);

            }
        }
    }
}