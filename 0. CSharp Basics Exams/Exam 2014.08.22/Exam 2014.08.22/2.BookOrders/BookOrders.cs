using System;
using System.Globalization;
class BookOrders
{
    static void Main()
    {
        int orders = int.Parse(Console.ReadLine());
        int AllBooks = 0;
        double EndPrice = 0;
        for (int i = 0; i < orders; i++)
        {
            int packets = int.Parse(Console.ReadLine());
            int books = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            int discount = 0;
            if (packets >= 10 && packets < 110)
            {
                discount = 4 + packets / 10;
            }
            else if (packets >= 110)
            {
                discount = 15;
            }
            AllBooks += packets * books;
            EndPrice += packets * books * price * (100 - discount) / 100;
        }
        Console.WriteLine(AllBooks);
        Console.WriteLine("{0:F2}", EndPrice);
    }
}
