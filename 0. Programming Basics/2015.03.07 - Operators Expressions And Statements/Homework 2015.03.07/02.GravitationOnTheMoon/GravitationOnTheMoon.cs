using System;
class GravitationOnTheMoon
{
    static void Main()
    {
        Console.Write("Enter weight = ");
        double weight = double.Parse(Console.ReadLine());
        Console.WriteLine("Your weight on the Moon = {0}", weight * 0.17);
    }
}
