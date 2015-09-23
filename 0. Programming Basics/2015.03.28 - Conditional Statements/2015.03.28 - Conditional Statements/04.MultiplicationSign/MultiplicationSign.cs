using System;
class MultiplicationSign
{
    static void Main()
    {
        Console.Write("a = ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("b = ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("c = ");
        double c = double.Parse(Console.ReadLine());
        if (a == 0 || b == 0 || c == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            bool isAnegative = a < 0 ? true : false;
            bool isBnegative = b < 0 ? true : false;
            bool isCnegative = c < 0 ? true : false;
            if (isAnegative ^ isBnegative == false)
            {
                if (isCnegative)
                {
                    Console.WriteLine("-");    
                }
                else
                {
                    Console.WriteLine("+");
                }
            }
            else
            {
                if (isCnegative)
                {
                    Console.WriteLine("+");
                }
                else
                {
                    Console.WriteLine("-");
                }
            }
        }
    }
}
