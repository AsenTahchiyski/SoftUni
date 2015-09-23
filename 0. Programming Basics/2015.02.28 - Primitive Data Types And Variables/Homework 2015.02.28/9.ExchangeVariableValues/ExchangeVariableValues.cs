using System;
class ExchangeVariableValues
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("Starting values:\n a = {0}, b = {1}", a, b);
        int temp = a;
        a = b;
        b = temp;
        Console.WriteLine("Values after switch:\n a = {0}, b = {1}", a, b);
    }
}
