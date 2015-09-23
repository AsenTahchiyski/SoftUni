using System;
class FruitMarket
{
    static void Main()
    {
        string day = Console.ReadLine();
        double totalPrice = 0;
        for (int i = 0; i < 3; i++)
        {
            double quantity = double.Parse(Console.ReadLine());
            string product = Console.ReadLine();
            totalPrice += quantity * getPrice(product) * (1 - (discount(day, product) / 100.0));
        }
        Console.WriteLine("{0:F2}", totalPrice);
    }
    static int discount(string day, string product)
    {
        switch (day)
        {
            case "Monday": 
                return 0;
            case "Tuesday":
                if (product != "tomato" && product != "cucumber")
                    return 20;
                else
                    return 0;
            case "Wednesday":
                if (product == "tomato" || product == "cucumber")
                    return 10;
                else
                    return 0;
            case "Thursday":
                if (product == "banana")
                    return 30;
                else
                    return 0;
            case "Friday": return 10;
            case "Saturday": return 0;
            case "Sunday": return 5;
            default: return 0;
        }
    }
    static double getPrice(string product)
    {
        switch (product)
        {
            case "banana": return 1.80;
            case "cucumber": return 2.75;
            case "tomato": return 3.20;
            case "orange": return 1.60;
            case "apple": return 0.86;
            default: return 0;
        }
    }
}
