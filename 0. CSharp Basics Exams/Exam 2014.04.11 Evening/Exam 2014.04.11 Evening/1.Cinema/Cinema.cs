using System;
class Cinema
{
    static void Main()
    {
        string type = Console.ReadLine();
        double ticketPrice = 0;
        switch (type)
        {
            case "Premiere": ticketPrice = 12; break;
            case "Normal": ticketPrice = 7.5; break;
            case "Discount": ticketPrice = 5; break;
            default: break;
        }
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());
        Console.WriteLine("{0:F2} leva", ticketPrice * rows * columns);
    }
}
