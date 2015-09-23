using System;
class AgeAfter10Years
{
    static void Main()
    {
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Your age now:" + age);
        Console.WriteLine("In 10 years you'll be:" + (age + 10));
    }
}
