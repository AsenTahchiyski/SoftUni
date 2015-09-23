using System;
class TorrentPirate
{
    static void Main()
    {
        int megabytes = int.Parse(Console.ReadLine());
        double ticketPrice = int.Parse(Console.ReadLine());
        double wifeSpend = int.Parse(Console.ReadLine());
        double timeToDownload = (megabytes / 2.0) / 3600.0; // hours
        double moviesToWatch = megabytes / 1500.0;
        double totalWifeSpend = wifeSpend * timeToDownload;
        if (totalWifeSpend > moviesToWatch * ticketPrice)
        {
            Console.WriteLine("cinema -> {0:F2}lv", ticketPrice * moviesToWatch);
        }
        else
        {
            Console.WriteLine("mall -> {0:F2}lv", totalWifeSpend);
        }
    }
}
