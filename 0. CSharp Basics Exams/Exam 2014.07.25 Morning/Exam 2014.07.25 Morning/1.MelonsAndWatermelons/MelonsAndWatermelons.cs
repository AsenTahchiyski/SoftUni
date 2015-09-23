using System;
class MelonsAndWatermelons
{
    static void Main()
    {
        int startingDay = int.Parse(Console.ReadLine());
        int daysTotal = int.Parse(Console.ReadLine());
        int melons = 0;
        int watermelons = 0;
        int currentDay = startingDay;
        for (int i = 0; i < daysTotal; i++)
        {
            switch (currentDay)
            {
                case 1: watermelons++; break;
                case 2: melons += 2; break;
                case 3: melons++; watermelons++; break;
                case 4: watermelons += 2; break;
                case 5: watermelons += 2; melons += 2; break;
                case 6: watermelons++; melons += 2; break;
                case 7: break;
                default: break;
            }
            currentDay++;
            if (currentDay > 7)
            {
                currentDay = 1;
            }
        }
        if (watermelons == melons)
        {
            Console.WriteLine("Equal amount: {0}", melons);
        }
        else if (watermelons > melons)
        {
            Console.WriteLine("{0} more watermelons", watermelons - melons);
        }
        else
        {
            Console.WriteLine("{0} more melons", melons - watermelons);
        }
    }
}
