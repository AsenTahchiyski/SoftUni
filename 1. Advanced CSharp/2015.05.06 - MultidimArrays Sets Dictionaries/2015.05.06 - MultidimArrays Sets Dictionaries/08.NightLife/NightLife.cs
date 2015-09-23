using System;
using System.Collections.Generic;
class NightLife
{
    static void Main()
    {
        var masterSchedule = new Dictionary<string, Dictionary<string, List<string>>>();
        Console.Write("Enter <city>;<venue>;<artist> : ");
        string[] input = Console.ReadLine().Split(';');
        string city = input[0];
        string venue = input[1];
        string artist = input[2];
        Dictionary<string, List<string>> sortedVenues = new Dictionary<string, List<string>>();
        while (input[0].ToUpper() != "END")
        {
            city = input[0];
            venue = input[1];
            artist = input[2];
            // check if city exists and add if false
            if (!masterSchedule.ContainsKey(city))
            {
                masterSchedule.Add(city, new Dictionary<string, List<string>>());
                sortedVenues.Add(city, new List<string>());
            }
            // check if venue exists and add if false
            if (!masterSchedule[city].ContainsKey(venue))
            {
                masterSchedule[city].Add(venue, new List<string>());
                sortedVenues[city].Add(venue);
                sortedVenues[city].Sort();
            }
            // check if artist exists and add if false
            if (!masterSchedule[city][venue].Contains(artist))
            {
                masterSchedule[city][venue].Add(artist);
            }
            Console.Write("Enter <city>;<venue>;<artist> : ");
            input = Console.ReadLine().Split(';');
        }
        Console.WriteLine(new string('-', 40));
        // print results
        foreach (var currentCity in sortedVenues)
        {
            Console.WriteLine(currentCity.Key); // print city
            foreach (var currentVenueSorted in currentCity.Value)
            {
                Console.Write("->{0}: ", currentVenueSorted); // print venue
                List<string> sortedArtists = masterSchedule[currentCity.Key][currentVenueSorted]; // sort artists
                sortedArtists.Sort();
                Console.WriteLine(string.Join(", ", sortedArtists)); // print artists
            }
        }   
    }
}
